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
    public IEnumerator Login(string login, string password)
    {
        AuthenticateModel user = new AuthenticateModel();
        user.Login = login;
        user.Password = password;

        var json = JsonUtility.ToJson(user);

        using (UnityWebRequest www = new UnityWebRequest(WebConfig.url + "/users/authenticate", "POST"))
        {
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

    }

   public  IEnumerator Register(string login, string mail, string password, string sex, string birthday)
    {
        UserRegister user = new UserRegister();
        user.Login = login;
        user.Mail = mail;
        user.Sex = sex;
        user.Birthday = birthday;
        user.password = password;
     
        var json = JsonUtility.ToJson(user);
        
        

        using (UnityWebRequest www = new UnityWebRequest(WebConfig.url + "/users/register", "POST"))
        {
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
 
}
