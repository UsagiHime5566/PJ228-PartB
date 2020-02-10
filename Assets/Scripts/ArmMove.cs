using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArmMove : MonoBehaviour
{
    public Vector3 rightFace;
    public Vector3 leftFace;
    public int posType;

    public float duration = 10;
    float gap = 8;
    void Start()
    {
        rightFace = transform.localScale;
        leftFace = new Vector3(-rightFace.x, rightFace.y, rightFace.z);

        if (posType == 0)
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(transform.DOScale(leftFace, 0));
            mySequence.Append(transform.DOLocalMoveX(-gap, duration).SetEase(Ease.Linear));
            mySequence.Append(transform.DOScale(rightFace, 0));
            mySequence.Append(transform.DOLocalMoveX(gap, duration).SetEase(Ease.Linear));

            mySequence.SetLoops(-1);
        }

        if (posType == 1)
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(transform.DOScale(rightFace, 0));
            mySequence.Append(transform.DOLocalMoveX(gap, duration).SetEase(Ease.Linear));
            mySequence.Append(transform.DOScale(leftFace, 0));
            mySequence.Append(transform.DOLocalMoveX(-gap, duration).SetEase(Ease.Linear));

            mySequence.SetLoops(-1);
        }

        if (posType == 2)
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(transform.DOScale(rightFace, 0));
            mySequence.Append(transform.DOLocalMoveX(gap, duration / 2).SetEase(Ease.Linear));
            mySequence.Append(transform.DOScale(leftFace, 0));
            mySequence.Append(transform.DOLocalMoveX(-gap, duration).SetEase(Ease.Linear));
            mySequence.Append(transform.DOScale(rightFace, 0));
            mySequence.Append(transform.DOLocalMoveX(0, duration / 2).SetEase(Ease.Linear));

            mySequence.SetLoops(-1);
        }
    }
}
