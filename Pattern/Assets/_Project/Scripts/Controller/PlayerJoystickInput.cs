using UnityEngine;

public class PlayerJoystickInput : MonoBehaviour, IMoveableInput
{
    public bool IsActive { get; private set; } = true;
    public Vector3 Move { get; private set; } = Vector3.zero;
    
    [SerializeField] private VariableJoystick _movementJoystick;

    private void FixedUpdate() =>
        Move = Vector3.forward * _movementJoystick.Vertical + Vector3.right * _movementJoystick.Horizontal;
}

