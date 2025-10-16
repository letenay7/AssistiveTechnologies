using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private AvatarController avatarController;
    [SerializeField]
    private GameObject avatar;
    void Start()
    {
        avatarController = avatar.GetComponent<AvatarController>();
    }

    public void ToggleOnOff()
    {
        GameObject toggle = gameObject.transform.GetChild(0).gameObject;
        StatefulInteractable interactable = toggle.GetComponent<StatefulInteractable>();
        if (interactable != null)
        {
            //Debug.Log($"aaaaaaaaa {interactable.IsToggled}");
            //interactable.ForceSetToggled(!interactable.IsToggled);
            for (int i = 1; i < gameObject.transform.childCount; i++)
            {
                GameObject child = gameObject.transform.GetChild(i).gameObject;
                child.SetActive(interactable.IsToggled);
            }
        }
        else
        {
            Debug.LogWarning("StatefulInteractable component not found on toggle GameObject.");
        }
    }

    public void SpeedUp()
    {
        avatarController.IncreaseSpeed();
    }

    public void SlowDown()
    {
        avatarController.DecreaseSpeed();
    }
    public void Horn()
    {
        avatarController.MakeSound();
    }
}
