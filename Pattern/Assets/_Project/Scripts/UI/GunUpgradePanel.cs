using UnityEngine;
using Zenject;
using DG.Tweening;
using System;

public class GunUpgradePanel : MonoBehaviour
{
    public event Action Upgraded;
    
    [field: SerializeField] public GunType GunType {  get; private set; }   
    [field: SerializeField] public int CurrentLevel { get; private set; }

    public bool IsActive { get; private set; } = false;

    [SerializeField] private GunUpgradeButton[] _gunUpgradeButtons;
    [SerializeField] private PanelAnimation _panelAnimation;
    [SerializeField] private float _duration;

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

        Vector3 transformLengthToShow = new Vector3(_transform.localPosition.x, Camera.main.scaledPixelHeight, _transform.localPosition.z);
        Vector3 transformLengthToHide = _transform.localPosition;

        Debug.Log(transformLengthToShow + " | " + transformLengthToHide);

        _panelAnimation.Init(transformLengthToShow, transformLengthToHide, _duration, true);
        
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
        //_transform.DOLocalMove(new Vector3(_transform.localPosition.x, 460f, 0f), 0.8f, true);
        _panelAnimation.ShowPanel();
    }

    private void HideUpgradePanel()
    {
        //_transform.DOLocalMove(new Vector3(_transform.localPosition.x, 840f, 0f), 0.8f, true);
        _panelAnimation.HidePanel();
        IsActive = false;
    }
}
