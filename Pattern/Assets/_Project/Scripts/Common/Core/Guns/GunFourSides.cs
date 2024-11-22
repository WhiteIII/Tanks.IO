﻿using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class GunFourSides : Gun
    {
        public GunFourSides(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
        {
            Durations.Clear();
        }

        public override void Shoot()
        {
            base.Shoot();
        }
    }
}