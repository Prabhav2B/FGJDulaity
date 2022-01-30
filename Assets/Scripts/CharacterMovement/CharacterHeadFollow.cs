using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterHeadFollow : MonoBehaviour
{
    [SerializeField] private float followDuration = 1f;
    private CharacterInput _characterInput;
    private Transform _characterBodyTransform;
    private Vector3 _offset;

    private bool _isTweening;
    private float _headBobOffset;
    private Rigidbody2D rb;
    //private float _lastDir;
    
    void Awake()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody2D>();
    }
    
    void Start()
    {
        _characterBodyTransform = FindObjectOfType<CharacterBodyTorque>().transform;
        _characterInput = FindObjectOfType<CharacterInput>();
        _offset = transform.localPosition - _characterBodyTransform.localPosition  ;
        _headBobOffset = 0f;
    }
    
    void Update()
    {
        float direction;
        if (!Mathf.Approximately(_characterInput.ReceivedInput.x, 0f))
        {
            direction = _characterInput.ReceivedInput.x > 0f ? 1f : -1f;
            //_lastDir = direction;
        }
        // else if (Mathf.Abs(rb.angularVelocity) > 100f)
        // {
        //     direction = rb.angularVelocity > 0f ? -1f : 1f;
        // }
        else
        {
            _headBobOffset = 0f;
            direction = 0f;
        }


        var targetPosition = _characterBodyTransform.position + _offset + (Vector3.right * (_headBobOffset * direction));
        
        
        if(!_isTweening)
            TweenBody(targetPosition);
    }

    private void TweenBody(Vector3 targetPosition)
    {
        _isTweening = true;
        transform.DOMove(targetPosition, followDuration).OnComplete(ResetTweenFlag);
    }

    private void ResetTweenFlag()
    {
        _isTweening = false;
    }

    public void SetBob()
    {
        // if((Mathf.Abs(rb.velocity.x) < 1f))
        //     return;
        DOTween.To(() => _headBobOffset, x => _headBobOffset = x, .2f, .2f).OnComplete(ResetBob);

    }

    private void ResetBob()
    {
        DOTween.To(() => _headBobOffset, x => _headBobOffset = x, 0f, .5f);
    }
}
