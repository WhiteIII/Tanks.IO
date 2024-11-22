using UnityEngine;

namespace TanksIO.Controller
{
    public interface IMoveableInput
    {
        bool IsActive { get; }
        Vector3 Move { get; }
    }
}