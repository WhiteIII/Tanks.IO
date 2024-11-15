using UnityEngine;
using Zenject;

public class BattleInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private UIElementsListData _uIElementsListData;
    [SerializeField] private GunsDataList _gunsDataList;
    [SerializeField] private GameRules _gameRules;

    [Inject] private DiContainer _diContainer;

    private GlobalBulletObjectPool _bulletObjectPool;

    public override void InstallBindings()
    {
        _bulletObjectPool = new GlobalBulletObjectPool(_diContainer);
        
        Container.Bind<UIElementsListData>().FromInstance(_uIElementsListData).AsSingle();
        Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
        Container.Bind<GunsDataList>().FromInstance(_gunsDataList).AsSingle();
        Container.Bind<GameRules>().FromInstance(_gameRules).AsSingle();
        Container.Bind<GlobalBulletObjectPool>().FromInstance(_bulletObjectPool).AsSingle();
    }
}