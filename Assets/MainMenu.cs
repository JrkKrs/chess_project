using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoginMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void QuickGame()
    {
        Application.Quit();
    }


    public GameObject loginButton;
    void Start()
    {
        string token = PlayerPrefs.GetString("token");
        Debug.Log(token);
        if (token != "")
        {
            loginButton.GetComponent<Text>().text = "Logout";
        }
    }

}
