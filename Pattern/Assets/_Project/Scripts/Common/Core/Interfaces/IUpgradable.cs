using System;

public interface IUpgradable : IGunUpgradable, ITankUpradable
{
    public event Action LevelChange;
    
    public int NumberOfUpgrades { get; }
    public int Level { get; }
    public int CountOfPoints { get; }

    public void UpgradeHealth();

    public void UpgradeHeal();

    public void UpgradeSpeed();

    public void UpgradeBodyDamage();

    public void UpgradeDamage();

    public void UpgradeReload();

    public void UpgradeBulletSpeed();

    public void UpgradeBulletPenetration();
}
