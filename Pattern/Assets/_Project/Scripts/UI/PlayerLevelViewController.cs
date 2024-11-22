using UnityEngine;

namespace TanksIO.UI
{
    public class PlayerLevelViewController : MonoBehaviour
    {
        [SerializeField] private PlayerLevelView _playerLevelView;

        private UpgradeButtonModel _model;

        public void Init(UpgradeButtonModel upgradeButtonModel)
        {
            _model = upgradeButtonModel;
            _model.PlayerLevelChanged += ChangeView;
        }

        private void ChangeView(bool isActive) =>
            _playerLevelView.Draw(_model.NumberOfUpgrades.ToString());
    }
}