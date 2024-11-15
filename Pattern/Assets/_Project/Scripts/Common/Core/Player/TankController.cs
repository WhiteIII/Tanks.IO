using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public sealed class TankController : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardInput _keyboardInput;
    
    private IMovable _playerData;
    private Rigidbody _rigidbody;

    [Inject] private void Construct(PlayerData playerData) =>
        _playerData = playerData;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate() =>
        _rigidbody.MovePosition(transform.position + _keyboardInput.Move * _playerData.Speed * Time.deltaTime);
}
