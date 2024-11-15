using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameRules", menuName = "Game/GameRules")]
public class GameRules : ScriptableObject
{
    public readonly int LevelForFirstGunUpgrade = 15;
    public readonly int LevelForSecondGunUpgrade = 30;
    public readonly int LevelForThirtGunUpgrade = 45;

    public readonly GunType[] GunTypesFirstLevel = new GunType[]
    {
        GunType.DoubleShot,
        GunType.SniperGun,
        GunType.SpeedsterGun,
        GunType.MachineGun
    };

    public readonly GunType[] DoubleShotGunTypesSecondLevel = new GunType[]
    {
        GunType.TripleShot,
        GunType.FourSides,
        GunType.QuadroShot,
    };

    public readonly GunType[] SpeedsterGunTypesSecondLevel = new GunType[]
    {
        GunType.TriplesterGun
    };

    public readonly GunType[] FourSidesTypesThirdLevel = new GunType[]
    {
        GunType.Octo
    };

    public readonly GunType[] TripleShotGunTypesThirdLevel = new GunType[]
    {
        GunType.Triplet,
        GunType.PentaShot
    };

    public Dictionary<GunType, GunType[]> GunsForUpgrades { get; private set; } = new Dictionary<GunType, GunType[]>();
    
    public void Init()
    {
        GunsForUpgrades.Add(GunType.OrdinaryGun, GunTypesFirstLevel);
        GunsForUpgrades.Add(GunType.DoubleShot, DoubleShotGunTypesSecondLevel);
        GunsForUpgrades.Add(GunType.FourSides, FourSidesTypesThirdLevel);
        GunsForUpgrades.Add(GunType.TripleShot, TripleShotGunTypesThirdLevel);
        GunsForUpgrades.Add(GunType.SpeedsterGun, SpeedsterGunTypesSecondLevel);
    }
}
