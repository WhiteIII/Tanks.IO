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
    
    private UpgradeButtonController _controller;
    private UpgradeButtonView _view;
    private UpgradeButtonViewController _viewController;
    private UpgradePanelViewController _upgradePanelViewController;
    private UpgradeButtonModel _model;
    private IUpgradable _playerData;

    [Inject] private void Construct(PlayerData playerData) =>
        _playerData = playerData;

    public void Init(int maxCountOfUpgrades, UpgradePanelViewController upgradePanelViewController)
    {
        _upgradePanelViewController = upgradePanelViewController;

        _view = new UpgradeButtonView(_button.image);
        _viewController = new UpgradeButtonViewController(_view);
        _controller = new UpgradeButtonController(_button, maxCountOfUpgrades);
        _model = new UpgradeButtonModel(_playerData);

        _controller.OnUpgrade += Upgraded;
    }

    private void OnDestroy()
    {
        _controller.OnUpgrade -= Upgraded;
        _controller.OnDestroy();
    }

    private void Upgraded()
    {
        OnUpgrade?.Invoke();
    }

    
}

public class UpgradePanelViewController
{ 
    private readonly UIElementRepository _elementRepository;
    private readonly UpgradePanelView _view = new();

    public UpgradePanelViewController(UIElementRepository elementRepository)
    {
        _elementRepository = elementRepository;

        _elementRepository.OffAllObjects();
    }

    public void DrawNewState()
    {
        if (_elementRepository.IsNotEmpty == false)
            return;
        
        GameObject uIElement = _elementRepository.GetAndUnregister();
        _view.DrawNewState(uIElement);
    }
}


public class UpgradePanelView
{
    public void DrawNewState(GameObject uIElement) =>
        uIElement.SetActive(false);
}

public class UpgradeButtonModel
{
    private readonly IUpgradable _playerData;

    public UpgradeButtonModel(IUpgradable playerData) =>
        _playerData = playerData;


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
