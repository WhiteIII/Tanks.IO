using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Game/Gun")]
public class GunData : ScriptableObject
{
    [field: SerializeField] public GunSpawnPointList SpawnPoints { get; private set; }
    [field: SerializeField] public GameObject GunPrefab { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }
    [field: SerializeField] public GunType GunType { get; private set; }
    [field: SerializeField] public float ReloadScale { get; private set; }
    [field: SerializeField] public float BulletTimeLife { get; private set; }
}
