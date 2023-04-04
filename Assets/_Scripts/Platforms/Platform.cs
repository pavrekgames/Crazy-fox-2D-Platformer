using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Platform : MonoBehaviour
{
    [SerializeField] protected Transform[] points;
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected bool isVertical = false;

    public Sequence mySequence;

    protected virtual void Start()
    {
        mySequence = DOTween.Sequence();

        if (isVertical) { AnimatePlatformVertical(); } else { AnimatePlatformHorizontal(); }

    }

    protected virtual void AnimatePlatformHorizontal()
    {
        mySequence.Append(transform.DOMoveX(points[0].transform.position.x, speed));
        mySequence.Append(transform.DOMoveX(points[1].transform.position.x, speed)).SetLoops(-1);
    }

    protected virtual void AnimatePlatformVertical()
    {
        mySequence.Append(transform.DOMoveY(points[0].transform.position.y, speed));
        mySequence.Append(transform.DOMoveY(points[1].transform.position.y, speed)).SetLoops(-1);
    }

}
