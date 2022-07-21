using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using routeSystem;
using UnityEngine.UI;

namespace Custom.UI.System
{
    public class PhotoScrolPanel : MonoBehaviour
    {
        [SerializeField] GameObject photoScrolPrefab;
        public void OpenNewPopUp(ScreenInfo screenInfo)
        {
            Texture2D texture2Ds;
            //foreach(Photo photo in screenInfo.photos)
            //{
            //    texture2Ds = photo.GetTextureFromPath();
            //    CreatePanel(texture2Ds);
            //}
        }
        private void CreatePanel(Texture2D texture2Ds)
        {
            var instance = Instantiate(photoScrolPrefab);
            Sprite sprite = Sprite.Create(texture2Ds, new Rect(0.0f, 0.0f, texture2Ds.width, texture2Ds.height), new Vector2(0.5f, 0.5f), 100.0f);
            instance.GetComponent<Image>().sprite = sprite;
        }
    }
}
