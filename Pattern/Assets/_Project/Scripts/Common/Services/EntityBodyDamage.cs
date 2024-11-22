using TanksIO.Common.Core.Player;
using UnityEngine;

namespace TanksIO.Common.Services
{
    public class EntityBodyDamage : MonoBehaviour
    {
        private IBodyAttackable _entityData;

        public void Init(IBodyAttackable entityData)
        {
            _entityData = entityData;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(_entityData.BodyDamage);
            }
        }
    }
}