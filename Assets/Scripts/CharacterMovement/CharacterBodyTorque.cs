using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyTorque : MonoBehaviour
{
    [SerializeField] private float torque = 10f;
    [SerializeField] private float torqueThreshold = 80f;
    [SerializeField] private float waitTime = 1f;

    private BoundryDetection _boundryDetection;
    private CharacterHeadFollow _characterHeadFollow;
    
    private Rigidbody2D rb;
    private float turn;
    private bool inputPause;
    
    void Awake()
    {
        _characterHeadFollow = FindObjectOfType<CharacterHeadFollow>();
        rb = GetComponent<Rigidbody2D>();

        _boundryDetection = GetComponent<BoundryDetection>();
    }

    public void SetTorqueValue(Vector2 receivedInput)
    {
        turn = Mathf.Clamp(receivedInput.x, -1f, 1f);
    }

    private void FixedUpdate()
    {
        if (_boundryDetection.stopMovingLeft && turn < 0f || _boundryDetection.stopMovingRight && turn > 0f)
            return;

        if (Mathf.Approximately(turn, 0f))
            return;

        GenerateTorque(turn);
    }

    private void GenerateTorque(float f)
    {
        if(Mathf.Abs(rb.angularVelocity) < torqueThreshold && !inputPause)
        { 
            rb.AddTorque(torque * turn * -1f, ForceMode2D.Force);
        }
        else if (!inputPause)
        {
            inputPause = true;
            StartCoroutine(InputPauseTimer());
        }
        
    }

    IEnumerator InputPauseTimer()
    {
        var timer = 0f;
        //var startTime = Time.time;
        while (true)
        {
            if (timer >= waitTime)
            {
                break;
            }

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        inputPause = false;
        yield return null;
    }
}
