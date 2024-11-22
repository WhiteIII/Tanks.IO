using System;
using TanksIO.Common.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TanksIO.UI
{
    public class GunUpgradeButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GunUpgradePanel _gunUpgradePanel;
        [SerializeField] private GunType _currentGunType;
        [SerializeField] private GunType[] _gunTypeForViseble;

        public event Action OnClicked;

        private IGunUpgradable _gunUpgradable;
        private GunsDataList _gunDataList;

        [Inject]
        private void Construct(PlayerData playerData, GunsDataList gunsDataList)
        {
            _gunUpgradable = playerData;
            _gunDataList = gunsDataList;
        }

        private void Awake()
        {
            _gunUpgradePanel.Upgraded += ChangeButtonVisible;
        }

        private void OnDestroy()
        {
            _gunUpgradePanel.Upgraded -= ChangeButtonVisible;
        }

        private void ChangeButtonVisible()
        {
            foreach (GunType gunType in _gunTypeForViseble)
            {
                if (_gunDataList.CurrentGun.GunType == gunType)
                {
                    return;
                }
            }

            gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _gunUpgradable.ChangeGun(_currentGunType);
            OnClicked?.Invoke();
        }
    }
}