using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeUIState : MonoBehaviour
{
    [SerializeField] private Image[] _UIElements;
    [SerializeField] private Button _button;

    private Image _buttonImage;
    private Color _originalColor;
    private int _counActivatedUIelements = 0;

    private void Awake()
    {
        _buttonImage = _button.GetComponent<Image>();
        _originalColor = _buttonImage.color;
        
        foreach (var uiElement in _UIElements)
        {
            uiElement.enabled = false;
        }

        _button.onClick.AddListener(ChangeUIElementsView);
    }

    private void ChangeUIElementsView()
    {        
        _UIElements[_counActivatedUIelements].enabled = true;
        
        _counActivatedUIelements++;

        if (_counActivatedUIelements == _UIElements.Length)
        {
            _button.onClick.RemoveListener(ChangeUIElementsView);
            _button.enabled = false;
            _buttonImage.color = Color.gray;
        }
    }

    public void Activate()
    {
        _button.enabled = true;
        _buttonImage.color = _originalColor;
    }

    public void Deactivate()
    {
        _button.enabled = false;
        _buttonImage.color = Color.gray;
    }
}

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
        UpgradePanelViewController upgradePanelViewController, Upgrades upgrade)
    {
        _upgradePanelViewController = upgradePanelViewController;

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

public class UpgradeButtonModel
{
    public event Action<bool> PlayerLevelChanged;
    
    public bool PossibilityForUpgrade => _playerData.NumberOfUpgrades > 0;
    public int NumberOfUpgrades => _playerData.NumberOfUpgrades;
    public int PlayerLevel => _playerData.Level;  

    private readonly PlayerUpgradeController _controller;
    private readonly Upgrades _upgrade;
    private readonly UpgradeButton _upgradeButton;
    private readonly IUpgradable _playerData;

    public UpgradeButtonModel(PlayerUpgradeController playerUpgradeController, 
        Upgrades upgrade, UpgradeButton upgradeButton, IUpgradable playerData)
    {
        _controller = playerUpgradeController;
        _upgrade = upgrade;
        _upgradeButton = upgradeButton;
        _playerData = playerData;

        _upgradeButton.OnUpgrade += Upgrade;
        playerData.LevelChange += LevelChanged;
    }

    private void Upgrade()
    {
        _controller.Upgrade(_upgrade);
    }

    public void OnDestroy()
    {
        _upgradeButton.OnUpgrade -= Upgrade;
        _playerData.LevelChange -= LevelChanged;
    }

    private void LevelChanged() =>
        PlayerLevelChanged?.Invoke(PossibilityForUpgrade);
}

public class UpgradeButtonViewController
{
    private readonly UpgradeButtonView _upgradeButtonView;

    public UpgradeButtonViewController(UpgradeButtonView upgradeButtonView)
    {
        _upgradeButtonView = upgradeButtonView;
    }

    public void ActivateButton() =>
        _upgradeButtonView.ActivateButton();

    public void DeactivateButton() => 
        _upgradeButtonView.DeactivateButton();
}
