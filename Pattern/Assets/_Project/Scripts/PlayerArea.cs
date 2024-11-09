using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TargetAnimation>(out TargetAnimation targetAnimation))
        {
            targetAnimation.StartAnimation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<TargetAnimation>(out TargetAnimation targetAnimation))
        {
            targetAnimation.StopAnimation();
        }
    }
}
