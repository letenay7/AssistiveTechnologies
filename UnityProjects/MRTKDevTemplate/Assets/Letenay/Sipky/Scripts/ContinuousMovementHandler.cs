using MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovementHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject avatar;
    private AvatarController avatarController;
    private bool isGazeHovered = false;
    private enum ActionType
    {
        Forward,
        Reverse,
        Left,
        Right
    }
    [SerializeField]
    private ActionType actionType;

    void Start()
    {
        avatarController = avatar.GetComponent<AvatarController>();
    }

    public void OnGazeEnter()
    {
        isGazeHovered = true;
    }

    public void OnGazeExit()
    {
        if (isGazeHovered)
        {
            isGazeHovered = false;
            StopAction(); // Stop movement immediately if gaze is broken
        }
    }

     // Called when the 2-second dwell is complete (XRI Select Entered)
    public void OnDwellSelectEntered(SelectEnterEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is FuzzyGazeInteractor)
        {
            StartAction();
        }
    }

    // Called when the dwell selection ends (XRI Select Exited)
    // public void OnDwellSelectExited(SelectExitEventArgs eventArgs)
    // {
    //     if (eventArgs.interactorObject is FuzzyGazeInteractor)
    //     {
    //         isSelectedViaDwell = false;
    //         StopAction();
    //     }
    // }
    

    private void StartAction()
    {
        if (avatarController == null) return;
        
        switch (actionType)
        {
            case ActionType.Forward:
                avatarController.SetMovementInput(Vector3.forward);
                break;
            case ActionType.Reverse:
                avatarController.SetMovementInput(Vector3.back);
                break;
            case ActionType.Left:
                avatarController.SetRotationInput(-1f);
                break;
            case ActionType.Right:
                avatarController.SetRotationInput(1f);
                break;
        }
    }

    private void StopAction()
    {
        if (avatarController == null) return;
   
        switch (actionType)
        {
            case ActionType.Forward:
                avatarController.SetMovementInput(Vector3.zero);
                break;
            case ActionType.Reverse:
                avatarController.SetMovementInput(Vector3.zero);
                break;
            case ActionType.Left:
                avatarController.SetRotationInput(0f);
                break;
            case ActionType.Right:
                avatarController.SetRotationInput(0f);
                break;
        }
    }
}
