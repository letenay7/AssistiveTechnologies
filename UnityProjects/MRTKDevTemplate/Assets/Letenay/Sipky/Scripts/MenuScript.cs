using MixedReality.Toolkit;
using UnityEngine;

namespace Letenay
{
    public class MenuScript : MonoBehaviour
    {
        private AvatarController avatarController;

        [SerializeField]
        private GameObject avatar;

        private void Start()
        {
            avatarController = avatar.GetComponent<AvatarController>();
        }

        public void ToggleOnOff()
        {
            GameObject toggle = gameObject.transform.GetChild(0).gameObject;
            StatefulInteractable interactable = toggle.GetComponent<StatefulInteractable>();
            for (int i = 1; i < gameObject.transform.childCount; i++)
            {
                GameObject child = gameObject.transform.GetChild(i).gameObject;
                child.SetActive(interactable.IsToggled);
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

        public void Stop()
        {
            avatarController.StopMovement();
        }
    }
}
