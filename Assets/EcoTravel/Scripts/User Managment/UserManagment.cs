using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Doozy;
using Doozy.Engine.UI;
using Doozy.Engine.Nody;

public class UserManagment : MonoBehaviour
{

    [SerializeField] private GameObject regView;
    [SerializeField] private GameObject FirstView;
    [SerializeField] private GraphController graphController;
    public IEnumerator Login(string mail, string password)
    {
        AuthenticateModel user = new AuthenticateModel();
        user.Mail = mail;
        user.Password = password;

        var json = JsonUtility.ToJson(user, true);
        Debug.Log(json);
        using UnityWebRequest www = new UnityWebRequest(WebConfig.url +  "user/authenticate", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            graphController.Graph.SetActiveNodeByName("FirstMeet1");
            Debug.Log("Form upload complete! " + www.downloadHandler.text);
        }

    }

    public IEnumerator Register(string fullName, string mail, string password, string sex, string birthday)
    {
        UserRegister user = new UserRegister();
        user.Mail = mail;
        user.Fullname = fullName;
        user.Sex = sex;
        user.Birthday = birthday;
        user.Password = password;

        var json = JsonUtility.ToJson(user, true);
        Debug.Log(json);

        using UnityWebRequest www = new UnityWebRequest(WebConfig.url + "user/register", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            graphController.Graph.SetActiveNodeByName("FirstMeet1");
            Debug.Log("Form upload complete!");
        }
    }

}
