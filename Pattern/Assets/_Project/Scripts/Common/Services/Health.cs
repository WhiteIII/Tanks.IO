using UnityEngine;
using System;

public abstract class Health : MonoBehaviour, IEntityHealth
{    
    public virtual event Action HealthHasChanged;
    public virtual event Action<Health> Death;
    
    public int MaxHealth { get; protected set; }
    public int HealthValue { get; protected set; }
    public EntityType EntityType { get; protected set; }
    
    protected bool _alive = true;

    public bool Alive => _alive;

    public abstract void TakeDamage(int damage, ITankUpradable tankUpradable);
    public abstract void TakeDamage(int damage);
}
