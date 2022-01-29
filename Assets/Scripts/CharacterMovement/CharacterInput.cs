using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    private CharacterBodyTorque _characterBodyTorque;
    
    public Vector2 ReceivedInput { get; set; }

    private void Awake()
    {
        _characterBodyTorque = GetComponent<CharacterBodyTorque>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        ReceivedInput = context.ReadValue<Vector2>();
        _characterBodyTorque.SetTorqueValue(ReceivedInput);
    }
    
}
