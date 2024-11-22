using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using TanksIO.Common.Core.Enemy;
using TanksIO.Common.ScriptableObjects;
using TanksIO.Common.Core.Player;
using TanksIO.Common.Core.Guns;
using TanksIO.Common.Services.Generation;

namespace TanksIO.Common.Services
{
    public sealed class Field : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _planeMeshRenderer;
        [SerializeField] private TargetData[] _targetData;
        [SerializeField] private int _poolMaxSize;
        [SerializeField] private int _countsOfTarget;
        [SerializeField] private EnemyData _enemyData;

        [SerializeField, Range(0, 100)] private int _percentOfFirstTarget;
        [SerializeField, Range(0, 100)] private int _percentOfSecondTarget;
        [SerializeField, Range(0, 100)] private int _percentOfThirdTarget;
        [SerializeField, Range(0, 30)] private int _enemyCount;

        [Inject] private DiContainer _container;
        [Inject] private TankController _tankController;
        [Inject] private TargetsContainer _targetsContainer;
        [Inject] private PlayerData _playerData;
        [Inject] private UIElementsListData _uiElementsListData;
        [Inject] private GlobalBulletObjectPool _bulletObjectPool;
        [Inject] private GameRules _gameRules;

        private IEntityFactory _entityFactory;
        private ObjectPool<GameObject> _targetPool;
        private TargetsRandomPositions _randomPositions = new TargetsRandomPositions();
        private TargetData _currentTargetData;

        private void Awake()
        {
            int firstTargetCount = (int)Mathf.Round(_countsOfTarget * ((float)_percentOfFirstTarget / 100));
            int secondTargetCount = (int)Mathf.Round(_countsOfTarget * ((float)_percentOfSecondTarget / 100));
            int thirtTargetCount = (int)Mathf.Round(_countsOfTarget * ((float)_percentOfThirdTarget / 100));

            _randomPositions.Init(_planeMeshRenderer);
            _entityFactory = new TargetFactory();

            _targetPool = new ObjectPool<GameObject>(OnCreatePrefab, OnGetPrefab, OnRelease, OnDestroyPrefab, false, _poolMaxSize);

            _currentTargetData = _targetData[0];

            for (int i = 0; i < firstTargetCount; i++)
            {
                GetForTheFirstSpawn();
            }

            _currentTargetData = _targetData[1];

            for (int i = 0; i < secondTargetCount; i++)
            {
                GetForTheFirstSpawn();
            }

            _currentTargetData = _targetData[2];

            for (int i = 0; i < thirtTargetCount; i++)
            {
                GetForTheFirstSpawn();
            }

            _entityFactory = new EnemyFactory(_enemyData, _container, _bulletObjectPool, _gameRules);
            _currentTargetData = _enemyData;

            for (int i = 0; i < _enemyCount; i++)
            {
                GetForTheFirstSpawn();
            }
        }

        private GameObject OnCreatePrefab()
        {
            GameObject obj = _entityFactory.CreateTarget(_currentTargetData, _playerData, _uiElementsListData);

            obj.GetComponent<EntityHealth>().EntityDeath += Release;

            return obj;
        }

        private void OnGetPrefab(GameObject obj) =>
            obj.SetActive(true);

        private void OnRelease(GameObject obj) =>
            obj.SetActive(false);

        private void OnDestroyPrefab(GameObject obj)
        {
            obj.GetComponent<EntityHealth>().EntityDeath -= Release;
            GameObject.Destroy(obj);
        }

        private void GetForTheFirstSpawn()
        {
            var obj = _targetPool.Get();

            _randomPositions.SetTarget(obj);
            obj.transform.SetParent(_targetsContainer.transform);
        }

        private void GetClose()
        {
            var obj = _targetPool.Get();

            _randomPositions.SetTargetCloseZero(obj, _tankController.transform.position);
            obj.transform.SetParent(_targetsContainer.transform);
        }

        private void Get()
        {
            var obj = _targetPool.Get();

            _randomPositions.SetTargetOutOfCamera(obj, _tankController.transform.position);
            obj.transform.SetParent(_targetsContainer.transform);
        }

        private void Release(EntityHealth obj)
        {
            _targetPool.Release(obj.gameObject);
            Get();
            obj.Resurrect();
        }
    }
}