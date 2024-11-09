using UnityEngine;

public class GunSniper : Gun
{
    public GunSniper(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
    {
        Durations.Clear();
    }

    protected override void SetDurations()
    {
        for (int i = 0; i < GunSpawnPointList.SpawnPointList.Length; i++)
        {
            GameObject obj = BulletObjectPool.GetHomingBullet(Bullet);
            Durations.Add(GunSpawnPointList.SpawnPointList[i].rotation * Vector3.up);
            KickBackScale.Add(GunSpawnPointList.SpawnPointKickbacksScale[i]);
            obj.transform.SetPositionAndRotation(GunSpawnPointList.SpawnPointList[i].position, GunSpawnPointList.SpawnPointList[i].rotation);
            obj.GetComponent<Bullet>().Init(GunSpawnPointList.SpawnPointList[i].rotation * Vector3.up,
                GunSpawnPointList.SpawnPointDamageScale[i], GunSpawnPointList.SpawnPointSizeScale[i], Tank);
        }
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
