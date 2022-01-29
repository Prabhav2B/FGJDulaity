using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyTorque : MonoBehaviour
{
    [SerializeField] private float torque = 10f;
    private Rigidbody2D rb;
    private float turn;
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
        if(Mathf.Abs(rb.angularVelocity) < 80f)
        { 
            rb.AddTorque(torque * turn * -1f, ForceMode2D.Force);
        }
    }
}
