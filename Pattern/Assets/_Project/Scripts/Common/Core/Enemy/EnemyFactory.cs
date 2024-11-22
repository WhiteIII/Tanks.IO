using TanksIO.Common.Core.Guns;
using TanksIO.Common.Core.Player;
using TanksIO.Common.ScriptableObjects;
using TanksIO.Common.Services;
using TanksIO.UI;
using UnityEngine;
using Zenject;

namespace TanksIO.Common.Core.Enemy
{
    public class EnemyFactory : IEntityFactory
    {
        private EnemyData _enemyData;
        private GlobalBulletObjectPool _bulletObjectPool;
        private DiContainer _diContainer;
        private GameRules _gameRules;

        public EnemyFactory(EnemyData emenmyData, DiContainer diContainer, GlobalBulletObjectPool bulletObjectPool, GameRules gameRules)
        {
            _enemyData = emenmyData;
            _diContainer = diContainer;
            _bulletObjectPool = bulletObjectPool;
            _gameRules = gameRules;
        }

        public GameObject CreateTarget(TargetData targetData, IUpgradable playerData, UIElementsListData uIElementsListData)
        {
            var enemyGameObject = new GameObject("Enemy");

            EnemySetTarget enemySetTarget;
            EnemyUpgrader enemyUpgrader;
            EntityHealthBarFactory entityHealthBarFactory = new EntityHealthBarFactory();
            EnemyPartsFactory enemyPartsFactory = new EnemyPartsFactory();
            RigidbodyFacroty rigidbodyFacroty = new RigidbodyFacroty();
            EnemyStatsInRunTime enemyStatsInRunTime = new EnemyStatsInRunTime(_enemyData, _gameRules);

            EntityHealth entityHealth = enemyGameObject.AddComponent<EntityHealth>();

            entityHealth.Init(enemyStatsInRunTime);
            entityHealth.SetEntityType(EntityType.Enemy);

            GameObject enemyBody = enemyPartsFactory.CreateBody(_enemyData, _diContainer);
            GameObject playerArea = enemyPartsFactory.CreatePlayerArea(entityHealth);
            GameObject enemyAttackArea = enemyPartsFactory.CreateAttackArea();

            Rigidbody rigidbody = enemyGameObject.AddComponent<Rigidbody>();
            EnemyMovement enemyMovement = enemyGameObject.AddComponent<EnemyMovement>();
            enemyGameObject.AddComponent<TargetMovement>();

            rigidbodyFacroty.RigidbodyConfigure(rigidbody, 10f);

            enemySetTarget = new EnemySetTarget(playerArea.GetComponent<EnemyAttackArea>(), enemyGameObject.transform);

            enemyGameObject.AddComponent<LookedOnTarget>().Init(enemySetTarget);

            SphereCollider sphereCollider = enemyGameObject.AddComponent<SphereCollider>();

            sphereCollider.isTrigger = true;
            sphereCollider.radius = 0.5f;

            enemyMovement.Init(playerArea.GetComponent<EnemyAttackArea>(), enemyGameObject.GetComponent<LookedOnTarget>(), rigidbody,
                enemyAttackArea.GetComponent<EnemyEvasion>(), enemyGameObject.GetComponent<Health>(), enemyStatsInRunTime);
            enemyBody.GetComponent<EnemyShootTheGun>().Init(playerArea.GetComponent<EnemyAttackArea>(), enemyStatsInRunTime, rigidbody, enemyMovement, entityHealth, _bulletObjectPool);
            enemyGameObject.AddComponent<EnemyCanvasAnimation>();
            enemyUpgrader = new EnemyUpgrader(enemyStatsInRunTime, entityHealth, playerData);

            entityHealthBarFactory.CreateCanvasForTarget(enemyGameObject, enemyGameObject.GetComponent<EntityHealth>(), uIElementsListData, enemyGameObject.GetComponent<EnemyCanvasAnimation>());

            enemyPartsFactory.BuildTheObject(enemyGameObject, enemyBody, playerArea, enemyAttackArea);

            return enemyGameObject;
        }
    }
}