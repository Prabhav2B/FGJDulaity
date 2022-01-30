using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundHitCheck : MonoBehaviour
{
    public UnityAction OnGroundImpact;

    private void Start()
    {
        OnGroundImpact += FindObjectOfType<CharacterHeadFollow>().SetBob;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer($"Ground"))
        {
            OnGroundImpact();
        }
    }
}