using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Letenay
{
    public class ButtonTrigger : MonoBehaviour
    {
        private LoadingEffectHandler effectHandler;
        private JoystickController joystickController;

        private void Start()
        {
            joystickController = GetComponentInParent<JoystickController>();
            effectHandler = GetComponent<LoadingEffectHandler>();
        }

        public void OnGazeEnter()
        {
            effectHandler.SwitchDefaultToHover();
        }

        public void OnGazeExit()
        {
            effectHandler.SwitchToDefault();
        }

        public void OnDwellSelectEntered(SelectEnterEventArgs eventArgs)
        {
            effectHandler.SwitchHoverToSelected();
            joystickController.EnableMovement();
        }
    }
}
