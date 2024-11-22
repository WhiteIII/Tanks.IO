using DG.Tweening;
using TanksIO.Common.ScriptableObjects;
using TanksIO.UI;
using UnityEngine;
using Zenject;

namespace TanksIO.BootStrap
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private int _tweenersCapacity = 2000;
        [SerializeField] private int _sequencesCapacity = 100;
        [SerializeField] private UpgradePanelsFactory _upgradePanelsFactory;
        [SerializeField] private UpgradePanelConfig _upgradePanelConfig;

        private PlayerData _playerData;
        private PlayerUpgradeController _playerUpgradeController;
        private GameRules _gameRules;
        private UpgradeButtonFactory _upgradeButtonFactory;

        [Inject(Id = "UpgradePanelCanvas")] private Canvas _upgradeCanvas;

        [Inject]
        private void Construct(PlayerData playerData, GameRules gameRules,
            PlayerUpgradeController playerUpgradeController, DiContainer diContainer)
        {
            _playerData = playerData;
            _gameRules = gameRules;
            _playerUpgradeController = playerUpgradeController;
            _upgradeButtonFactory = new(_upgradePanelConfig.UpgradeButton, diContainer, _upgradePanelConfig.CountOfUpgrades);

            _playerData.PlayerDataLoad();
            _gameRules.Init();

            DOTween.SetTweensCapacity(_tweenersCapacity, _sequencesCapacity);

            _upgradePanelsFactory.Create(_upgradePanelConfig, _upgradeButtonFactory, _upgradeCanvas);
        }

        private void OnDestroy()
        {
            _playerData.ResetThePoints();
            _playerData.ResetStats();
        }
    }
}