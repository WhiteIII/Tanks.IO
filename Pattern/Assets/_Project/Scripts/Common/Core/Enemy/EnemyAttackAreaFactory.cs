using UnityEngine;

public class EnemyAttackAreaFactory
{
    public GameObject CreateAttackArea()
    {
        var enemyAttackArea = new GameObject("AttackArea");

        BoxCollider boxCollider = enemyAttackArea.AddComponent<BoxCollider>();
        enemyAttackArea.AddComponent<EnemyEvasion>();
        
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector3(2f, 2f, 2f);

        return enemyAttackArea;
    }
}
