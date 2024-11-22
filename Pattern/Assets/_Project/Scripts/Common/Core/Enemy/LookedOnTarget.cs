using UnityEngine;

namespace TanksIO.Common.Core.Enemy
{
    public class LookedOnTarget : MonoBehaviour
    {
        private EnemySetTarget _setTarget;

        private void Update()
        {
            if (_setTarget.TargetTransform != null)
            {
                transform.LookAt(_setTarget.TargetTransform);
                transform.rotation = new Quaternion(0f, transform.rotation.y,
                    0f, transform.rotation.w);
            }
        }

        public void Init(EnemySetTarget enemySetTarget)
        {
            _setTarget = enemySetTarget;
        }
    }
}