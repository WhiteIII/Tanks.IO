using TanksIO.Common.Core.Player;
using TanksIO.Common.ScriptableObjects;
using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class OrdinaryGunFactory : IGunFactory
    {
        public GunType GunType { get; private set; } = GunType.OrdinaryGun;

        protected GameObject _currentGunPrefab;

        public virtual void CreateGun(GunData gunData, GameObject currentGunPrefab, ref GunCalculateKickback tankCalculateKickback,
            Rigidbody rigidbody, Transform gunSpawnPoint, ref IShootable gun, ITank tank, GlobalBulletObjectPool bulletObjectPool)
        {
            _currentGunPrefab = currentGunPrefab;
            CreatePrefab(gunData, rigidbody, gunSpawnPoint, ref gun);

            gun = new Gun(gunData.BulletPrefab, _currentGunPrefab.GetComponent<GunSpawnPointList>(), tank, bulletObjectPool);
            tankCalculateKickback = new GunCalculateKickback(rigidbody, (Gun)gun);
        }

        protected void CreatePrefab(GunData gunData, Rigidbody rigidbody, Transform gunSpawnPoint, ref IShootable gun)
        {
            if (gunSpawnPoint.childCount > 0)
            {
                GameObject.Destroy(gunSpawnPoint.GetChild(0).gameObject);
            }

            _currentGunPrefab = GameObject.Instantiate(gunData.GunPrefab);
            _currentGunPrefab.transform.SetParent(gunSpawnPoint);
            _currentGunPrefab.transform.localPosition = new Vector3(0f, 0f, 0f);
            _currentGunPrefab.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}