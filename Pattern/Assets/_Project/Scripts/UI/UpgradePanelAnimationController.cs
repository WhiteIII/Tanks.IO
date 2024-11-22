using UnityEngine;

namespace TanksIO.UI
{
    public class UpgradePanelAnimationController : MonoBehaviour
    {
        [SerializeField] private UpgradeButtonUI _upgradeButtonUI;
        [SerializeField] private PanelAnimation _panelAnimation;
        [SerializeField] private UpgradeSelection _upgradeSelection;
        [SerializeField] private float _duration;

        private void Awake()
        {
            RectTransform panelRectTransform = GetComponent<RectTransform>();

            Vector3 leangthTransformToShow = new Vector3(0f, Camera.main.scaledPixelHeight, 0f);
            Vector3 lengthTransformToHide = panelRectTransform.position;

            _panelAnimation.Init(leangthTransformToShow, lengthTransformToHide, _duration);

            _upgradeButtonUI.OnOpen += ShowPanel;
            _upgradeButtonUI.OnClose += HidePanel;

            _upgradeSelection.PlayerLevelUpgrade += ShowPanel;
            _upgradeSelection.PlayerUpgraded += HidePanel;
        }

        private void OnDestroy()
        {
            _upgradeButtonUI.OnOpen -= ShowPanel;
            _upgradeButtonUI.OnClose -= HidePanel;

            _upgradeSelection.PlayerLevelUpgrade -= ShowPanel;
            _upgradeSelection.PlayerUpgraded -= HidePanel;
        }

        private void HidePanel() =>
            _panelAnimation.HidePanel();

        private void ShowPanel() =>
            _panelAnimation.ShowPanel();
    }
}