using System.Collections.Generic;
using UnityEngine;

namespace TanksIO.UI
{
    public class UpgradePanelRepository : MonoBehaviour 
    {
        private RectTransform RectTransform => GetComponent<RectTransform>();

        private List<RectTransform> _uIElementsList = new();

        public void AddChildren(RectTransform uIElementRectTransform)
        {
            uIElementRectTransform.SetParent(RectTransform);
            _uIElementsList.Add(uIElementRectTransform);
        }
    }
}