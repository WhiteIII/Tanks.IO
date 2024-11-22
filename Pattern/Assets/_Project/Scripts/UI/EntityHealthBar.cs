using TanksIO.Common.Services;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class EntityHealthBar : HealthBar
    {
        protected override void ChangeBar()
        {
            _healthBar.fillAmount = (float)_health.HealthValue / _health.MaxHealth;
        }

        public void Init(Health health, Image healthBar)
        {
            _health = health;
            _healthBar = healthBar;
        }
    }
}