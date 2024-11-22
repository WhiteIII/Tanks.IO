using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Vector3;
using TanksIO.Common.Core.Enemy;
using UnityEngine.Assertions;

using TanksIO.Common.Services;

public class RuleBasedAiActor : IAiActor
{
    private readonly IRule[] _rules;
    
    public RuleBasedAiActor (params IRule[] rules) =>
        _rules = rules;

    public void Update()
    {
        foreach (IRule rule in _rules)
        {
            if (rule.CanExacute)
            {
                rule.Execute();
                return;
            }
        }
    }
}

public class AiController : MonoBehaviour
{   
    private void FixedUpdate()
    {

    }
}

public class ActorsRepository
{
    public IEnumerable<IAiActor> All => _actors;

    private readonly List<IAiActor> _actors = new();

    public void Register(IAiActor aiActor) =>
        _actors.Add(aiActor);

    public void Unregister(IAiActor aiActor) =>
        _actors.Remove(aiActor);
}

public class AiAgentRepository
{
    private readonly List<AiAgent> _characters = new();

    public AiAgent GetClosestEnemy(AiAgent forCharacter)
    {
        float closestSqrDistance = float.MaxValue;
        AiAgent closestEnemy = null;

        foreach (AiAgent character in _characters)
        {
            float sqrDistance = Vector3.SqrMagnitude(forCharacter.Position - character.Position);

            if (sqrDistance < closestSqrDistance)
            {
                closestSqrDistance = sqrDistance;
                closestEnemy = character;
            }
        }

        Assert.IsNotNull(closestEnemy);

        return closestEnemy;
    }

    public void Register(AiAgent character) =>
        _characters.Add(character);

    public void Unregister(AiAgent character) =>
        _characters.Remove(character);
}

public class AiAgent : MonoBehaviour
{
    public bool HasEnemy => _enemy is { IsAlive: true };
    public bool CloseEnougthToAttack =>
        SqrMagnitude(Position - _enemy.Position) <= Pow(_enemyShootTheGun.AttackDistance, 2f);
    public bool InAttackCoolDown => _enemyShootTheGun.CoolDown;
    public bool IsAlive => _health.Alive;
    public bool HealthCriticalValue => _health.CriticalValue;
    public Vector3 Position => transform.position;

    [SerializeField] private EnemyShootTheGun _enemyShootTheGun;
    [SerializeField] private EntityHealth _health;
    
    private IEnemyMovement _enemyMovement;
    private AiAgent _enemy;

    private void Awake()
    {
        _enemyMovement = GetComponent<IEnemyMovement>();
    }

    public void Shoot() =>
        _enemyShootTheGun.Shoot();

    public void MoveToEnemy() =>
        _enemyMovement.MoveTo(_enemy.Position);
    public void MoveAwayFromEnemy() =>
        _enemyMovement.MoveAway(_enemy.Position);

    public void AssignEnemy(AiAgent enemy) =>
        _enemy = enemy;
}
