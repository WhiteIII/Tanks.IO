using System;
using UnityEngine;
using Zenject;

public class TankBodyDamage : MonoBehaviour
{
    private IAttackable _playerData;

    public event Action Collide;

    [Inject] private void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EntityHealth>(out EntityHealth entityHealth))
        {
            entityHealth.TakeDamage(_playerData.BodyDamage);
            other.GetComponent<TargetMovement>().Push(transform.position.normalized * 2f);
            Collide?.Invoke();
        }
    }
}
