using System;
using Zenject;
using TanksIO.Common.Services;
using TanksIO.Common.ScriptableObjects;

namespace TanksIO.Common.Core.Player
{
    public class PlayerHealth : Health
    {
        private Health _health;
        private IPlayerDamagable _playerData;

        public override event Action<Health> Death;
        public override event Action HealthHasChanged;

        [Inject]
        private void Construct(PlayerData playerData)
        {
            _playerData = playerData;
        }

        private void Awake()
        {
            EntityType = EntityType.Player;

            _playerData.LevelChange += ChangeCurrentHealthCount;

            SetHealth();

            _health = GetComponent<Health>();
        }

        private void OnDestroy()
        {
            _playerData.LevelChange -= ChangeCurrentHealthCount;
        }

        private void ChangeCurrentHealthCount()
        {
            SetHealth();
            HealthHasChanged?.Invoke();
        }

        private void SetHealth()
        {
            MaxHealth = _playerData.Health;
            HealthValue = MaxHealth;
        }

        public override void TakeDamage(int damage, ITankUpradable tankUpradable)
        {
            if (HealthValue - damage <= 0)
            {
                _alive = false;
                HealthValue = 0;
                Death?.Invoke(_health);
                tankUpradable.ResetThePoints();
                gameObject.SetActive(false);
            }
            else
            {
                HealthValue -= damage;
            }
            HealthHasChanged?.Invoke();
        }

        public override void TakeDamage(int damage)
        {
            if (HealthValue - damage <= 0)
            {
                _alive = false;
                HealthValue = 0;
                Death?.Invoke(_health);
            }
            else
            {
                HealthValue -= damage;
            }
            HealthHasChanged?.Invoke();
        }
    }
}