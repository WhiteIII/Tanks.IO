using System;
using UnityEngine;

[Serializable]
public class UpgradePanelConfig
{
    [field: SerializeField] public GameObject UIElement {  get; private set; }
    [field: SerializeField] public GameObject UpgradeButton { get; private set; }
    [field: SerializeField, Range(0, 10)] public int CountOfUpgrades { get; private set; }
}
