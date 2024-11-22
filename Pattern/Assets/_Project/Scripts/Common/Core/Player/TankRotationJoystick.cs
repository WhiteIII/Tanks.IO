using UnityEngine;

namespace TanksIO.Common.Core.Player
{
    public class TankRotationJoystick : MonoBehaviour
    {
        [SerializeField] private VariableJoystick _variableJoystick;
        [SerializeField] private float _rotateSpeed;

        public Vector3 Duration { get; private set; }

        private void FixedUpdate()
        {
            float horizontal = _variableJoystick.Horizontal;
            float vertical = _variableJoystick.Vertical;

            Vector3 movement = new Vector3(horizontal, 0f, vertical);

            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
            }

            Duration = transform.rotation * Vector3.forward;
        }
    }
}