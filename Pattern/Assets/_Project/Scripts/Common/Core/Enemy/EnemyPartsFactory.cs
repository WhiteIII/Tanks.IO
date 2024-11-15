using UnityEngine;
using Zenject;

public class EnemyPartsFactory
{
    public GameObject CreateBody(EnemyData enemyData, DiContainer diContainer)
    {
        GameObject enemyBody = diContainer.InstantiatePrefab(enemyData.TargetPrefab);

        return enemyBody;
    }

    public GameObject CreatePlayerArea(EntityHealth entityHealth)
    {
        var playerArea = new GameObject("PlayerArea");

        SphereCollider sphereCollider = playerArea.AddComponent<SphereCollider>();

        playerArea.AddComponent<EnemyAttackArea>().Init(entityHealth);

        sphereCollider.isTrigger = true;
        sphereCollider.radius = 16f;

        return playerArea;
    }

    public GameObject CreateAttackArea()
    {
        var enemyAttackArea = new GameObject("AttackArea");

        BoxCollider boxCollider = enemyAttackArea.AddComponent<BoxCollider>();
        enemyAttackArea.AddComponent<EnemyEvasion>();

        boxCollider.isTrigger = true;
        boxCollider.size = new Vector3(2f, 2f, 2f);

        return enemyAttackArea;
    }

    public void BuildTheObject(GameObject currentGameObject, GameObject body, GameObject playerArea, GameObject attackArea)
    {
        body.transform.SetParent(currentGameObject.transform);
        body.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        playerArea.transform.SetParent(currentGameObject.transform);
        playerArea.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        attackArea.transform.SetParent(currentGameObject.transform);
        attackArea.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
}
