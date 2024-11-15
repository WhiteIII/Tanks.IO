using System.Collections;
using UnityEngine;
using Zenject;

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
