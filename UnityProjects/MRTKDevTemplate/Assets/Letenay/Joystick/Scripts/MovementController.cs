using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    public GameObject hitMarkerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HandleRaycastHit(RaycastHit hit)  
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Hit Something");
            GameObject marker = Instantiate(hitMarkerPrefab, hit.point, Quaternion.identity);
            //Destroy(marker, 1f);
            Transform hitObject = hit.collider.transform;
            Vector3 localHitPoint = hitObject.InverseTransformPoint(hit.point);

            string hitRegion = GetHitRegion(localHitPoint, hit.collider.bounds.extents);
            Debug.Log($"Clicked on: {hitObject.name}, Region: {hitRegion}");
            if (hitRegion.Equals("Top")) 
            {
                Forward();
            }

            if (hitRegion.Equals("Bottom")) 
            {
                Reverse();
            }

            if (hitRegion.Equals("Left")) 
            {
                Left();
            }

             if (hitRegion.Equals("Right")) 
            {
                Right();
            }
        }
    }

    private void Right()
    {
        Debug.Log("Right");
    }

    private void Left()
    {
        Debug.Log("Left");
    }

    private void Reverse()
    {
         Debug.Log("Reverse");
    }

    private void Forward()
    {
        Debug.Log("Forward");
    }

    private string GetHitRegion(Vector3 localPoint, Vector3 extents)
    {
        if (localPoint.y > extents.y * 0.5f) return "Top";
        if (localPoint.y < -extents.y * 0.5f) return "Bottom";
        if (localPoint.x > extents.x * 0.5f) return "Right";
        if (localPoint.x < -extents.x * 0.5f) return "Left";
        // if (localPoint.z > extents.z * 0.5f) return "Front";
        // if (localPoint.z < -extents.z * 0.5f) return "Back";
        return "Center";    
    }
}
