using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject avatar;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - avatar.transform.position;
    }
    void LateUpdate()
    {
        transform.position = avatar.transform.position + offset;
    }
}