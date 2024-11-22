using UnityEngine;
using DG.Tweening;

namespace TanksIO.UI
{
    public class PanelAnimation : MonoBehaviour
    {
        private RectTransform _transform;
        private Vector3 _transformLengthToShow;
        private Vector3 _transformLengthToHide;
        private float _duration;
        private bool _isLocalMove = false;

        public void Init(Vector3 transformLentghToShow, Vector3 transformLentghToHide, float duration)
        {
            _transformLengthToShow = transformLentghToShow;
            _transformLengthToHide = transformLentghToHide;
            _duration = duration;
        }

        public void Init(Vector3 transformLentghToShow, Vector3 transformLentghToHide, float duration, bool isLocalMove)
        {
            Init(transformLentghToShow, transformLentghToHide, duration);

            _isLocalMove = isLocalMove;
        }

        private void Awake() =>
            _transform = GetComponent<RectTransform>();

        public void ShowPanel() =>
            MovePanel(_transformLengthToShow);

        public void HidePanel() =>
            MovePanel(_transformLengthToHide);

        private void MovePanel(Vector3 endPosition)
        {
            if (_isLocalMove)
                _transform.DOLocalMove(endPosition, _duration, true);
            else
                _transform.DOMove(endPosition, _duration, true);
        }
    }
}