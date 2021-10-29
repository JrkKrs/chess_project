
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class login : MonoBehaviour
{

    string userToken = "";
    public GameObject UsernameGame;
    public GameObject PasswdGameObject;
    private string username, password;

    public string UserToken
    {
        get => userToken;
        set
        {
            userToken = value;
            
        }
    }

    public void LoginButton()
    {
        username = UsernameGame.GetComponent<InputField>().text;
        password = PasswdGameObject.GetComponent<InputField>().text;

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("passwd", password);

        StartCoroutine(ApiClient.Instance.Upload(form));
        // ApiClient.Instance.Upload(form);

        UserToken = ApiClient.ApiOutput;
        Debug.Log("PACZAJ");
        Debug.Log(ApiClient.ApiOutput);
        Debug.Log(UserToken);
        Debug.Log("PACZAJ");

        PlayerPrefs.SetInt("isLogin", 1);
        PlayerPrefs.SetString("token", UserToken);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode.Tab)))
        {
            if (UsernameGame.GetComponent<InputField>().isFocused)
            {
                PasswdGameObject.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (username != "" && password != "")
                LoginButton();
        }

        

        
    }
}
