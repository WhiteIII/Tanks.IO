using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UpgradeButtonUI : MonoBehaviour, IPointerDownHandler
{
    public event Action OnOpen;
    public event Action OnClose;
     
    [SerializeField] private UpgradeSelection _upgradeSelection;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private IUpgradable _playerData;
    private bool _isDisplay = false;
    
    [Inject] private void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Awake()
    {
        _playerData.LevelChange += DrawCurrentNumberOfUpgrades;
        _upgradeSelection.PlayerUpgraded += DrawCurrentNumberOfUpgrades;
    }

    private void OnDestroy()
    {
        _playerData.LevelChange -= DrawCurrentNumberOfUpgrades;
        _upgradeSelection.PlayerUpgraded -= DrawCurrentNumberOfUpgrades;
    }

    private void DrawCurrentNumberOfUpgrades()
    {
        _textMeshProUGUI.text = _playerData.NumberOfUpgrades.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isDisplay == false)
        {
            OnOpen?.Invoke();
            _isDisplay = true;
        }
        else
        {
            OnClose?.Invoke();
            _isDisplay = false;
        }
    }
}
