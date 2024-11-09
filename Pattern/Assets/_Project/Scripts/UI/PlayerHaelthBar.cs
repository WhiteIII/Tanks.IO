using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHaelthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _text;

    private StringBuilder _stringBuilder;

    protected override void Start()
    {
        _stringBuilder = new StringBuilder();

        _healthBar = GetComponent<Image>();
        ChangeHealthCount();
    }

    protected override void ChangeBar()
    {
        base.ChangeBar();

        ChangeHealthCount();
    }

    private void ChangeHealthCount()
    {
        _stringBuilder.Append(_health.HealthValue);
        _stringBuilder.Append(" / ");
        _stringBuilder.Append(_health.MaxHealth);

        _text.text = _stringBuilder.ToString();
        _stringBuilder.Clear();
    }
}
