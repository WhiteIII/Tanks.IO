using UnityEngine;

public class GunDoubleShot : Gun
{
    public GunDoubleShot(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
    {
        Durations.Clear();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
