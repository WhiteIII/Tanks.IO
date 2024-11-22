using UnityEngine;
using TanksIO.Common.Core.Enemy;

namespace TanksIO.UI
{
    public class CanvasLookedOnCamera : MonoBehaviour
    {
        private Camera _camera;
        private EnemyCanvasAnimation _targetAnimation;
        private bool _isPlaying = false;

        private void Update()
        {
            if (_camera == null)
            {
                return;
            }

            if (_isPlaying == false)
            {
                return;
            }

            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.back, _camera.transform.rotation * Vector3.up);
        }

        private void OnDestroy()
        {
            _targetAnimation.AnimationStateChange -= InTheLens;
        }

        public void Init(Camera camera, EnemyCanvasAnimation targetAnimation)
        {
            _camera = camera;
            _targetAnimation = targetAnimation;

            _targetAnimation.AnimationStateChange += InTheLens;
        }

        private void InTheLens(bool isPlaying)
        {
            _isPlaying = isPlaying;
        }
    }
}