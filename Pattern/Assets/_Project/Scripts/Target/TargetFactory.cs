using UnityEngine;

public class TargetFactory : IEntityFactory
{      
    public GameObject CreateTarget(TargetData targetData, IUpgradable playerData, UIElementsListData uIElementsListData)
    {
        Rigidbody rigidbody;
        EntityHealth entityHealth;
        EntityHealthBarFactory entityHealthBarFactory = new EntityHealthBarFactory();
        RigidbodyFacroty rigidbodyFacroty = new RigidbodyFacroty();
        var targetGameObject = GameObject.Instantiate(targetData.TargetPrefab);

        entityHealth = targetGameObject.AddComponent<EntityHealth>();
        targetGameObject.AddComponent<TargetAnimation>();
        rigidbody = targetGameObject.AddComponent<Rigidbody>();
        targetGameObject.AddComponent<TargetMovement>();
        targetGameObject.AddComponent<EntityBodyDamage>().Init(targetData);

        entityHealth.Init(targetData);
        entityHealth.SetEntityType(EntityType.Target);

        rigidbodyFacroty.RigidbodyConfigure(rigidbody, 3f);

        entityHealthBarFactory.CreateCanvasForTarget(targetGameObject, entityHealth, uIElementsListData, targetGameObject.GetComponent<TargetAnimation>());

        return targetGameObject;
    }
}
