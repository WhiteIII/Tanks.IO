using TanksIO.Common.Services;
using UnityEngine;

namespace TanksIO.UI
{
    public class EntityHealthBarController : MonoBehaviour
    {
        private GameObject _canvasGameObject;
        private EntityHealth _entityHealth;

        private bool _isActive;

        private void OnDestroy()
        {
            _entityHealth.HealthHasChanged -= ActiveCanvas;
            _entityHealth.Reborn -= SubscribeUntilReborn;
        }

        private void ActiveCanvas()
        {
            _entityHealth.HealthHasChanged -= ActiveCanvas;

            _canvasGameObject.SetActive(true);
        }

        private void SubscribeUntilReborn()
        {
            _entityHealth.HealthHasChanged += ActiveCanvas;
            _canvasGameObject.SetActive(false);
            _isActive = false;
        }

        public void Init(GameObject canvasGameObject, EntityHealth entityHealth)
        {
            _canvasGameObject = canvasGameObject;
            _entityHealth = entityHealth;

            _entityHealth.HealthHasChanged += ActiveCanvas;
            _entityHealth.Reborn += SubscribeUntilReborn;
            _canvasGameObject.SetActive(false);
            _isActive = true;
        }

        private void OnEnable()
        {
            if (_isActive == false)
            {
                _canvasGameObject?.SetActive(false);
                _isActive = true;
            }
        }
    }
}