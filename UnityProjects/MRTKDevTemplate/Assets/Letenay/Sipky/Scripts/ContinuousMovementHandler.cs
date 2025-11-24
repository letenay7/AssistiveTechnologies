using MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Letenay
{
    public class ContinuousMovementHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject avatar;

        private AvatarController avatarController;

        [SerializeField]
        private TextMeshProUGUI currentlySelected;

        [SerializeField]
        private Direction currentDirection;

        private DirectionController directionController;
        private bool isSelected;
        private bool isHovering;

        private void Start()
        {
            avatarController = avatar.GetComponent<AvatarController>();
            directionController = gameObject.GetComponentInParent<DirectionController>();
        }

        public void OnGazeEnter()
        {
            StopAction(); // stop current Action
            directionController.SetDirection(gameObject);
            isHovering = true;
            directionController.SwitchCurrentToHover();
        }

        public void OnGazeExit() // if user exits hover before 2s dwell completes
        {
            // reset if hover started but action was not triggered
            if (isHovering && !isSelected)
            {
                directionController.ResetToDefault();
            }
        }

        // Called when the 2-second dwell is complete (XRI Select Entered)
        public void OnDwellSelectEntered(SelectEnterEventArgs eventArgs)
        {
            isSelected = false;
            isSelected = true;
            if (eventArgs.interactorObject is FuzzyGazeInteractor)
            {
                StartAction();
            }
        }

        private void StartAction()
        {
            if (avatarController == null)
            {
                Debug.Log("Avatar Controller is null");
                return;
            }
            directionController.SwitchCurrentToSelected();
            switch (currentDirection)
            {
                case Direction.Forward:
                    avatarController.SetMovementInput(Vector3.forward);
                    break;
                case Direction.Reverse:
                    avatarController.SetMovementInput(Vector3.back);
                    break;
                case Direction.Left:
                    avatarController.SetRotationInput(-1f);
                    break;
                case Direction.Right:
                    avatarController.SetRotationInput(1f);
                    break;
            }

            currentlySelected.text = $"Currently selected: {currentDirection}";
        }

        private void StopAction()
        {
            if (avatarController == null)
            {
                Debug.Log("Avatar Controller is null");
                return;
            }

            isSelected = false;
            isHovering = false;
            directionController.ResetToDefault();

            switch (currentDirection)
            {
                case Direction.Forward:
                case Direction.Reverse:
                    avatarController.SetMovementInput(Vector3.zero);
                    break;
                case Direction.Left:
                case Direction.Right:
                    avatarController.SetRotationInput(0f);
                    break;
            }
            //currentlySelected.text = "Currently selected: Stop";
        }
    }
}
