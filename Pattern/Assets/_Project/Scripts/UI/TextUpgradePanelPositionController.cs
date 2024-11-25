using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class TextUpgradePanelPositionController
    {
        private readonly float _countOfUpgrades;

        public TextUpgradePanelPositionController(int countOfUpgrades) =>
            _countOfUpgrades = countOfUpgrades;

        public void SetPosition(RectTransform textRectTransform, Vector3 position,
            GridLayoutGroup panelFactoryLayoutGroup, GridLayoutGroup panelLayoutGroup, int count)
        {
            float width = (panelLayoutGroup.cellSize.x * (_countOfUpgrades / 2f)
                + panelLayoutGroup.spacing.x * ((_countOfUpgrades / 2f) - 1));

            float height = position.y - (panelFactoryLayoutGroup.cellSize.y + panelFactoryLayoutGroup.spacing.y) * count;

            textRectTransform.localPosition = new Vector3(
                                                position.x + width,
                                                height,
                                                textRectTransform.localPosition.z
            );
        }
    }
}