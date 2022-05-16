using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using API;
using DefaultNamespace.Models;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Auth : MonoBehaviour
{
    // Start is called before the first frame update
    private IAPIHelper api;
    public TMP_InputField userNameInput;
    public TMP_InputField passwordInput;
    public GameObject errorMessage;
    void Start()
    {
        // Dependency injection
        api = APIHelper.Instance;
        // RegisterRequest request = new RegisterRequest();
        // request.UserName = "test3";
        // request.Password = "test";
        // request.ConfirmPassword = "test";
        // StartCoroutine(APIHelper.Instance.Register(request, (response) =>
        // {
        //     Debug.Log(response.Code);
        // }));
        // LoginRequest request = new LoginRequest();
        // request.UserName = "string";
        // request.Password = "string";
        //
        // StartCoroutine(api.Login(request, (response) =>
        // {
        //     Debug.Log(response.Code + " " + response.Token);
        //     api.Token = response.Token;
        // }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLoginPressed()
    {
        Debug.Log("Login pressed");
        string username = userNameInput.text;
        string password = passwordInput.text;
        if (username != null && password != null)
        {
            if (username.Length > 0 && password.Length > 0)
            {
                var loginRequest = new LoginRequest();
                loginRequest.UserName = username;
                loginRequest.Password = password;

                StartCoroutine(api.Login(loginRequest, (response) =>
                {
                    if (response.Code == 200)
                    {
                        errorMessage.SetActive(false);
                        api.Token = response.Token;
                        api.UserName = username;
                        SceneManager.LoadScene(1);
                    }
                    else
                    {
                        errorMessage.SetActive(true);
                        var errorMessageText = errorMessage.GetComponent<TMP_Text>();
                        errorMessageText.text = response.Message;
                    }
                }));
            }
        }
        
    }
}
