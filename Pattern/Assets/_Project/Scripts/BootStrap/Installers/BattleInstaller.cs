using TanksIO.Common.Core.Guns;
using TanksIO.Common.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace TanksIO.BootStrap.Installers
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private UIElementsListData _uIElementsListData;
        [SerializeField] private GunsDataList _gunsDataList;
        [SerializeField] private GameRules _gameRules;

        [Inject] private DiContainer _diContainer;

        private GlobalBulletObjectPool _bulletObjectPool;
        private PlayerUpgradeController _playerUpgradeController;

        public override void InstallBindings()
        {
            _bulletObjectPool = new GlobalBulletObjectPool(_diContainer);
            _playerUpgradeController = new PlayerUpgradeController(_playerData);

            Container.Bind<UIElementsListData>().FromInstance(_uIElementsListData).AsSingle();
            Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
            Container.Bind<GunsDataList>().FromInstance(_gunsDataList).AsSingle();
            Container.Bind<GameRules>().FromInstance(_gameRules).AsSingle();
            Container.Bind<GlobalBulletObjectPool>().FromInstance(_bulletObjectPool).AsSingle();
            Container.Bind<PlayerUpgradeController>().FromInstance(_playerUpgradeController).AsSingle();
        }
    }
}