using System;
using UnityEngine;
using UnityEngine.Events;
using routeSystem;
using UnityEngine.UI;
using Doozy.Engine.UI;
using System.Collections.Generic;
namespace Custom.UI.System
{
    public class UtilPopUpController : MonoBehaviour
    {
        [SerializeField] private string popUpName;
        UIPopup OpenUIPopup = null;
        public void OpenAtWorkPopUp()
        {
            OpenUIPopup = UIPopup.GetPopup(popUpName);
            OpenUIPopup.Show();
        }
    }

}
