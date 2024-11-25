using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TanksIO.UI
{
    public class UpgradeButtonFactory
    {
        private readonly UpgradeButtonPositionController _positionController;
        private readonly GameObject _buttonPrefab;
        private readonly DiContainer _diContainer;

        private int _count = 0;

        public UpgradeButtonFactory(GameObject buttonPrefab, DiContainer diContainer,
            int countOfUpgrades)
        {
            _buttonPrefab = buttonPrefab;
            _diContainer = diContainer;

            _positionController = new UpgradeButtonPositionController(countOfUpgrades);
        }

        public GameObject Create(Vector3 panelPostion, GridLayoutGroup panelFactoryGridLayoutGroup, 
            GridLayoutGroup panelGridLayoutGroup, RectTransform parent)
        {
            GameObject buttonObject = _diContainer.InstantiatePrefab(_buttonPrefab, parent);
            _positionController.SetPostion(buttonObject.GetComponent<RectTransform>(),
                panelPostion, panelFactoryGridLayoutGroup, panelGridLayoutGroup, _count);
            _count++;
            return buttonObject;
        }
    }
}