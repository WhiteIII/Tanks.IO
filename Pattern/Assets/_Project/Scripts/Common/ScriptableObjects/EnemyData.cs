using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Game", menuName = "Game/Enemy")]
public class EnemyData : TargetData, ITank, IUpgradable
{
    public event Action LevelChange;
    public event Action<GunType> GunChanging;
    public event Action PointsCountChange;
    
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float AttackSpeed { get; private set; }
    [field: SerializeField] public float BulletSpeed { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int BulletPenetration { get; private set; }
    [field: SerializeField] public GunType GunType { get; private set; }
    [field: SerializeField] public int CountOfPoints { get; private set; }
    [field: SerializeField] public int Heal { get; private set; }

    public int NumberOfUpgrades { get; private set; } = 0;

    public int Level { get; private set; }

    private float _pointsCountForNextUpgrade = 30;
    private float _pointForUpgrade = 0;

    private float _originalSpeed;
    private float _originalAttackSpeed;
    private float _originalBulletSpeed;
    private int _originalHealth;
    private int _originalHeal;
    private int _originalDamage;
    private int _originalBulletPenetration;
    private int _originalBodyDamage;

    public void AddPoints(int points)
    {
        if (points > 0)
        {
            CountOfPoints += points;
            _pointForUpgrade += points;
            UpgradeLevel();
            PointsCountChange?.Invoke();
        }
    }

    public void ResetThePoints()
    {
        CountOfPoints = 0;
        Level = 0;
        _pointForUpgrade = 0;
        _pointsCountForNextUpgrade = 30;
    }

    public void PlayerDataLoad()
    {
        _originalHealth = Health;
        _originalHeal = Heal;
        _originalDamage = Damage;
        _originalSpeed = Speed;
        _originalAttackSpeed = AttackSpeed;
        _originalBulletSpeed = BulletSpeed;
        _originalBulletPenetration = BulletPenetration;
        _originalBodyDamage = BodyDamage;
    }

    public void ResetStats()
    {
        Health = _originalHealth;
        Heal = _originalHeal;
        Damage = _originalDamage;
        Speed = _originalSpeed;
        AttackSpeed = _originalAttackSpeed;
        BulletSpeed = _originalBulletSpeed;
        BulletPenetration = _originalBulletPenetration;
        BodyDamage = _originalBodyDamage;

        NumberOfUpgrades = 0;

        GunType = GunType.OrdinaryGun;
    }

    private void UpgradeLevel()
    {
        if (_pointForUpgrade < _pointsCountForNextUpgrade)
        {
            return;
        }

        while (_pointForUpgrade >= _pointsCountForNextUpgrade)
        {
            Level++;
            NumberOfUpgrades++;
            _pointForUpgrade -= _pointsCountForNextUpgrade;
            _pointsCountForNextUpgrade *= 1.25f;
            _pointsCountForNextUpgrade = Mathf.Round(_pointsCountForNextUpgrade);
            HiddenStatsUpgrade();
        }

        LevelChange?.Invoke();
    }

    private void HiddenStatsUpgrade()
    {
        Health += 15;
        Heal += 3;
        BodyDamage += 2;
        Damage += 2;
        Speed += 0.05f;

        if (AttackSpeed - 0.02f >= 0)
        {
            AttackSpeed -= 0.02f;
        }

        BulletSpeed += 0.1f;
    }

    public void ChangeGun(GunType gunType)
    {
        GunType = gunType;
        GunChanging?.Invoke(GunType);
    }

    public void UpgradeHealth()
    {
        Health += 15;
        NumberOfUpgrades--;
    }

    public void UpgradeHeal()
    {
        Health += 5;
        NumberOfUpgrades--;
    }

    public void UpgradeSpeed()
    {
        Speed += 0.07f;
        NumberOfUpgrades--;
    }

    public void UpgradeBodyDamage()
    {
        BodyDamage += 5;
        NumberOfUpgrades--;
    }

    public void UpgradeDamage()
    {
        Damage += 4;
        NumberOfUpgrades--;
    }

    public void UpgradeReload()
    {
        if (AttackSpeed - 0.03f >= 0)
        {
            AttackSpeed -= 0.03f;
            NumberOfUpgrades--;
        }
    }

    public void UpgradeBulletSpeed()
    {
        BulletSpeed += 0.1f;
        NumberOfUpgrades--;
    }

    public void UpgradeBulletPenetration()
    {
        NumberOfUpgrades--;
    }
}