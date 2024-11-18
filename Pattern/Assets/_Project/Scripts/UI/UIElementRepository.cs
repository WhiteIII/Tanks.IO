using System.Collections.Generic;
using UnityEngine;

public class UIElementRepository
{
    public bool IsNotEmpty
    {
        get
        {
            return _uIElements.Count > 0;
        }
    }

    readonly private Queue<GameObject> _uIElements = new();

    public void Register(GameObject element) =>
        _uIElements.Enqueue(element);

    public void OffAllObjects()
    {
        foreach (GameObject element in _uIElements) 
            element.SetActive(false);
    }

    public GameObject GetAndUnregister()
        => _uIElements.Dequeue();
}
