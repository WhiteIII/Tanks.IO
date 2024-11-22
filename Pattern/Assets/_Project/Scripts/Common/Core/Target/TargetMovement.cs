using UnityEngine;

namespace TanksIO.Common.Core.Player
{
    public class TargetMovement : MonoBehaviour
    {
        [SerializeField] protected Rigidbody Rigidbody;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public void Push(Vector3 duration)
        {
            Rigidbody.AddForce(duration * 100f);
        }
    }
}