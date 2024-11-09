using UnityEngine;

[CreateAssetMenu(fileName = "Game", menuName = "Game/Target")]
public class TargetData : EntityData, IEntityDamagable
{
    [field: SerializeField] public GameObject TargetPrefab {  get; private set; }
    [field: SerializeField] public int Points { get; private set; }
}
