using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using static UnityEngine.Vector3;

public class NavMeshMovemnt : MonoBehaviour, IEnemyMovement
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _updatePathCooldown;
    [SerializeField] private float _currentCooldown;

    private bool InCooldown => _currentCooldown > .1f;

    private void Update() =>
        _currentCooldown = Max(_currentCooldown - Time.deltaTime, 0f);

    public void MoveAway(Vector3 target)
    {
        if (_navMeshAgent.destination == target || InCooldown)
            return;

        _navMeshAgent.SetDestination(target);
        _currentCooldown = _updatePathCooldown;
    }

    public void MoveTo(Vector3 target)
    {
        if (_navMeshAgent.destination == target || InCooldown)
            return;

        _navMeshAgent.SetDestination(-target);
        _currentCooldown = _updatePathCooldown;
    }
}
