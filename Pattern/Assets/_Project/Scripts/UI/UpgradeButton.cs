using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeButton : MonoBehaviour 
{
    public event Action OnUpgrade;
    
    [SerializeField] private Button _button;
    [SerializeField] private PlayerLevelViewController _levelViewController;
    
    private UpgradeButtonController _controller;
    private UpgradeButtonView _view;
    private UpgradeButtonViewController _viewController;
    private UpgradePanelViewController _upgradePanelViewController;
    private UpgradeButtonModel _model;
    private PlayerUpgradeController _playerUpgradeController;
    private IUpgradable _playerData;

    [Inject] private void Construct(PlayerUpgradeController playerUpgradeController, PlayerData playerData)
    {
        _playerUpgradeController = playerUpgradeController;
        _playerData = playerData;
    }

    public void Init(int maxCountOfUpgrades, 
        UpgradePanelViewController upgradePanelViewController, Upgrades upgrade, 
        PlayerLevelViewController playerLevelViewController)
    {
        _upgradePanelViewController = upgradePanelViewController;
        _levelViewController = playerLevelViewController;

        _view = new UpgradeButtonView(_button.image);
        _viewController = new UpgradeButtonViewController(_view);
        _controller = new UpgradeButtonController(_button, maxCountOfUpgrades);
        _model = new UpgradeButtonModel(_playerUpgradeController, upgrade, this, _playerData);
        _levelViewController.Init(_model);

        _controller.OnUpgrade += Upgraded;
        _model.PlayerLevelChanged += ChangeButtonActive;
    }

    private void OnDestroy()
    {
        _model.PlayerLevelChanged -= ChangeButtonActive;
        _controller.OnUpgrade -= Upgraded;
        _controller.OnDestroy();
        _model.OnDestroy();
    }

    private void Upgraded()
    {
        OnUpgrade?.Invoke();
        _upgradePanelViewController.DrawNewState();
    }

    private void ChangeButtonActive(bool isActive)
    {
        if (isActive)
        {
            _controller.AllowUpgrade();
            _viewController.ActivateButton();
        }
        else
        {
            _controller.BlockUpgrade();
            _viewController.DeactivateButton();
        }
    }
}