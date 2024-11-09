using System;

public interface IEntityHealthInteractional
{
    public event Action<Health> Death;

    public void TakeDamage(int Damage, ITankUpradable tankUpradable);
}
