using TanksIO.Common.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace TanksIO.Common.Core.Player
{
    public class TankControllerJoystick : MonoBehaviour
    {
        [SerializeField] private VariableJoystick _variableJoystick;

        [Inject] private PlayerData _playerData;

        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            Vector3 move = Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;

            _rigidbody.MovePosition(transform.position + move * _playerData.Speed * Time.deltaTime);
        }
    }
}