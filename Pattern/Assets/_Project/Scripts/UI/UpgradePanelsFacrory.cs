using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelsFacrory : MonoBehaviour 
{
    private RectTransform RectTransform => GetComponent<RectTransform>();
    private GridLayoutGroupUIFactory Factory => new(_panel, RectTransform);

    [SerializeField] private GameObject _panel;
    [SerializeField] private Color[] colors;

    public void Create()
    {
        if (TryGetComponent(out GridLayoutGroup _) == false)
            gameObject.AddComponent<GridLayoutGroup>();

        Factory.Create();
    }

    
}
