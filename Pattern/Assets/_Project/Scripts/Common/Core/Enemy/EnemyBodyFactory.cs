using TanksIO.Common.ScriptableObjects;
using TanksIO.Common.Services;
using UnityEngine;

namespace TanksIO.Common.Core.Enemy
{
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
}