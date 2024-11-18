using System.Collections.Generic;

public class PlayerUpgradeController
{
    private delegate void UpgradeStats();

    private readonly IUpgradable _playerData;
    private readonly Dictionary<Upgrades, UpgradeStats> _upgradeStats = new();

    public PlayerUpgradeController(IUpgradable playerData)
    {
        _playerData = playerData;

        _upgradeStats.Add(Upgrades.Health, _playerData.UpgradeHealth);
        _upgradeStats.Add(Upgrades.Heal, _playerData.UpgradeHeal);
        _upgradeStats.Add(Upgrades.Speed, _playerData.UpgradeSpeed);
        _upgradeStats.Add(Upgrades.BodyDamage, _playerData.UpgradeBodyDamage);
        _upgradeStats.Add(Upgrades.Damage, _playerData.UpgradeDamage);
        _upgradeStats.Add(Upgrades.Reload, _playerData.UpgradeReload);
        _upgradeStats.Add(Upgrades.BulletSpeed, _playerData.UpgradeBulletSpeed);
        _upgradeStats.Add(Upgrades.BulletPenetration, _playerData.UpgradeBulletPenetration);
    }

    public void Upgrade(Upgrades upgrade) =>
        _upgradeStats[upgrade].Invoke();
}
