using UnityEngine;

public class EnemyBodyFactory
{
    public GameObject CreateBody(EnemyData enemyData, IUpgradable playerData)
    {
        GameObject enemyBody = GameObject.Instantiate(enemyData.TargetPrefab);

        SphereCollider sphereCollider = enemyBody.AddComponent<SphereCollider>();
        EntityHealth entityHealth = enemyBody.AddComponent<EntityHealth>();

        entityHealth.Init(enemyData);
        entityHealth.SetEntityType(EntityType.Enemy);

        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.5f;

        return enemyBody;
    }
}
