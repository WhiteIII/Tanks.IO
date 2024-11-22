using System;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradeButtonController
    {
        public event Action OnUpgrade;

        public bool IsActive { get; private set; } = true;

        readonly private Button _button;
        readonly private int _maxCountOfUpgrades;

        private int _countOfUpgrades = 0;

        public UpgradeButtonController(Button button, int maxCountOfUpgrades)
        {
            _button = button;
            _maxCountOfUpgrades = maxCountOfUpgrades;

            _button.onClick.AddListener(Upgrade);
            BlockUpgrade();
        }

        private void Upgrade()
        {
            OnUpgrade?.Invoke();
            _countOfUpgrades++;

            if (_countOfUpgrades == _maxCountOfUpgrades)
                DeactivateButton();
        }

        private void DeactivateButton()
        {
            BlockUpgrade();
            IsActive = false;
            _button.onClick.RemoveListener(Upgrade);
        }

        public void BlockUpgrade() =>
            _button.enabled = false && IsActive;

        public void AllowUpgrade() =>
            _button.enabled = true && IsActive;

        public void OnDestroy() =>
            _button.onClick.RemoveListener(Upgrade);
    }
}