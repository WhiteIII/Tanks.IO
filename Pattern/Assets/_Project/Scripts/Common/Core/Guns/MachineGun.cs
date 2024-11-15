using UnityEngine;
using Zenject;

public class MachineGun : Gun
{
    public MachineGun(GameObject bullet, GunSpawnPointList gunSpawnPointList, ITank tank, GlobalBulletObjectPool bulletObjectPool) : base(bullet, gunSpawnPointList, tank, bulletObjectPool)
    {
        Durations.Clear();
    }

    public override void Shoot()
    {
        base.Shoot();
    }

    protected override void SetDurations()
    {
        for (int i = 0; i < GunSpawnPointList.SpawnPointList.Length; i++)
        {
            GameObject obj = BulletObjectPool.GetOrdinaryBullet(Bullet);
            Vector3 randomVector = new Vector3(Random.Range(-0.3f, 0.3f), 0f, Random.Range(-0.3f, 0.3f));
            
            Durations.Add((GunSpawnPointList.SpawnPointList[i].rotation * Vector3.up + randomVector).normalized);
            KickBackScale.Add(GunSpawnPointList.SpawnPointKickbacksScale[i]);
            obj.transform.SetPositionAndRotation(GunSpawnPointList.SpawnPointList[i].position, GunSpawnPointList.SpawnPointList[i].rotation);
            obj.GetComponent<Bullet>().Init((GunSpawnPointList.SpawnPointList[i].rotation * Vector3.up + randomVector).normalized, 
                GunSpawnPointList.SpawnPointDamageScale[i], GunSpawnPointList.SpawnPointSizeScale[i], Tank);
        }
    }
}