using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GunsScriptsList
{
    private GunDoubleShot _gunDoubleShot;
    private GunSniper _gunSniper;
    private GunSpeedster _gunSpeedster;

    private readonly GunType _gun;
    
    private List<Gun> _guns = new List<Gun>();

    public Gun CurrentGun { get; private set; }

    public GunsScriptsList() 
    {
        _guns.Add(_gunDoubleShot);
        _guns.Add(_gunSniper);
        _guns.Add(_gunSpeedster);
    }

    public void ChangeGun(GunType gunType, GameObject bullet, GunSpawnPointList gunSpawnPointList, int poolMaxSize, DiContainer diContainer)
    {
        
    }
}
