using Zenject;
using UnityEngine;
using System.Collections;
using System;
using TanksIO.Common.ScriptableObjects;
using TanksIO.Common.Services;
using TanksIO.Common.Core.Player;

namespace TanksIO.Common.Core.Guns
{
    public class WaveBullet : Bullet
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private float _damageScale;
        [SerializeField] private float _sizeScale;

        [Inject] private GlobalBulletObjectPool _pool;
        [Inject] private GunsDataList _data;

        private bool _isActive = false;

        public override event Action<Bullet> BulletTouchedTheTarget;

        public override void Init(Vector3 duration, float damageScale, float sizeScale, ITank tank)
        {
            base.Init(duration, damageScale, sizeScale, tank);
            _isActive = true;
            StartCoroutine(SpawnBullet());
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            transform.Rotate(0, 0, 1);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntityHealthInteractional health))
            {
                CurrentDamage = Mathf.RoundToInt((float)PlayerData.Damage * DamageScale);

                health.TakeDamage(CurrentDamage, PlayerData);
                other.GetComponent<TargetMovement>().Push(Duration);
                transform.localScale = Vector3.one;
                BulletHealh = MaxHealth;
                StopAllCoroutines();
                _isActive = false;
                BulletTouchedTheTarget?.Invoke(BulletSrtipt);
            }
        }

        protected override IEnumerator KillTheBullet()
        {
            yield return new WaitForSeconds(GunData.CurrentGun.BulletTimeLife);
            transform.localScale = Vector3.one;
            BulletTouchedTheTarget?.Invoke(BulletSrtipt);
            StopAllCoroutines();
            _isActive = false;
        }

        private IEnumerator SpawnBullet()
        {
            while (_isActive)
            {
                foreach (Transform spawnPoint in _spawnPoints)
                {
                    GameObject obj = _pool.GetOrdinaryBullet(_data.GunDatas[0].BulletPrefab);
                    obj.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
                    obj.GetComponent<Bullet>().Init(spawnPoint.rotation * Vector3.up,
                        _damageScale, _sizeScale, PlayerData);
                }

                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}