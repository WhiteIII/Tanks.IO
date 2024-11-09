using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttackArea : MonoBehaviour
{
    public List<Transform> TargetTransformList { get; private set; } = new List<Transform>();
    public List<Transform> EnemyTransformList { get; private set; } = new List<Transform>();
    public Transform PlayerTransform { get; private set; }

    public event Action OnTriggerEntered;
    public event Action OnTriggerExited;

    private EntityHealth _entityHealth;

    public void Init(EntityHealth entityHealth)
    {
        _entityHealth = entityHealth;
        _entityHealth.Reborn += ResetArea;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health enemy))
        {
            AddEntity(enemy);
            
            enemy.Death += RemoveEnemy;

            OnTriggerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health enemy))
        {
            RemoveEntity(enemy);
            
            enemy.Death -= RemoveEnemy;

            OnTriggerExited?.Invoke();
        }
    }

    private void OnDestroy()
    {
        _entityHealth.Reborn -= ResetArea;
    }

    private void RemoveEnemy(Health enemyHealth)
    {
        enemyHealth.Death -= RemoveEnemy;

        RemoveEntity(enemyHealth);

        OnTriggerExited?.Invoke();
    }

    private void AddEntity(Health entityHealth)
    {
        if (entityHealth.EntityType == EntityType.Target)
        {
            TargetTransformList.Add(entityHealth.transform);
        }

        else if (entityHealth.EntityType == EntityType.Player)
        {
            PlayerTransform = entityHealth.transform;
        }

        else
        {
            EnemyTransformList.Add(entityHealth.transform);
        }
    }

    private void RemoveEntity(Health entityHealth)
    {
        
        if (entityHealth.EntityType == EntityType.Target)
        {
            TargetTransformList.Remove(entityHealth.transform);
        }

        else if (entityHealth.EntityType == EntityType.Player)
        {
            PlayerTransform = null;
        }

        else
        {
            EnemyTransformList.Remove(entityHealth.transform);
        }
    }

    private void ResetArea()
    {
        PlayerTransform = null;
        TargetTransformList.Clear();
        EnemyTransformList.Clear();
    }
}
