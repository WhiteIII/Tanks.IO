using System;
using UnityEngine;
using Zenject;


public class UpgradeSelection : MonoBehaviour
{
    [SerializeField] private UpgradeUIState[] _upgradeUIState;
    
    public bool IsActive { get; private set; } = false;
    
    private IUpgradable _playerData;

    public event Action PlayerLevelUpgrade;
    public event Action PlayerUpgraded;
    
    [Inject] private void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Start()
    {
        foreach (var upgrade in _upgradeUIState)
        {
            upgrade.Deactivate();
        }

        _playerData.LevelChange += PanelSetActive;    
    }

    private void OnDestroy()
    {
        _playerData.LevelChange -= PanelSetActive;
    }

    private void PanelSetActive()
    {
        foreach (var upgrade in _upgradeUIState)
        {
            upgrade.Activate();
        }

        PlayerLevelUpgrade?.Invoke();
        IsActive = true;
        _playerData.LevelChange -= PanelSetActive;
    }

    private void CheckTheActive()
    {
        if (_playerData.NumberOfUpgrades == 0)
        {
            IsActive = false;
            
            foreach (var upgrade in _upgradeUIState)
            {
                upgrade.Deactivate();
            }

            PlayerUpgraded?.Invoke();

            _playerData.LevelChange += PanelSetActive;
        }
    }

    public void UpgradeHealth()
    {
        _playerData.UpgradeHealth();
        CheckTheActive();
    }

    public void UpgradeHeal()
    {
        _playerData.UpgradeHeal();
        CheckTheActive();
    }

    public void UpgradeSpeed()
    {
        _playerData.UpgradeSpeed();
        CheckTheActive();
    }
    
    public void UpgradeBodyDamage()
    {
        _playerData.UpgradeBodyDamage();
        CheckTheActive();
    }

    public void UpgradeDamage()
    {
        _playerData.UpgradeDamage();
        CheckTheActive();
    }

    public void UpgradeReload()
    {
        _playerData.UpgradeReload();
        CheckTheActive();
    }

    public void UpgradeBulletSpeed()
    {
        _playerData.UpgradeBulletSpeed();
        CheckTheActive();
    }

    public void UpgradeBulletPenetration()
    {
        _playerData.UpgradeBulletPenetration();
        CheckTheActive();
    }
}
