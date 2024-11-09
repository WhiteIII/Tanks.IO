using UnityEngine;
using DG.Tweening;

public class UpgradePanelAnimation : MonoBehaviour
{
    [SerializeField] private UpgradeSelection _upgradeSelection;

    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        
        _upgradeSelection.PlayerLevelUpgrade += ShowPanel;
        _upgradeSelection.PlayerUpgraded += HidePanel;
    }

    private void OnDestroy()
    {
        _upgradeSelection.PlayerLevelUpgrade -= ShowPanel;
        _upgradeSelection.PlayerUpgraded -= HidePanel;
    }

    public void ShowPanel()
    {
        _transform.DOMove(new Vector3(0f, 1080f, 0f), 0.8f, true);
    }

    public void HidePanel()
    {
        _transform.DOMove(new Vector3(0f, 1440f, 0f), 0.8f, true);
    }
}
