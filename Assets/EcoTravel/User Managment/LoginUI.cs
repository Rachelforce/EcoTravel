using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    [SerializeField] private UserManagment userManagment;
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;

    public void Login()
    {
        if ((login.text != "") && (password.text != ""))
        {
            StartCoroutine(userManagment.Login(login.text, password.text));
        }
    }
}
