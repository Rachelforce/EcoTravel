using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Custom.UI.System;
using routeSystem;
public delegate void OpenRoute(int index);
public class PrefadLinks : MonoBehaviour
{
    public List<TextMeshProUGUI> Texts;
    public List<Image> Images;
    public List<Button> Buttons;
    

    public void SetText(List<string> inputText)
    {
        for(int i = 0; i < inputText.Count; i++)
        {
            Texts[i].text = inputText[i];
        }
    }
    public void SetButtonsCallbacks( OpenRoute callbacks, int index)
    {
        Buttons[0].onClick.AddListener(delegate { callbacks(index); });
       
    }

}
