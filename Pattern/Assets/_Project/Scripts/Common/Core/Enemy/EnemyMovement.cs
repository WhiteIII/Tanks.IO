using TanksIO.Common.Services;
using UnityEngine;

namespace TanksIO.Common.Core.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyAttackArea _area;
        [SerializeField] private LookedOnTarget _lookedOnTarget;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private EnemyEvasion _enemyEvasion;
        [SerializeField] private IEntityHealthValue _health;
        [SerializeField] private float _distance = 8f;

        private IMovable _enemyData;

        private EnemySetTarget _setTarget;

        public bool IsMoving { get; private set; } = false;

        public void Init(EnemyAttackArea enemyAttackArea, LookedOnTarget lookedOnTarget, 
            Rigidbody rigidbody, EnemyEvasion enemyEvasion, IEntityHealthValue targetHealth, IMovable enemyData)
        {
            _area = enemyAttackArea;
            _lookedOnTarget = lookedOnTarget;
            _rigidbody = rigidbody;
            _enemyEvasion = enemyEvasion;
            _health = targetHealth;
            _enemyData = enemyData;

            _setTarget = new EnemySetTarget(_area, transform);
            _lookedOnTarget.Init(_setTarget);
        }

        private void FixedUpdate()
        {
            if (_setTarget.TargetTransform == null)
            {
                IsMoving = false;
                return;
            }

            if (Vector3.Distance(transform.position, _setTarget.TargetTransform.position) < _distance && Vector3.Distance(transform.position, _setTarget.TargetTransform.position) > _distance * 0.25f)
            {
                IsMoving = false;
                return;
            }

            IsMoving = true;
            Vector3 direction = (_setTarget.TargetTransform.position - transform.position).normalized;

            if ((Vector3.Distance(transform.position, _setTarget.TargetTransform.position) < _distance * 0.25f || _health.HealthValue < (float)_health.MaxHealth * 0.3f)
                && (_area.EnemyTransformList.Count > 0 || _area.PlayerTransform != null))
            {
                direction = -direction;
            }

            if (_enemyEvasion.TargetTransforms.Count > 0)
            {
                _rigidbody.MovePosition(transform.position + (_enemyEvasion.GetDuration() + direction).normalized * _enemyData.Speed * Time.deltaTime);
                return;
            }

            if (_area.EnemyTransformList.Count == 0 || _area.TargetTransformList.Count == 0 || _area.PlayerTransform == null)
            {
                _rigidbody.MovePosition(transform.position + (new Vector3(0f, 0.58f, 0f) - transform.position).normalized * _enemyData.Speed * Time.deltaTime);
            }

            _rigidbody.MovePosition(transform.position + direction * _enemyData.Speed * Time.deltaTime);
        }
    }
}