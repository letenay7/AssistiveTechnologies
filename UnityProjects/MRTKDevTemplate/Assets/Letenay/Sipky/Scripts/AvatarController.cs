using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;




public class AvatarController : MonoBehaviour
{
    private Rigidbody rigidBody;
   
    private float moveDistance = 1f;
    private float forwardSpeed = 1f;
    private float reverseMultiplier = 0.5f;
    private float rotateMultiplier = 0.8f;
    private bool isMoving = false;
    private bool isTurning = false;
    
    // stlacim tlacitko a hybem sa kym neslacim ine  alebo pokial neuhnem pohladom
    // TODO refactor method order
    // TODO Manage movement from menuScript via Statefulinteractable isGazeHovered
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
       
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
    public void StartMovement()
    {
        isMoving = true;
    }
    public void Forward()
    {
        Move(Vector3.forward);
    }
    public void Reverse() 
    {
        Move(Vector3.back);
    }
    public void Left()
    {
        Turn(Vector3.left);
    }

    public void Right()
    {
        Turn(Vector3.right);
    }

    public void Move(Vector3 direction)
    {
        Debug.Log($"Moving enabled {isMoving}");
        if (isMoving)
        {
            Vector3 moveVector = direction.normalized;
            if (direction == Vector3.forward)
            {
                moveVector *= forwardSpeed;
            }
            else
            {
                moveVector *= reverseMultiplier * forwardSpeed;
            }
            rigidBody.velocity = moveVector;
        }
    }
    private void Turn(Vector3 direction)
    {
       if (isTurning)
        {
            Vector3 rotationVector = Vector3.up * rotateMultiplier;
            if (direction == Vector3.right)
            {
                transform.Rotate(rotationVector);
            }
            else
            {
                transform.Rotate(-rotationVector);
            }
        }
    }

    public void MakeSound()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
    public void StopMovement()
    {
        isMoving = false;
        rigidBody.velocity = Vector3.zero;
        Debug.Log("Stop");
    }

    public void StopTurn()
    {
        isTurning = false;
    }

    public void StartTurn()
    {
        isTurning = true;
    } 
}
