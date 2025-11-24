using UnityEngine;

namespace Letenay
{
    public class JoystickController : MonoBehaviour
    {
        private bool isEnabled;

        [SerializeField]
        private GameObject gazeIndicator;

        private float x;
        private float y;
        private Vector3 defaultIndicatorPosition = Vector3.zero;

        private void Start()
        {
            defaultIndicatorPosition = gazeIndicator.transform.localPosition;
        }

        private void Update()
        {
            if (isEnabled)
            {
                gazeIndicator.transform.position = new Vector3(x, y, gazeIndicator.transform.position.z);
            }
        }

        public void DisableMovement()
        {
            isEnabled = false;
            gazeIndicator.transform.localPosition = defaultIndicatorPosition;
            gazeIndicator.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Movement Disabled");
        }

        public void EnableMovement()
        {
            isEnabled = true;
            gazeIndicator.transform.Find("DwellIndicator").gameObject.SetActive(false);
            // disable collider because of raycasts
            gazeIndicator.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Movement Enabled");
        }

        public void OnRaycastHit(RaycastHit hit)
        {
            Transform hitObject = hit.collider.transform;
            Vector3 localPosition = hitObject.InverseTransformPoint(hit.point);
            if (isEnabled)
            {
                //Debug.Log(localPosition);
                x = hit.point.x;
                y = hit.point.y;
                /* Values accepted by the wheelchair are 0-255
               Our joystick pointer is at local coords (0, 0, 0) and the joystick has size 260x260
               considering the size of the gaze pointer and tolerance local values on the joystick are <-128, 128>
            */
                if (Mathf.Abs(localPosition.x) > 128f || Mathf.Abs(localPosition.y) > 128f)
                {
                    DisableMovement();
                }

                int joystickX = Mathf.RoundToInt(localPosition.x) + 128;
                int joystickY = Mathf.RoundToInt(localPosition.y) + 128;
                //Debug.Log($"x: {joystickX} y: {joystickY}");
            }
        }
    }
}
