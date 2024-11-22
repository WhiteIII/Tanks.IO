using UnityEngine;

namespace TanksIO.UI
{
    public class GridLayoutGroupUIFactory
    {
        private readonly GameObject _uIElement;
        private readonly RectTransform _panelTransform;

        public GridLayoutGroupUIFactory(GameObject uIelement, RectTransform panelTransform)
        {
            _uIElement = uIelement;
            _panelTransform = panelTransform;
        }

        public GameObject Create() =>
            Object.Instantiate(_uIElement, _panelTransform);
    }
}