using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;




public class AvatarController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float forwardSpeed = 1f;
    [SerializeField]
    private float reverseSpeedMultiplier = 0.5f;
    [SerializeField]
    private float rotationSpeedMultiplier = 0.8f;
    private Vector3 currentMovementInput = Vector3.zero;
    private float currentRotationInput = 0f;
    /*
        base values for wheelchair position are 128
        forward = increase baseY
        reverse = decrease baseY
        right = increase baseX
        left = decrease baseX
        https://github.com/JurajVincur/BleTest/blob/main/Assets/BleWheelchair/Scripts/TestBle.cs  
    */
    private float baseX = 128f;
    private float baseY = 128f;

    // TODO fix accidental triggers on gaze exit
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }

    private void ApplyMovement()
    {
        if (currentMovementInput != Vector3.zero)
        {
            float speed = forwardSpeed;
            if (currentMovementInput == Vector3.back)
            {
                speed *= reverseSpeedMultiplier;
            }
            Vector3 moveVector = currentMovementInput * speed;        
            // Apply velocity, keeping existing Y velocity (e.g., gravity)
            rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.z);
        }
    }

    private void ApplyRotation()
    {
        if (currentRotationInput != 0f)
        {
            float rotationAmount = currentRotationInput * rotationSpeedMultiplier;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
    public void StopMovement()
    {
        rigidBody.velocity = Vector3.zero;
        currentMovementInput = Vector3.zero;
        SetRotationInput(0f);
        rigidBody.angularVelocity = Vector3.zero;
        Debug.Log("Stop");
    }

    public void SetMovementInput(Vector3 direction)
    {
        currentMovementInput = direction;
        if (direction == Vector3.zero)
        {
            StopMovement();
        }
    }
    
    public void SetRotationInput(float direction)
    {
        /* -1 for left
          1 for right,
          0 for stop 
        */
        currentRotationInput = direction;
    }

    public void IncreaseSpeed()
    {
        if (forwardSpeed < 5)
        {
            forwardSpeed++;
            Debug.Log($"Speed increased. Current speed: {forwardSpeed}");
        }
    }
    
    public void DecreaseSpeed()
    {
        if (forwardSpeed > 1)
        {
            forwardSpeed--;
            Debug.Log($"Speed decreased. Current speed: {forwardSpeed}");
        }
    }

    public void MakeSound()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
}
