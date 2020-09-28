using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Transform))]

public class MovementKnife : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;

    private float _startPoint;

    private void Start()
    {
        _startPoint = transform.position.x;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveX(_endPoint.position.x, 3).SetEase(Ease.Linear));
        sequence.Append(transform.DOScaleY(-1, 0.5f));
        sequence.Append(transform.DOMoveX(_startPoint, 3).SetEase(Ease.Linear));
        sequence.Append(transform.DOScaleY(1, 0.5f));

        sequence.SetLoops(-1, LoopType.Restart);
    }
}
