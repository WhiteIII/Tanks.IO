using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected Image _healthBar;

    protected virtual void Start()
    {
        _healthBar = GetComponent<Image>();
    }
    
    private void Awake() =>
        _health.HealthHasChanged += ChangeBar;

    private void OnDestroy() =>
        _health.HealthHasChanged -= ChangeBar;


    protected virtual void ChangeBar()
    {
        _healthBar.fillAmount = (float)_health.HealthValue / _health.MaxHealth;
    }
}
