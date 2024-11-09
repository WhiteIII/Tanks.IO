using UnityEngine;
using Zenject;
using DG.Tweening;
using System;

public class GunUpgradePanel : MonoBehaviour
{
    [field: SerializeField] public GunType GunType {  get; private set; }   
    [field: SerializeField] public int CurrentLevel { get; private set; }

    [SerializeField] private GunUpgradeButton[] _gunUpgradeButtons;

    public bool IsActive { get; private set; } = false;

    public event Action Upgraded;

    private IUpgradable _playerData;
    private GunsDataList _gunDataList;
    private RectTransform _transform;

    [Inject] private void Construct(PlayerData playerData, GunsDataList gunsDataList)
    {
        _playerData = playerData;
        _gunDataList = gunsDataList;
    }

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        
        foreach (var button in _gunUpgradeButtons)
        {
            button.OnClicked += HideUpgradePanel;
        }

        _playerData.LevelChange += CheckCurrentLevel;
    }

    private void OnDestroy()
    {
        foreach (var button in _gunUpgradeButtons)
        {
            button.OnClicked -= HideUpgradePanel;
        }

        _playerData.LevelChange -= CheckCurrentLevel;
    }

    private void CheckCurrentLevel()
    {
        if (CurrentLevel <= _playerData.Level)
        {
            _playerData.LevelChange -= CheckCurrentLevel;
            IsActive = true;
            ShowUpgradePanel();
            GunType = _gunDataList.CurrentGun.GunType;
            Upgraded?.Invoke();
        }
    }

    private void ShowUpgradePanel()
    {
        _transform.DOLocalMove(new Vector3(_transform.localPosition.x, 460f, 0f), 0.8f, true);
    }

    private void HideUpgradePanel()
    {
        _transform.DOLocalMove(new Vector3(_transform.localPosition.x, 840f, 0f), 0.8f, true);
        IsActive = false;
    }
}
