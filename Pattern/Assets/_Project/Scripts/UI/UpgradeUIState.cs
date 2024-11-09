using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIState : MonoBehaviour
{
    [SerializeField] private Image[] _UIElements;
    [SerializeField] private Button _button;

    private Image _buttonImage;
    private Color _originalColor;
    private int _counActivatedUIelements = 0;

    private void Awake()
    {
        _buttonImage = _button.GetComponent<Image>();
        _originalColor = _buttonImage.color;
        
        foreach (var uiElement in _UIElements)
        {
            uiElement.enabled = false;
        }

        _button.onClick.AddListener(ChangeUIElementsView);
    }

    private void ChangeUIElementsView()
    {        
        _UIElements[_counActivatedUIelements].enabled = true;
        
        _counActivatedUIelements++;

        if (_counActivatedUIelements == _UIElements.Length)
        {
            _button.onClick.RemoveListener(ChangeUIElementsView);
            _button.enabled = false;
            _buttonImage.color = Color.gray;
        }
    }

    public void Activate()
    {
        _button.enabled = true;
        _buttonImage.color = _originalColor;
    }

    public void Deactivate()
    {
        _button.enabled = false;
        _buttonImage.color = Color.gray;
    }
}
