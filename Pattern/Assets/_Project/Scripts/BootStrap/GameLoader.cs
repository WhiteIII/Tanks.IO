using DG.Tweening;
using UnityEngine;
using Zenject;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private int _tweenersCapacity = 2000;
    [SerializeField] private int _sequencesCapacity = 100;
    [SerializeField] private UpgradePanelsFacrory _upgradePanelsFacrory;
    [SerializeField] private UpgradePanelConfig _upgradePanelConfig;
    
    private PlayerData _playerData;
    private PlayerUpgradeController _playerUpgradeController;
    private GameRules _gameRules;

    [Inject] private void Construct(PlayerData playerData, GameRules gameRules, PlayerUpgradeController playerUpgradeController)
    {
        _playerData = playerData;
        _gameRules = gameRules;
        _playerUpgradeController = playerUpgradeController;

        for (int i = 0; i < (int)Upgrades.BulletPenetration; i++) 
            _upgradePanelsFacrory.Create();

        _playerData.PlayerDataLoad();
        _gameRules.Init();

        DOTween.SetTweensCapacity(_tweenersCapacity, _sequencesCapacity);
    }

    private void OnDestroy()
    {
        _playerData.ResetThePoints();
        _playerData.ResetStats();
    }
}
