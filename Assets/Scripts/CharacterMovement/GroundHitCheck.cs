using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundHitCheck : MonoBehaviour
{
    public UnityAction OnGroundImpact;

    [SerializeField] private GameObject _particleSystemGameObject;
    private ParticleSystem _particleSystem;
    private CircleCollider2D _circleCollider2D;

    private void Start()
    {
        _particleSystem = _particleSystemGameObject.GetComponent<ParticleSystem>();
        _circleCollider2D = GetComponent<CircleCollider2D>();

        OnGroundImpact += FindObjectOfType<CharacterHeadFollow>().SetBob;
        OnGroundImpact += PlayParticles;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer($"Ground"))
        {
            OnGroundImpact();
        }
    }

    private void PlayParticles()
    {
        _particleSystemGameObject.transform.localPosition = _circleCollider2D.offset;
        _particleSystemGameObject.transform.rotation = Quaternion.identity;
        _particleSystem.Play();
        Debug.Log("snow particles");
    }
}