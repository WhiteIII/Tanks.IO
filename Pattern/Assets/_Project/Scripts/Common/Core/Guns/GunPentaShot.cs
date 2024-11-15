using UnityEngine;
using Zenject;

public class GunPentaShot : Gun
{
    public GunPentaShot(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
    {
        Durations.Clear();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}