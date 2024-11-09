using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public sealed class TankController : MonoBehaviour
{
    private IMovable _playerData;
    private Rigidbody _rigidbody;

    [Inject] private void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _rigidbody.MovePosition(transform.position + move * _playerData.Speed * Time.deltaTime);
    }
}
