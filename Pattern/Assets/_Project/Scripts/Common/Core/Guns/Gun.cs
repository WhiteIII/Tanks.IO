using System.Collections.Generic;
using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class Gun : IShootable, IDiractionOfShot
    {
        protected GameObject Bullet;
        protected GlobalBulletObjectPool BulletObjectPool;
        protected GunSpawnPointList GunSpawnPointList;
        protected ITank Tank { get; private set; }

        public List<Vector3> Durations { get; protected set; } = new List<Vector3>();

        public List<float> KickBackScale { get; protected set; } = new List<float>();

        public Gun(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool)
        {
            Bullet = bullet;
            GunSpawnPointList = gunSpawnPointList;
            BulletObjectPool = bulletObjectPool;
            Tank = tank;
        }

        protected virtual void SetDurations()
        {
            for (int i = 0; i < GunSpawnPointList.SpawnPointList.Length; i++)
            {
                GameObject obj = BulletObjectPool.GetOrdinaryBullet(Bullet);
                Durations.Add(GunSpawnPointList.SpawnPointList[i].rotation * Vector3.up);
                KickBackScale.Add(GunSpawnPointList.SpawnPointKickbacksScale[i]);
                obj.transform.SetPositionAndRotation(GunSpawnPointList.SpawnPointList[i].position, GunSpawnPointList.SpawnPointList[i].rotation);
                obj.GetComponent<Bullet>().Init(GunSpawnPointList.SpawnPointList[i].rotation * Vector3.up,
                    GunSpawnPointList.SpawnPointDamageScale[i], GunSpawnPointList.SpawnPointSizeScale[i], Tank);
            }
        }

        public virtual void Shoot()
        {
            Durations.Clear();

            SetDurations();
        }
    }
}