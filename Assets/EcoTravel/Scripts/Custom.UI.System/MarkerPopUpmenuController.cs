using System;
using UnityEngine;
using UnityEngine.Events;
using routeSystem;
using UnityEngine.UI;
using Doozy.Engine.UI;
using System.Collections.Generic;

namespace Custom.UI.System
{
    public class MarkerPopUpmenuController: MonoBehaviour
    {
        #region variables
        [SerializeField] private string routePopUpName;
        [SerializeField] private string morePopUpName;
        public UnityAction[] onPopupButtonClick = new UnityAction[2];

        UIPopup OpenUIPopup = null;
        ScreenInfo OpenscreenInfo = null;
        #endregion variables

        #region EventListener
        public void MarkerButtonClick(ScreenInfo screenInfo)
        {
            OpenscreenInfo  = screenInfo;   
            OpenShortPopUp(OpenscreenInfo);
        }
        public void RouteButtonClick(int id)
        {
            ScreenInfo screenInfo= RouteStore.GetRoute(id);
            MarkerButtonClick(screenInfo);
        }
        public void MoreButtonClick()
        {
            HideOldPopUp();
            OpenLongPopUp(OpenscreenInfo);

        }
        public void SaveButtonClick()
        {
            Debug.Log("Save");
        }
        #endregion EventListener

        #region Open/Close
        private void OpenShortPopUp(string _popUpName, string nameField, string descriptionField, Sprite[] sprites)
        {
            HideOldPopUp();
            OpenUIPopup = UIPopup.GetPopup(_popUpName);

            onPopupButtonClick[0] += MoreButtonClick;
            onPopupButtonClick[1] += SaveButtonClick;
            OpenUIPopup.Data.SetButtonsCallbacks(onPopupButtonClick);
            OpenUIPopup.Data.SetLabelsTexts(nameField, descriptionField);
            if(sprites!=null) OpenUIPopup.Data.SetImagesSprites(sprites);
            OpenUIPopup.Show();
            GameObject obj = OpenUIPopup.gameObject;
        }
        private void OpenShortPopUp(ScreenInfo screenInfo)
        {
            Sprite[] sprites = null;
            List<Texture2D> texs = screenInfo.GetPhotosTexture();
            if (texs != null)
            {
                sprites = new Sprite[texs.Count];
                for (int i = 0; i < texs.Count; i++)
                {
                    sprites[i] = (Sprite.Create(texs[i], new Rect(0.0f, 0.0f, texs[i].width, texs[i].height), new Vector2(0.5f, 0.5f), 100.0f));
                }
            }
            else Debug.Log("screenInfo photos is empty");
            OpenShortPopUp(routePopUpName, screenInfo.title, screenInfo.description, sprites);
        }

        private void OpenLongPopUp(string _popUpName, string nameField, string descriptionField, 
                                    List<string> conveniences, List<string> availability, List<string> other)
        {
            HideOldPopUp();
            OpenUIPopup = UIPopup.GetPopup(_popUpName);

            OpenUIPopup.Data.SetLabelsTexts(nameField, descriptionField, 
                conveniences[0], conveniences[1], conveniences[2],
                availability[0], availability[1], availability[2],
                other[0], other[1], other[2]);

            OpenUIPopup.Show();
            GameObject obj = OpenUIPopup.gameObject;
        }
        private void OpenLongPopUp(ScreenInfo screenInfo)
        {
            OpenLongPopUp(morePopUpName, screenInfo.title, screenInfo.description,
                            screenInfo.conveniences, screenInfo.availability, screenInfo.other);
        }

        private void HideOldPopUp()
        {
            try {
                OpenUIPopup.Hide();
                OpenUIPopup = null;
            }
            catch { return; }
        }
        #endregion Open/Close


    }
}
