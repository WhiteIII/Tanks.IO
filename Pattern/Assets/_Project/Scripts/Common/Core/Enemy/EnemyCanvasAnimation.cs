using System;
using UnityEngine;

namespace TanksIO.Common.Core.Enemy
{
    public class EnemyCanvasAnimation : MonoBehaviour
    {
        private bool _isPlaying = false;

        public event Action<bool> AnimationStateChange;

        public virtual void StopAnimation()
        {
            _isPlaying = false;
            AnimationStateChange?.Invoke(_isPlaying);
        }

        public virtual void StartAnimation()
        {
            _isPlaying = true;
            AnimationStateChange?.Invoke(_isPlaying);
        }
    }
}