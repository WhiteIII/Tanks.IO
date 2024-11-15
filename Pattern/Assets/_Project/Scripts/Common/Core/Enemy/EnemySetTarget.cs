using UnityEngine;

public class EnemySetTarget
{
    private EnemyAttackArea _area;
    private Transform _enemyTransform;

    public Transform TargetTransform { get; private set; }

    public EnemySetTarget(EnemyAttackArea area, Transform enemyTransform)
    {
        _area = area;
        _enemyTransform = enemyTransform;

        _area.OnTriggerEntered += SelectAGoal;
        _area.OnTriggerExited += SelectAGoal;
    }

    private void SelectAGoal()
    {
        if (_area.TargetTransformList.Contains(TargetTransform) || _area.EnemyTransformList.Contains(TargetTransform))
        {
            return;
        }
        
        if (_area.PlayerTransform != null)
        {
            TargetTransform = _area.PlayerTransform;
            return;
        }

        if (_area.EnemyTransformList.Count > 0)
        {
            TargetTransform = _area.EnemyTransformList[0].transform;

            foreach (var enemy in _area.EnemyTransformList)
            {
                if (Vector3.Distance(_enemyTransform.position, TargetTransform.position)
                    > Vector3.Distance(_enemyTransform.position, enemy.transform.position))
                {
                    TargetTransform = enemy.transform;
                }
            }
            return;
        }

        foreach (var enemy in _area.TargetTransformList)
        {
            TargetTransform = _area.TargetTransformList[0].transform;

            if (Vector3.Distance(_enemyTransform.position, TargetTransform.position)
                > Vector3.Distance(_enemyTransform.position, enemy.transform.position))
            {
                TargetTransform = enemy.transform;
            }
        }
    }
}
