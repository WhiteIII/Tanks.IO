using System;

public interface IPlayerDamagable : IDamagable
{
    public event Action LevelChange;

    public void ResetThePoints();
}
