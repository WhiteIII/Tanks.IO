using TanksIO.Common.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace TanksIO.UI
{
    public class GunUpgradePanelManager : MonoBehaviour
    {
        [SerializeField] private GunUpgradePanel[] _gunUpgradePanels;

        [Inject] private GunsDataList _gunsDataList;
    }
}