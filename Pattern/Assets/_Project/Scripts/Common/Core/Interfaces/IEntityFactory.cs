using UnityEngine;

public interface IEntityFactory
{
    public GameObject CreateTarget(TargetData targetData, IUpgradable playerData, UIElementsListData uIElementsListData);
}
