using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradeButtonPositionController
    {
        private readonly GridLayoutGroup layoutGroup;
        private readonly int _countOfUpgrades;

        public UpgradeButtonPositionController(int countOfUpgrades) =>
            _countOfUpgrades = countOfUpgrades;

        public void SetPostion(RectTransform buttonRectTransform, float positionY, GridLayoutGroup layoutGroup)
        {
            float width = (layoutGroup.cellSize.x * _countOfUpgrades
                + layoutGroup.spacing.x * (_countOfUpgrades - 1)) + buttonRectTransform.sizeDelta.x / 2f;

            buttonRectTransform.position = new Vector3(
                                                buttonRectTransform.localPosition.x + width,
                                                positionY,
                                                buttonRectTransform.localPosition.z
            );
        }
    }
}