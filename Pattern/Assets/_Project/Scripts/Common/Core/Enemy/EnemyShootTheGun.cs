using System.Collections;
using TanksIO.Common.Core.Guns;
using TanksIO.Common.Core.Player;
using TanksIO.Common.ScriptableObjects;
using TanksIO.Common.Services;
using UnityEngine;

namespace TanksIO.Common.Core.Enemy
{
    public class EnemyShootTheGun : EntityShoot
    {
        [field: SerializeField] public float AttackDistance { get; private set; }

        public bool CoolDown { get; private set; } = true;

        [SerializeField] private EnemyAttackArea _enemyAttackArea;

        private Rigidbody _rigidbody;
        private EnemyMovement _enemyMovement;
        private ITank _enemyTank;
        private EntityHealth _enemyHealth;
        private GlobalBulletObjectPool _bulletObjectPool;

        private bool _isActive = false;

        public void Init(EnemyAttackArea enemyAttackArea, ITank enemyStatsInRunTime, Rigidbody rigidbody, 
            EnemyMovement enemyMovement, EntityHealth entityHealth, GlobalBulletObjectPool bulletObjectPool)
        {
            _enemyAttackArea = enemyAttackArea;
            _enemyMovement = enemyMovement;
            _rigidbody = rigidbody;
            _enemyTank = enemyStatsInRunTime;
            _enemyHealth = entityHealth;
            _bulletObjectPool = bulletObjectPool;

            _isActive = true;

            ChangeGun(GunType.OrdinaryGun);
            CalculateKickback = new GunCalculateKickback(_rigidbody, (Gun)Gun);

            _enemyAttackArea.OnTriggerEntered += PeriodicallyShoot;
            _enemyHealth.Reborn += ResetTheGun;
            _enemyTank.GunChanging += ChangeGun;
        }

        private void OnDestroy()
        {
            _enemyAttackArea.OnTriggerEntered -= PeriodicallyShoot;
            _enemyHealth.Reborn -= ResetTheGun;
            _enemyTank.GunChanging -= ChangeGun;
        }

        protected override void PeriodicallyShoot()
        {
            if (_isActive == false)
            {
                return;
            }

            if (_enemyAttackArea.PlayerTransform == null && _enemyAttackArea.TargetTransformList.Count == 0 && _enemyAttackArea.EnemyTransformList.Count == 0)
            {
                return;
            }

            if (Shooting == true)
            {
                return;
            }

            StartCoroutine(SpawnBullet());
        }

        protected override IEnumerator SpawnBullet()
        {
            if (_enemyAttackArea == null)
            {
                yield return null;
            }

            Shooting = true;

            while (_enemyAttackArea.PlayerTransform != null || _enemyAttackArea.EnemyTransformList.Count > 0 || _enemyAttackArea.TargetTransformList.Count > 0 || _isActive)
            {
                Gun.Shoot();

                if (_enemyMovement.IsMoving)
                {
                    yield return null;
                }

                CalculateKickback.GetKickback();

                yield return new WaitForSeconds(_enemyTank.AttackSpeed * 0.5f * GunDataList.GunDatas[0].ReloadScale);
                _rigidbody.velocity = Vector3.zero;

                yield return new WaitForSeconds(_enemyTank.AttackSpeed * 0.5f * GunDataList.GunDatas[0].ReloadScale);
            }

            Shooting = false;
        }

        public void Shoot()
        {
            Gun.Shoot();
        }

        private void ChangeGun(GunType gunType)
        {
            foreach (GunData gunData in GunDataList.GunDatas)
            {
                if (gunType == gunData.GunType)
                {
                    IGunFactory gunFactory = GunScriptsList.GunsFactoryList[gunData.GunType];
                    gunFactory.CreateGun(gunData, CurrentGunPrefab, ref CalculateKickback, Rigidbody, GunSpawnPoint, ref Gun, _enemyTank, _bulletObjectPool);
                    CalculateKickback.SetRigidBody(_rigidbody);
                }
            }
        }

        private void ResetTheGun()
        {
            ChangeGun(GunType.OrdinaryGun);
            CalculateKickback.SetRigidBody(_rigidbody);
            Shooting = false;
        }
    }
}