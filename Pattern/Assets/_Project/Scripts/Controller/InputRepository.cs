﻿using UnityEngine;

namespace TanksIO.Controller
{
    public class InputRepository : MonoBehaviour
    {
        private IMoveableInput[] _movementInputs;

        private void FixedUpdate()
        {
            foreach (var input in _movementInputs)
            {
                if (input.IsActive)
                { }
            }
        }
    }
}