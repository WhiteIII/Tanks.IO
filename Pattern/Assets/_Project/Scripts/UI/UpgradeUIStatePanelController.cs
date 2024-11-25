using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradeUIStatePanelController : MonoBehaviour
    {
        private RectTransform RectTransform => GetComponent<RectTransform>();
        private GridLayoutGroupUIFactory Factory => new(Config.UIElement, RectTransform);

        public UpgradePanelConfig Config { get; private set; }

        private readonly UIElementRepository _elementRepository = new();

        public void SetPanel(UpgradePanelConfig config, Color elementColor,
            Upgrades upgrade, UpgradeButtonFactory upgradeButtonFactory,
            UpgradePanelTextFactory upgradePanelTextFactory,
            PlayerLevelViewController playerLevelViewController, 
            RectTransform panelsFactoryRectTransform, GridLayoutGroup panelsGridLayoutGroup,
            UpgradePanelRepository upgradePanelRepository)
        {
            Config = config;

            GameObject buttonPrefab;
            UpgradePanelViewController upgradePanelViewController;

            if (TryGetComponent(out GridLayoutGroup _) == false)
                gameObject.AddComponent<GridLayoutGroup>();

            for (int i = 0; i < Config.CountOfUpgrades; i++)
            {
                GameObject uIElementClone = Factory.Create();
                uIElementClone.GetComponent<Image>().color = elementColor;
                _elementRepository.Register(uIElementClone);
            }

            upgradePanelViewController = new UpgradePanelViewController(_elementRepository);

            buttonPrefab = upgradeButtonFactory.Create(panelsFactoryRectTransform.localPosition,
                panelsGridLayoutGroup, GetComponent<GridLayoutGroup>(), 
                upgradePanelRepository);

            upgradePanelTextFactory.Create(upgrade, 
                panelsFactoryRectTransform.localPosition, panelsGridLayoutGroup, GetComponent<GridLayoutGroup>(), 
                upgradePanelRepository);

            buttonPrefab.GetComponent<UpgradeButton>().Init(Config.CountOfUpgrades,
                upgradePanelViewController, upgrade, playerLevelViewController);
        }
    }
}