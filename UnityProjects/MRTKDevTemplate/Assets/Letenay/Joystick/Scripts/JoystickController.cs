using System;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private bool isWithinBounds;
    [SerializeField] private GameObject gazeIndicator;
    private float x;
    private float y;
    private Vector3 defaultIndicatorPosition = Vector3.zero;

    void Start()
    {
        defaultIndicatorPosition = gazeIndicator.transform.position;
    }

    void Update()
    {
        if (isWithinBounds)
        {
            gazeIndicator.transform.position = new Vector3(x, y, gazeIndicator.transform.position.z);
        }
    }

    public void DisableMovement()
    {
        isWithinBounds = false;
        gazeIndicator.transform.position = defaultIndicatorPosition;
        Debug.Log("Movement Disabled");
    }

    public void EnableMovement()
    {
        isWithinBounds = true;
        Debug.Log("Movement Enabled");
    }

    public void OnRaycastHit(RaycastHit hit)
    {
        Transform hitObject = hit.collider.transform;
        Vector3 localPosition = hitObject.InverseTransformPoint(hit.point);
        if (isWithinBounds)
        {
            x = hit.point.x;
            y = hit.point.y;
            localPosition.z = defaultIndicatorPosition.z;
            //Debug.Log(Vector3.Distance(localPosition, defaultIndicatorPosition));
            if (Vector3.Distance(localPosition, defaultIndicatorPosition) > 150f)
            {
                DisableMovement();
            }

            Tuple<float, float> joystickValues = CalculateJoystickValues(localPosition.x, localPosition.y);
            //Debug.Log($"x: {joystickValues.Item1}, y: {joystickValues.Item2}");
        }
    }

    private Tuple<float, float> CalculateJoystickValues(float localX, float localY)
    {
        localX += 128f;
        localY += 128f;
        return new Tuple<float, float>(localX, localY);
    }
}
