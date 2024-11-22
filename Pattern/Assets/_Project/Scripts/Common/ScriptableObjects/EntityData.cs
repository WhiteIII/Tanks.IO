using UnityEngine;

namespace TanksIO.Common.ScriptableObjects
{
    public class EntityData : ScriptableObject, IDamagable, IBodyAttackable
    {
        [field: SerializeField] public int Health { get; protected set; }
        [field: SerializeField] public int BodyDamage { get; protected set; }
    }
}