using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Custom.UI.System
{
    
    public class ZoomButtons : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] float speed;
        public void ZoomIn()
        {
            slider.value += speed;
        }
        public void ZoomOut()
        {
            slider.value -= speed;
        }
    }
}
