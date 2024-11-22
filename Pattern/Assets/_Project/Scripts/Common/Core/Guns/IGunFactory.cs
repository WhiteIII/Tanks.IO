using UnityEngine;
using TanksIO.Common.ScriptableObjects;
using TanksIO.Common.Core.Player;

namespace TanksIO.Common.Core.Guns
{
    public interface IGunFactory
    {
        public GunType GunType { get; }

        public void CreateGun(GunData gunData, GameObject currentGunPrefab, ref GunCalculateKickback tankCalculateKickback, Rigidbody rigidbody, Transform gunSpawnPoint, ref IShootable gun, ITank tank, GlobalBulletObjectPool bulletObjectPool);
    }
}