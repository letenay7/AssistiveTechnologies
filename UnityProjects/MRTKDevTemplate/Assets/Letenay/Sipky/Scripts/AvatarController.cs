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
    private float speed = 1;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
       
    }

    public void IncreaseSpeed() 
    {
        if (speed < 5) 
        {
            speed++;
            Debug.Log($"Speed increased. Current speed: {speed}");
        }
       
    }
    public void DecreaseSpeed()
    {
        if (speed > 1) 
        {
            speed--;
            Debug.Log($"Speed decreased. Current speed: {speed}");
        }
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
        Move(Vector3.left);
    }

    public void Right() 
    {
        Move(Vector3.right);
    }

    private void Move(Vector3 direction)
    {
        Vector3 moveVector = direction.normalized * moveDistance * speed;
        rigidBody.velocity = moveVector;
    }
    
    public void MakeSound()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }

    
}
