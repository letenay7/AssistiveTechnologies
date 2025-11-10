using UnityEngine;

namespace Letenay.Sipky.Scripts
{



    public class DirectionController : MonoBehaviour
    {
        private GameObject currentDirection;
        private LoadingEffectHandler effectHandler;

        public void SetDirection(GameObject direction)
        {
            currentDirection = direction;
            effectHandler = currentDirection.GetComponent<LoadingEffectHandler>();
        }

        public void SwitchCurrentToHover()
        {
            effectHandler.SwitchDefaultToHover();
        }

        public void SwitchCurrentToSelected()
        {
            effectHandler.SwitchHoverToSelected();

        }

        public void ResetToDefault()
        {
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent<LoadingEffectHandler>(out var handler))
                {
                    handler.SwitchToDefault();
                }
                else
                {
                    Debug.LogWarning("No loading effect found for " + child.name);
                }
            }
        }
    }
}
