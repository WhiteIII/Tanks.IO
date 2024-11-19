using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIStatePanelController : MonoBehaviour
{
    private RectTransform RectTransform => GetComponent<RectTransform>();
    private GridLayoutGroupUIFactory Factory => new(Config.UIElement, RectTransform);

    [field: SerializeField] public UpgradePanelConfig Config { get; private set; }
    
    [SerializeField] private Color _elementColor;

    private readonly UIElementRepository _elementRepository = new();

    public void SetPanel(UpgradePanelConfig config, Color elementColor, Upgrades upgrade)
    {
        Config = config;
        _elementColor = elementColor;

        ImagePanelController imagePanelController;
        UpgradePanelViewController upgradePanelViewController;

        if (TryGetComponent(out GridLayoutGroup _) == false)
            gameObject.AddComponent<GridLayoutGroup>();

        imagePanelController = new ImagePanelController(
                                                    Config.UIElement.GetComponent<RectTransform>(),
                                                    gameObject.GetComponent<GridLayoutGroup>(),
                                                    Config.CountOfUpgrades);

        for (int i = 0; i < Config.CountOfUpgrades; i++)
        {
            GameObject uIElementClone = Factory.Create();
            uIElementClone.GetComponent<Image>().color = _elementColor;
            _elementRepository.Register(uIElementClone);
        }

        upgradePanelViewController = new UpgradePanelViewController(_elementRepository);

        Config.UpgradeButton.GetComponent<UpgradeButton>().Init(Config.CountOfUpgrades, upgradePanelViewController, upgrade);
        imagePanelController.DrawPanel();
    }
}
