namespace TanksIO.UI
{
    public class UpgradeButtonViewController
    {
        private readonly UpgradeButtonView _upgradeButtonView;

        public UpgradeButtonViewController(UpgradeButtonView upgradeButtonView)
        {
            _upgradeButtonView = upgradeButtonView;
        }

        public void ActivateButton() =>
            _upgradeButtonView.ActivateButton();

        public void DeactivateButton() =>
            _upgradeButtonView.DeactivateButton();
    }
}