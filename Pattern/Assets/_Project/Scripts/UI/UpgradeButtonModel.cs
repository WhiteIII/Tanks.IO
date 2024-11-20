using System;

public class UpgradeButtonModel
{
    public event Action<bool> PlayerLevelChanged;
    
    public bool PossibilityForUpgrade => _playerData.NumberOfUpgrades > 0;
    public int NumberOfUpgrades => _playerData.NumberOfUpgrades;
    public int PlayerLevel => _playerData.Level;  

    private readonly PlayerUpgradeController _controller;
    private readonly UpgradeButton _upgradeButton;
    private readonly Upgrades _upgrade;
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
