using System.Collections;
using UnityEngine;
using Zenject;

public class ShootTheGun : EntityShoot
{
    [SerializeField] private VariableJoystick _variableJoystick;

    private IGunUpgradable _playerGunData;
    private IAttackable _playerAttackData;
    private ITank _playerTank;
    private GlobalBulletObjectPool _bulletObjectPool;

    [Inject] private void Construct(PlayerData playerData, GlobalBulletObjectPool bulletObjectPool)
    {
        _playerGunData = playerData;
        _playerAttackData = playerData;
        _playerTank = playerData;
        _bulletObjectPool = bulletObjectPool;
    }
    
    private void Awake()
    {      
        Rigidbody = GetComponent<Rigidbody>();

        ChangeGun(GunType.OrdinaryGun);

        _variableJoystick.JoystickPositionChanged += PeriodicallyShoot;
        _playerGunData.GunChanging += ChangeGun;
    }

    private void OnDestroy()
    {
        _variableJoystick.JoystickPositionChanged -= PeriodicallyShoot;
        _playerGunData.GunChanging -= ChangeGun;
    }

    protected override void PeriodicallyShoot()
    {
        if (Shooting)
        {
            return;
        }

        if (_variableJoystick.OnClicked)
        {
            StartCoroutine(SpawnBullet());
        }
    }

    protected override IEnumerator SpawnBullet()
    {
        Shooting = true;

        while (_variableJoystick.OnClicked)
        {
            Gun.Shoot();

            CalculateKickback.GetKickback();

            yield return new WaitForSeconds(_playerAttackData.AttackSpeed * 0.5f * GunDataList.CurrentGun.ReloadScale);
            Rigidbody.velocity = Vector3.zero;

            yield return new WaitForSeconds(_playerAttackData.AttackSpeed * 0.5f * GunDataList.CurrentGun.ReloadScale);
        }

        Shooting = false;
    }

    private void ChangeGun(GunType gunType)
    {
        foreach (GunData gunData in GunDataList.GunDatas)
        {
            if (gunType == gunData.GunType)
            {
                IGunFactory gunFactory = GunScriptsList.GunsFactoryList[gunData.GunType];
                gunFactory.CreateGun(gunData, CurrentGunPrefab, ref CalculateKickback, Rigidbody, GunSpawnPoint, ref Gun, _playerTank, _bulletObjectPool);
                GunDataList.ChangeCurrentGun(gunData);
            }
        }
    }
}
