using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Login()
    {
        if (WebConnect.Instance)
            WebConnect.Instance.LogIn();
    }

    public void CreateAccount()
    {
        if (WebConnect.Instance)
            WebConnect.Instance.CreateAccount();
    }
}
