using UnityEngine;
using Zenject;

public class GunUpgradePanelManager : MonoBehaviour
{
    [SerializeField] private GunUpgradePanel[] _gunUpgradePanels;

    [Inject] private GunsDataList _gunsDataList;
}
