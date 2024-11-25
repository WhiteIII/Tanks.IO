using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradeButtonPositionController
    {
        private readonly int _countOfUpgrades;

        public UpgradeButtonPositionController(int countOfUpgrades) =>
            _countOfUpgrades = countOfUpgrades;

        public void SetPosition(RectTransform buttonRectTransform, Vector3 position, 
            GridLayoutGroup panelFactoryLayoutGroup, GridLayoutGroup panelLayoutGroup, int count)
        {
            float width = (panelLayoutGroup.cellSize.x * _countOfUpgrades
                + panelLayoutGroup.spacing.x * (_countOfUpgrades - 1)) + buttonRectTransform.sizeDelta.x / 2f;

            float height = position.y - (panelFactoryLayoutGroup.cellSize.y + panelFactoryLayoutGroup.spacing.y) * count;

            buttonRectTransform.localPosition = new Vector3(
                                                position.x + width,
                                                height,
                                                buttonRectTransform.localPosition.z
            );
        }
    }
}