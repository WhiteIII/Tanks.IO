using UnityEngine;
using Zenject;

public class DoubleShotFactory : OrdinaryGunFactory
{
    public new GunType GunType { get; private set; } = GunType.DoubleShot;

    public override void CreateGun(GunData gunData, GameObject currentGunPrefab, ref GunCalculateKickback tankCalculateKickback, Rigidbody rigidbody, Transform gunSpawnPoint, ref IShootable gun, ITank tank, GlobalBulletObjectPool bulletObjectPool)
    {
        _currentGunPrefab = currentGunPrefab;
        CreatePrefab(gunData, rigidbody, gunSpawnPoint, ref gun);
        
        gun = new GunDoubleShot(gunData.BulletPrefab, _currentGunPrefab.GetComponent<GunSpawnPointList>(), tank, bulletObjectPool);
        tankCalculateKickback = new GunCalculateKickback(rigidbody, (Gun)gun);
    }
}
