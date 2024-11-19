using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelsFactory : MonoBehaviour 
{
    private RectTransform RectTransform => GetComponent<RectTransform>();
    private GridLayoutGroupUIFactory Factory => new(_panel, RectTransform);

    [SerializeField] private GameObject _panel;
    [SerializeField] private UpgradeColorConfig[] _colors;

    private void Awake()
    {
        if (TryGetComponent(out GridLayoutGroup _) == false)
            gameObject.AddComponent<GridLayoutGroup>();
    }

    public void Create()
    {
        for (int i = 0; i < (int)Upgrades.BulletPenetration; i++)
        {
            GameObject panelObject = Factory.Create();

        }
    }
}
