using UnityEngine;
using Zenject;

public class GlobalBulletObjectPool
{
    private BulletObjectPool _ordinaryBulletPool;
    private BulletObjectPool _homingBulletPool;
    private BulletObjectPool _waveBulletPool;
    
    public GlobalBulletObjectPool(DiContainer container)
    {
        _ordinaryBulletPool = new BulletObjectPool(container);
        _homingBulletPool = new BulletObjectPool(container);
        _waveBulletPool = new BulletObjectPool(container);
    }
    
    public GameObject GetOrdinaryBullet(GameObject bulletPrefab)
    {
        var obj = _ordinaryBulletPool.Get(bulletPrefab);

        return obj;
    }

    public GameObject GetHomingBullet(GameObject bulletPrefab)
    {
        var obj = _homingBulletPool.Get(bulletPrefab);

        return obj;
    }

    public GameObject GetWaveBullet(GameObject bulletPrefab)
    {
        var obj = _waveBulletPool.Get(bulletPrefab);

        return obj;
    }
}
