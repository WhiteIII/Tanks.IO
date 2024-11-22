using UnityEngine;
using UnityEngine.UI;

namespace TanksIO.UI
{
    public class UpgradeButtonView
    {
        private readonly Image _buttonImage;
        private readonly Color _originalColor;

        public UpgradeButtonView(Image buttonImage)
        {
            _buttonImage = buttonImage;
            _originalColor = _buttonImage.color;
        }

        public void ActivateButton() =>
            _buttonImage.color = _originalColor;

        public void DeactivateButton() =>
            _buttonImage.color = Color.gray;
    }
}