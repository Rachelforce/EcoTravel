using System;
using UnityEngine;
using routeSystem;
using UnityEngine.UI;

namespace Custom.UI.System
{
    public class MarkerPopUpmenuController: MonoBehaviour
    {
        [SerializeField] private Text nameField;
        [SerializeField] private Text descriptionField;

        public void MarkerButtonClick(ScreenInfo screenInfo)
        {
            nameField.text = screenInfo._name;
            descriptionField.text = screenInfo.description;
        }
    }
}
