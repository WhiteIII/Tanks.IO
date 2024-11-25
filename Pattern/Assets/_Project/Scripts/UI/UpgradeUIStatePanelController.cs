using TMPro;
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
        private readonly UpgradePanelTextFactory _upgradePanelTextFactory = new();

        public void SetPanel(UpgradePanelConfig config, Color elementColor,
            Upgrades upgrade, UpgradeButtonFactory upgradeButtonFactory,
            PlayerLevelViewController playerLevelViewController, Canvas upgradePanelCanvas, 
            RectTransform panelsFactoryRectTransform, GridLayoutGroup panelsGridLayoutGroup)
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
                panelsGridLayoutGroup, GetComponent<GridLayoutGroup>(), upgradePanelCanvas.GetComponent<RectTransform>());

            _upgradePanelTextFactory.Create(upgrade, upgradePanelCanvas.GetComponent<RectTransform>());

            buttonPrefab.GetComponent<UpgradeButton>().Init(Config.CountOfUpgrades,
                upgradePanelViewController, upgrade, playerLevelViewController);
        }
    }

    public class UpgradePanelTextFactory
    {
        public void Create(Upgrades upgrades, RectTransform parent)
        {
            GameObject textObject = new($"Text {upgrades}");
            TextMeshProUGUI text = textObject.AddComponent<TextMeshProUGUI>();

            textObject.transform.SetParent(parent);

            text.alignment = TextAlignmentOptions.Center;
            text.text = upgrades.ToString();
        }
    }
}