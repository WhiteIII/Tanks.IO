using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class GunOcto : Gun
    {
        public GunOcto(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
        {
            Durations.Clear();
        }

        public override void Shoot()
        {
            base.Shoot();
        }
    }
}