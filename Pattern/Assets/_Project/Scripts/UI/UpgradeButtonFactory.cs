using UnityEngine;
using Zenject;

public class UpgradeButtonFactory
{
    private readonly GameObject _buttonPrefab;
    private readonly DiContainer _diContainer;

    public UpgradeButtonFactory(GameObject buttonPrefab, DiContainer diContainer)
    {
        _buttonPrefab = buttonPrefab;
        _diContainer = diContainer;
    }

    public GameObject Create(Transform parent) =>
        _diContainer.InstantiatePrefab(_buttonPrefab, parent);
}