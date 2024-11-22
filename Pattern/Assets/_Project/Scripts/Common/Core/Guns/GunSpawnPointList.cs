using UnityEngine;

namespace TanksIO.Common.Core.Guns
{
    public class GunSpawnPointList : MonoBehaviour
    {
        [field: SerializeField] public Transform[] SpawnPointList { get; private set; }

        [field: SerializeField] public float[] SpawnPointKickbacksScale { get; private set; }

        [field: SerializeField] public float[] SpawnPointDamageScale { get; private set; }

        [field: SerializeField] public float[] SpawnPointSizeScale { get; private set; }
    }
}