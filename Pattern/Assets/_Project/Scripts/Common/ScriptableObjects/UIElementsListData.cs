using System.Collections.Generic;
using UnityEngine;

namespace TanksIO.Common.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game", menuName = "Game/UIList")]
    public sealed class UIElementsListData : ScriptableObject
    {
        [field: SerializeField] public List<Sprite> List { get; private set; }
    }
}