using System.Collections;
using TanksIO.Common.Core.Guns;
using TanksIO.Common.Core.Player;
using TanksIO.Common.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace TanksIO.Common.Core.Enemy
{
    public abstract class EntityShoot : MonoBehaviour
    {
        [SerializeField] protected Transform GunSpawnPoint;

        [Inject] protected DiContainer DIContainer;
        [Inject] protected GunsDataList GunDataList;

        protected IShootable Gun;
        protected Rigidbody Rigidbody;
        protected GameObject CurrentGunPrefab;
        protected GunCalculateKickback CalculateKickback;
        protected GunScriptsList GunScriptsList = new GunScriptsList();
        protected bool Shooting = false;
        protected int PoolMaxSize = 20;

        protected abstract void PeriodicallyShoot();

        protected abstract IEnumerator SpawnBullet();
    }
}