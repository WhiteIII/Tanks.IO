using UnityEngine;
using Zenject;

public class GunSpeedster : Gun
{
    public GunSpeedster(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
    {
        Durations.Clear();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
