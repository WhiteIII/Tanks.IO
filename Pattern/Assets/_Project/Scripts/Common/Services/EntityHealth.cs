using System;

public class EntityHealth : Health
{    
    public override event Action HealthHasChanged;
    public override event Action<Health> Death;
    public event Action<EntityHealth> EntityDeath;
    public event Action Reborn;

    public bool CriticalValue => 
        HealthValue <= MaxHealth * _criticalValuePercent;

    private readonly float _criticalValuePercent = 0.25f;
        
    private EntityHealth _entityHealth;
    private IEntityDamagable _damagableEnemy;

    private void Awake()
    {
        _entityHealth = GetComponent<EntityHealth>();
    }

    public override void TakeDamage(int damage, ITankUpradable tankUpradable)
    {
        if (HealthValue - damage <= 0)
        {
            _alive = false;
            HealthValue = 0;
            tankUpradable.AddPoints(_damagableEnemy.Points);
            EntityDeath?.Invoke(_entityHealth);
            Death?.Invoke(_entityHealth);
        }
        else
        {
            HealthValue -= damage;
        }
        HealthHasChanged?.Invoke();
    }

    public override void TakeDamage(int damage)
    {
        if (HealthValue - damage <= 0)
        {
            _alive = false;
            HealthValue = 0;
            EntityDeath?.Invoke(_entityHealth);
            Death?.Invoke(_entityHealth);
        }
        else
        {
            HealthValue -= damage;
        }
        HealthHasChanged?.Invoke();
    }

    public void Init(IEntityDamagable damagableEnemy)
    {
        _damagableEnemy = damagableEnemy;
        MaxHealth = _damagableEnemy.Health;
        HealthValue = MaxHealth;
    }

    public void Resurrect()
    {
        _alive = true;
        HealthValue = MaxHealth;
        Reborn?.Invoke();
    }

    public void SetEntityType(EntityType entityType)
    {
        EntityType = entityType;
    }
}
