using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradePanelTextFactory
    {
        private readonly TextUpgradePanelPositionController _upgradePanelPositionController;

        private int _count = 0;

        public UpgradePanelTextFactory(int countsOfUpgrades) =>
            _upgradePanelPositionController = new(countsOfUpgrades);
        
        public void Create(Upgrades upgrades, Vector3 panelsFactoryPosition, 
            GridLayoutGroup panelFactoryGridLayoutGroup, GridLayoutGroup panelLayoutGroup, UpgradePanelRepository upgradePanelRepository)
        {
            GameObject textObject = new($"Text {upgrades}");
            TextMeshProUGUI text = textObject.AddComponent<TextMeshProUGUI>();

            upgradePanelRepository.AddChildren(textObject.GetComponent<RectTransform>());
            _upgradePanelPositionController.SetPosition(textObject.GetComponent<RectTransform>(), panelsFactoryPosition, 
                panelFactoryGridLayoutGroup, panelLayoutGroup, _count);

            text.alignment = TextAlignmentOptions.Center;
            text.text = upgrades.ToString();
            _count++;
        }
    }
}