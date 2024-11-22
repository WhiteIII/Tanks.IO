using TanksIO.Common.Core.Player;
using TanksIO.Common.ScriptableObjects;
using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class TriplesterFactory : OrdinaryGunFactory
    {
        public new GunType GunType { get; private set; } = GunType.TriplesterGun;

        public override void CreateGun(GunData gunData, GameObject currentGunPrefab, ref GunCalculateKickback tankCalculateKickback, Rigidbody rigidbody, Transform gunSpawnPoint, ref IShootable gun, ITank tank, GlobalBulletObjectPool bulletObjectPool)
        {
            _currentGunPrefab = currentGunPrefab;
            CreatePrefab(gunData, rigidbody, gunSpawnPoint, ref gun);

            gun = new GunTriplester(gunData.BulletPrefab, _currentGunPrefab.GetComponent<GunSpawnPointList>(), tank, bulletObjectPool);
            tankCalculateKickback = new GunCalculateKickback(rigidbody, (Gun)gun);
        }
    }
}