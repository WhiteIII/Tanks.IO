using System;

public interface IGunUpgradable
{
    public event Action<GunType> GunChanging;

    public void ChangeGun(GunType gunType);
}
