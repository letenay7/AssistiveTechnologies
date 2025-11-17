using UnityEngine;
using UnityEngine.UI;

namespace Letenay.Sipky.Scripts
{
    public class LoadingEffectHandler : MonoBehaviour
    {
        private Color defaultColor;
        private GameObject indicator;
        private readonly Color hoverColor = new Color32(228, 162, 11, 128);
        private readonly Color selectColor = new Color32(22, 227, 38, 128);

        private void Start()
        {
            indicator = transform.GetChild(4).gameObject;
            defaultColor = indicator.GetComponent<RawImage>().color;
        }

        public void SwitchDefaultToHover()
        {
            indicator.GetComponent<RawImage>().color = hoverColor;
            indicator.SetActive(true);
        }

        public void SwitchHoverToSelected()
        {
            indicator.GetComponent<RawImage>().color = selectColor;
        }

        public void SwitchToDefault()
        {
            indicator.GetComponent<RawImage>().color = defaultColor;
            indicator.SetActive(false);
        }
    }
}
