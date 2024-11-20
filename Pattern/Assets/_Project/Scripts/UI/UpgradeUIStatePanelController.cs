using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIStatePanelController : MonoBehaviour
{
    
    private RectTransform RectTransform => GetComponent<RectTransform>();
    private GridLayoutGroupUIFactory Factory => new(Config.UIElement, RectTransform);

    public UpgradePanelConfig Config { get; private set; }

    [SerializeField] private RectTransform _panelViewTransform;
    
    private readonly UIElementRepository _elementRepository = new();

    private Color _elementColor;

    public void SetPanel(UpgradePanelConfig config, Color elementColor, 
        Upgrades upgrade, UpgradeButtonFactory upgradeButtonFactory)
    {
        Config = config;
        _elementColor = elementColor;

        GameObject buttonPrefab;
        ImagePanelController imagePanelController;
        UpgradePanelViewController upgradePanelViewController;

        if (TryGetComponent(out GridLayoutGroup _) == false)
            gameObject.AddComponent<GridLayoutGroup>();

        imagePanelController = new ImagePanelController(
                                                    _panelViewTransform,
                                                    gameObject.GetComponent<GridLayoutGroup>(),
                                                    Config.CountOfUpgrades);

        for (int i = 0; i < Config.CountOfUpgrades; i++)
        {
            GameObject uIElementClone = Factory.Create();
            uIElementClone.GetComponent<Image>().color = _elementColor;
            _elementRepository.Register(uIElementClone);
        }

        upgradePanelViewController = new UpgradePanelViewController(_elementRepository);

        buttonPrefab = upgradeButtonFactory.Create(RectTransform);

        buttonPrefab.GetComponent<UpgradeButton>().Init(Config.CountOfUpgrades, upgradePanelViewController, upgrade);
        imagePanelController.DrawPanel();
    }
}
