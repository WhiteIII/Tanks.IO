using System.Collections.Generic;
using TanksIO.Common.Core.Player;
using UnityEngine;

namespace TanksIO.Common.Core.Enemy
{
    public class EnemyEvasion : MonoBehaviour
    {
        public List<Transform> TargetTransforms { get; private set; } = new List<Transform>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TargetMovement targetMovement))
            {
                TargetTransforms.Add(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out TargetMovement targetMovement))
            {
                TargetTransforms.Remove(other.transform);
            }
        }

        public Vector3 GetDuration()
        {
            Vector3 currentTargetPostion = TargetTransforms[0].position;

            foreach (Transform targetTransform in TargetTransforms)
            {
                if (Vector3.Distance(currentTargetPostion, transform.position)
                        > Vector3.Distance(transform.position, targetTransform.position))
                {
                    currentTargetPostion = targetTransform.position;
                }
            }

            Vector3 duration = -(currentTargetPostion - transform.position).normalized;

            return duration;
        }

        public Vector3 GetDuration(Vector3 targetPosition)
        {
            Vector3 duration = (targetPosition - transform.position).normalized;
            return duration;
        }
    }
}