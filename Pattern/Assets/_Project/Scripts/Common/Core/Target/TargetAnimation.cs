using UnityEngine;
using DG.Tweening;
using System;

public class TargetAnimation : EnemyCanvasAnimation
{
    private Tween _tween;

    private void Awake()
    {
        _tween = transform.DORotate(new Vector3(0, 360f, 0), 30, RotateMode.FastBeyond360).SetLoops(-1);
        _tween.Pause();
    }

    public override void StopAnimation()
    {
        _tween.Pause();
        base.StopAnimation();
    }

    public override void StartAnimation()
    {
        _tween.Play();
        base.StartAnimation();
    }

    private void OnDisable()
    {
        StopAnimation();
    }
}
