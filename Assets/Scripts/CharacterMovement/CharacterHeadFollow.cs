using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterHeadFollow : MonoBehaviour
{
    [SerializeField] private float followDuration = 1f;
    private Transform _characterBodyTransform;
    private Vector3 _offset;

    private bool isTweening;
    
    void Start()
    {
        _characterBodyTransform = FindObjectOfType<CharacterBodyTorque>().transform;
        _offset = transform.localPosition - _characterBodyTransform.localPosition  ;
    }
    
    void Update()
    {
        var targetPosition = _characterBodyTransform.position + _offset;
        if(!isTweening)
            TweenBody(targetPosition);
    }

    private void TweenBody(Vector3 targetPosition)
    {
        isTweening = true;
        transform.DOMove(targetPosition, followDuration).OnComplete(ResetTweenFlag);
    }

    private void ResetTweenFlag()
    {
        isTweening = false;
    }


}
