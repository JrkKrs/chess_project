using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
    public static string apiOutput = "";

    private static ApiClient _instance;
    public GameObject LoginErr;

    public static string ApiOutput
    {
        get => apiOutput;
        set
        {
            apiOutput = value;

        }
    }

    public static ApiClient Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ApiClient>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(ApiClient).Name;
                    _instance = go.AddComponent<ApiClient>();
                    DontDestroyOnLoad(go);
                }
            }
    
            return _instance;
        }
    }
    
    public IEnumerator Get(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                LoginErr.GetComponent<Text>().text = "isNetworkError";
                LoginErr.GetComponent<Text>().color = Color.white;
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = Encoding.UTF8.GetString(www.downloadHandler.data);
                }
            }
        }
    }
    
    public IEnumerator Post(string url, string json)
    {
    
        using (UnityWebRequest www = UnityWebRequest.Post(url, json))
        {
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            yield return www.SendWebRequest();
    
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                LoginErr.GetComponent<Text>().text = "isNetworkError";
                LoginErr.GetComponent<Text>().color = Color.white;
            }
    
            else
            {
                if (www.isDone)
                {
                    string jsonResult = Encoding.UTF8.GetString(www.downloadHandler.data);
    
                }
            }
        }
    }

    public IEnumerator Upload(WWWForm form)
    {
        // WWWForm form = new WWWForm();
        // form.AddField("myField", "myData");

        UnityWebRequest www = UnityWebRequest.Post("https://chess.jrk.ovh/WebService.asmx/LoginResult", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            // LoginErr.GetComponent<Text>().text = "isNetworkError";
            // LoginErr.GetComponent<Text>().color = Color.white;
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.data.ToString());
            Debug.Log(www.downloadHandler.text);

            string apiReturn = www.downloadHandler.text;


            string pattern = @"(<\?.*|<str.*\"">|<\/string>|\n)";
            string substitution = @"";
            RegexOptions options = RegexOptions.Multiline;

            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(apiReturn, substitution);
            Debug.Log("resultAPI");
            Debug.Log(result);
            Debug.Log("resultAPI");
            ApiOutput = result;
            PlayerPrefs.SetString("tmp_api", result);

        }
    }
}
