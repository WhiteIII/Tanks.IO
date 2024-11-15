using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour, IMoveableInput
{
    public bool IsActive { get; private set; } = true;
    public Vector3 Move { get; private set; } = Vector3.zero;

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Move = transform.right * x + transform.forward * z;
    }
}

