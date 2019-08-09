﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WepConnect : MonoBehaviour
{
    [SerializeField]
    string connectHttp = "";

    static WepConnect instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Call(string adress)
    {
        UnityWebRequest wwwUrl = new UnityWebRequest(adress);

        yield return wwwUrl.SendWebRequest();

        ErrorException(wwwUrl);
    }

    IEnumerator Call(string adress, WWWForm form)
    {
        UnityWebRequest wwwUrl = UnityWebRequest.Post(adress, form);

        yield return wwwUrl.SendWebRequest();

        ErrorException(wwwUrl);
    }
    
    public void LogIn()
    {
        WWWForm form = new WWWForm();

        GameObject id = GameObject.FindGameObjectWithTag("ID");
        GameObject password = GameObject.FindGameObjectWithTag("Password");

        string idText = id.GetComponent<Text>().text;
        string passwordText = password.GetComponent<Text>().text;

        form.AddField("username", idText);
        form.AddField("password", passwordText);

        StartCoroutine(Call(connectHttp + "/auth/login", form));
    }
    
    void ErrorException(UnityWebRequest wwwUrl)
    {
        if (wwwUrl.isNetworkError || wwwUrl.isHttpError)
        {
            Debug.Log(wwwUrl.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
