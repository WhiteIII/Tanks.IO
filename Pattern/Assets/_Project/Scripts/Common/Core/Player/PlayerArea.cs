using TanksIO.Common.Core.Target;
using UnityEngine;

namespace TanksIO.Common.Core.Player
{
    public class PlayerArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TargetAnimation targetAnimation))
            {
                targetAnimation.StartAnimation();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out TargetAnimation targetAnimation))
            {
                targetAnimation.StopAnimation();
            }
        }
    }
}