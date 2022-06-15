using System;
using UnityEngine;
using routeSystem;
using UnityEngine.UI;
using Doozy.Engine.UI;

namespace Custom.UI.System
{
    public class MarkerPopUpmenuController: MonoBehaviour
    {
        [SerializeField] private string routePopUpName;
        

        public void MarkerButtonClick(ScreenInfo screenInfo)
        {
            print(screenInfo._name);
            OpenPopUp(routePopUpName, screenInfo._name, screenInfo.description);
        }
        private void OpenPopUp(string _popUpName, string nameField, string descriptionField)
        {
            UIPopup uIPopup = UIPopup.GetPopup(_popUpName);
            uIPopup.Data.SetLabelsTexts(nameField, descriptionField);
            uIPopup.Show();
        }
    }
}
