using UnityEngine;

public interface IMoveableInput
{ 
    bool IsActive { get; }
    Vector3 Move { get; }
}

