using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace TanksIO.Common.Core.Guns
{
    public class BulletObjectPool
    {
        private GameObject _bulletObject;
        private ObjectPool<GameObject> _pool;
        private DiContainer _container;
        private int _poolMaxSize = 40;

        public BulletObjectPool(DiContainer container)
        {
            _container = container;

            _pool = new ObjectPool<GameObject>(OnCreatePrefab, OnGetPrefab, OnRelease, OnDestroyPrefab, false, _poolMaxSize);
        }

        private GameObject OnCreatePrefab()
        {
            GameObject obj = _container.InstantiatePrefab(_bulletObject);

            obj.GetComponent<Bullet>().BulletTouchedTheTarget += Release;

            return obj;
        }

        private void OnDestroyPrefab(GameObject obj)
        {
            obj.GetComponent<Bullet>().BulletTouchedTheTarget -= Release;
            GameObject.Destroy(obj);
        }

        private void Release(Bullet obj) =>
            _pool.Release(obj.gameObject);

        private void OnRelease(GameObject obj) =>
            obj.SetActive(false);

        private void OnGetPrefab(GameObject obj)
        {
            obj.SetActive(true);
        }

        public GameObject Get(GameObject bulletPrefab)
        {
            _bulletObject = bulletPrefab;
            var obj = _pool.Get();

            return obj;
        }
    }
}