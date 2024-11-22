﻿using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class GunQuadroShot : Gun
    {
        public GunQuadroShot(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
        {
            Durations.Clear();
        }

        public override void Shoot()
        {
            base.Shoot();
        }
    }
}