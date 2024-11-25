using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradePanelsFactory : MonoBehaviour
    {
        private PlayerLevelViewPositionController PlayerLevelViewPositionController => new(
                                                            _playerLevelViewController.GetComponent<RectTransform>(),
                                                            GetComponent<GridLayoutGroup>(),
                                                            (int)Upgrades.BulletPenetration + 1);
        private RectTransform RectTransform => GetComponent<RectTransform>();
        private GridLayoutGroup GridLayoutGroup => GetComponent<GridLayoutGroup>();
        private GridLayoutGroupUIFactory Factory => new(_panel, RectTransform);

        [SerializeField] private GameObject _panel;
        [SerializeField] private PlayerLevelViewController _playerLevelViewController;
        [SerializeField] private UpgradeColorConfig[] _colors;

        public void Create(UpgradePanelConfig upgradePanelConfig,
            UpgradeButtonFactory upgradeButtonFactory, Canvas upgradePanelCanvas)
        {
            for (int i = 0; i < (int)Upgrades.BulletPenetration + 1; i++)
            {
                GameObject panelObject = Factory.Create();
                panelObject.GetComponentInChildren<UpgradeUIStatePanelController>().
                    SetPanel(upgradePanelConfig, _colors[i].Color, _colors[i].Upgrades, upgradeButtonFactory,
                    _playerLevelViewController, upgradePanelCanvas, RectTransform, GridLayoutGroup);
                ImagePanelController.DrawPanelWhthParameters(
                                                        panelObject.GetComponentInChildren<GridLayoutGroup>(),
                                                        GridLayoutGroup,
                                                        upgradePanelConfig.CountOfUpgrades);
            }

            PlayerLevelViewPositionController.SetPosition();
        }
    }
}