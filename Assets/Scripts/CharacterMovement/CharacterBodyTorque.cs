using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyTorque : MonoBehaviour
{
    [SerializeField] private float torque = 10f;
    [SerializeField] private float torqueThreshold = 80f;
    [SerializeField] private float waitTime = 1f;
    
    private Rigidbody2D rb;
    private float turn;
    private bool inputPause;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTorqueValue(Vector2 receivedInput)
    {
        turn = Mathf.Clamp(receivedInput.x, -1f, 1f);
    }

    private void FixedUpdate()
    {
        
        if(Mathf.Approximately(turn, 0f))
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
