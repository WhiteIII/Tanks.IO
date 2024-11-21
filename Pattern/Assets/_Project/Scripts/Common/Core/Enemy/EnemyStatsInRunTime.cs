using System;
using UnityEngine;

public class EnemyStatsInRunTime : ITank, IUpgradable, IEntityDamagable
{
    public event Action PointsCountChange;
    public event Action LevelChange;
    public event Action<GunType> GunChanging;
    
    public int BodyDamage { get; protected set; }
    public int Health { get; private set; }
    public int Heal { get; private set; }
    public int Damage { get; private set; }
    public float Speed { get; private set; }
    public float AttackSpeed { get; private set; }
    public float BulletSpeed { get; private set; }
    public int BulletPenetration { get; private set; }
    public int CountOfPoints { get; private set; }
    public int Level { get; private set; }
    public int Points { get; private set; }
    public GunType GunType { get; private set; }

    public int NumberOfUpgrades { get; private set; } = 0;

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

    private GameRules _gameRules;

    private delegate void UpgradeStats();

    private UpgradeStats[] _upgradeStats = new UpgradeStats[9];

    public EnemyStatsInRunTime(EnemyData enemyData, GameRules gameRules)
    {
        Health = enemyData.Health;
        Heal = enemyData.Heal;
        BodyDamage = enemyData.BodyDamage;
        Damage = enemyData.Damage;
        Speed = enemyData.Speed;
        AttackSpeed = enemyData.AttackSpeed;
        BulletSpeed = enemyData.BulletSpeed;
        BulletPenetration = enemyData.BulletPenetration;
        Points = enemyData.Points;
        _gameRules = gameRules;

        _originalSpeed = Speed;
        _originalAttackSpeed = AttackSpeed;
        _originalBulletSpeed = BulletSpeed;
        _originalHealth = Health;
        _originalHeal = Heal;
        _originalDamage = Damage;
        _originalBulletPenetration = BulletPenetration;
        _originalBodyDamage = BodyDamage;

        _upgradeStats[0] = UpgradeHealth;
        _upgradeStats[1] = UpgradeHeal;
        _upgradeStats[2] = UpgradeDamage;
        _upgradeStats[3] = UpgradeSpeed;
        _upgradeStats[4] = UpgradeBodyDamage;
        _upgradeStats[5] = UpgradeDamage;
        _upgradeStats[6] = UpgradeReload;
        _upgradeStats[7] = UpgradeBulletSpeed;
        _upgradeStats[8] = UpgradeBulletPenetration;

        GunType = GunType.OrdinaryGun;
    }

    public void AddPoints(int points)
    {
        if (points > 0)
        {
            CountOfPoints += points;
            Points += Mathf.RoundToInt(Convert.ToSingle(points) * 0.3f);
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
            TryUpgradeGun();
            _pointForUpgrade -= _pointsCountForNextUpgrade;
            _pointsCountForNextUpgrade *= 1.25f;
            _pointsCountForNextUpgrade = Mathf.Round(_pointsCountForNextUpgrade);
            HiddenStatsUpgrade();
            _upgradeStats[UnityEngine.Random.Range(0, _upgradeStats.Length)]?.Invoke();
        }
        
        LevelChange?.Invoke();
    }

    private void TryUpgradeGun()
    {
        if (Level != _gameRules.LevelForFirstGunUpgrade && Level != _gameRules.LevelForSecondGunUpgrade && Level != _gameRules.LevelForThirtGunUpgrade)
        {
            Debug.Log(Level);
            return;
        }

        if (Level == _gameRules.LevelForFirstGunUpgrade)
        {
            ChangeGun(_gameRules.GunTypesFirstLevel[UnityEngine.Random.Range(0, _gameRules.GunTypesFirstLevel.Length)]);
            Debug.Log(GunType);
        }

        if (Level == _gameRules.LevelForSecondGunUpgrade)
        {
            if (_gameRules.GunsForUpgrades.ContainsKey(GunType) == false)
            {
                return;
            }
            
            ChangeGun(_gameRules.GunsForUpgrades[GunType][UnityEngine.Random.Range(0, _gameRules.GunsForUpgrades[GunType].Length)]);
            Debug.Log(GunType);
        }

        if (Level == _gameRules.LevelForThirtGunUpgrade)
        {
            if (_gameRules.GunsForUpgrades.ContainsKey(GunType) == false)
            {
                return;
            }

            ChangeGun(_gameRules.GunsForUpgrades[GunType][UnityEngine.Random.Range(0, _gameRules.GunsForUpgrades[GunType].Length)]);
            Debug.Log(GunType);
        }
    }

    private void HiddenStatsUpgrade()
    {
        Health += 15;
        Heal += 3;
        BodyDamage += 2;
        Damage += 2;
        Speed += 0.05f;

        if (AttackSpeed - 0.005f >= 0)
        {
            AttackSpeed -= 0.005f;
        }

        BulletSpeed += 0.1f;
    }

    public void UpgradeHealth()
    {
        Health += 15;
        NumberOfUpgrades--;
    }

    public void UpgradeHeal()
    {
        Heal += 5;
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
        if (AttackSpeed - 0.01f >= 0)
        {
            AttackSpeed -= 0.01f;
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

    public void ChangeGun(GunType gunType)
    {
        GunType = gunType;
        GunChanging?.Invoke(GunType);
    }
}

