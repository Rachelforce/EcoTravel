using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RiegisterUI : MonoBehaviour
{
    [SerializeField] private UserManagment userManagment;
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField mail;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField r_password;
    [SerializeField] private TMP_InputField sex;
    [SerializeField] private TMP_InputField d_birthday;
    [SerializeField] private TMP_InputField m_birthday;
    [SerializeField] private TMP_InputField y_birthday;
    public void Register()
    {
        if ((login.text != "") && (password.text != "") && (mail.text.Contains("@")))
        {
            if (password.text == r_password.text)
            {
                string birthday = $"{d_birthday.text}.{m_birthday.text}.{y_birthday.text}";
                StartCoroutine(userManagment.Register(login.text,mail.text,password.text,sex.text, birthday));
                
            }
        }
    }

}
