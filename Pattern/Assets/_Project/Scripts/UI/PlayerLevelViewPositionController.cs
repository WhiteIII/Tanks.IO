using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class PlayerLevelViewPositionController
    {
        private readonly RectTransform _playerLevelPanelRectTransform;
        private readonly GridLayoutGroup _panelgridLayoutGroup;
        private readonly int _countOfElements;

        public PlayerLevelViewPositionController(RectTransform playerLevelPanelRectTransform,
            GridLayoutGroup panelGridLayoutGroup, int countOfElements)
        {
            _playerLevelPanelRectTransform = playerLevelPanelRectTransform;
            _panelgridLayoutGroup = panelGridLayoutGroup;
            _countOfElements = countOfElements;
        }

        public void SetPosition()
        {
            float heigth = _panelgridLayoutGroup.cellSize.y * _countOfElements + _playerLevelPanelRectTransform.sizeDelta.y / 2f;
            _playerLevelPanelRectTransform.position = new Vector3(
                                                            _playerLevelPanelRectTransform.position.x,
                                                            _playerLevelPanelRectTransform.position.y - heigth,
                                                            _playerLevelPanelRectTransform.position.z
                );
        }
    }
}