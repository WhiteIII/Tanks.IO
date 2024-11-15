using UnityEngine;

public class EnemyPlayerAreaFactory
{
    public GameObject CreatePlayerArea()
    {
        var playerArea = new GameObject("PlayerArea");

        SphereCollider sphereCollider = playerArea.AddComponent<SphereCollider>();

        playerArea.AddComponent<EnemyAttackArea>();

        sphereCollider.isTrigger = true;
        sphereCollider.radius = 16f;

        return playerArea;
    }
}
