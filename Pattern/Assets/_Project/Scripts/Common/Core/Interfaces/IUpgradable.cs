using System;

public interface IUpgradable : IGunUpgradable, ITankUpradable
{
    public int NumberOfUpgrades { get; }
    public int Level { get; }
    public int CountOfPoints { get; }

    public event Action LevelChange;

    public void UpgradeHealth();

    public void UpgradeHeal();

    public void UpgradeSpeed();

    public void UpgradeBodyDamage();

    public void UpgradeDamage();

    public void UpgradeReload();

    public void UpgradeBulletSpeed();

    public void UpgradeBulletPenetration();
}
