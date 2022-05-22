using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using API;
using DefaultNamespace.Models;
using Models;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;


public class Auth : MonoBehaviour
{
    // Start is called before the first frame update
    private IAPIHelper api;
    
    //Login
    public TMP_InputField userNameInput;
    public TMP_InputField passwordInput;
    public GameObject errorMessage;
    private TMP_Text errorMessageText;
    public GameObject loginObject;
    
    //Register
    public GameObject registerObject;
    public TMP_InputField userNameInputReg;
    public TMP_InputField passwordInputReg;
    public TMP_InputField confirmPasswordInputReg;
    public TMP_Text regSuccessfulText;
    void Start()
    {
        // Dependency injection
        api = APIHelper.Instance;
        errorMessageText = errorMessage.GetComponent<TMP_Text>();
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

    public void OnLoginPressed()
    {
        Debug.Log("Login pressed");
        string username = userNameInput.text;
        string password = passwordInput.text;
        if ((username != null && password != null) && (username.Length >= 1 && password.Length >= 1)){
            
            Debug.Log(username);
            var loginRequest = new LoginRequest();
                loginRequest.UserName = username;
                loginRequest.Password = password;

                StartCoroutine(api.Login(loginRequest, (response) =>
                {
                    if (response != null)
                    {
                        if (response.Code == 200)
                        {
                            errorMessage.SetActive(false);
                            api.Token = response.Token;
                            api.UserName = username;
                            DontDestroyOnLoad(GameObject.Find("NeuroManager"));
                            SceneManager.LoadScene(1);
                        }
                        else
                        {
                            errorMessage.SetActive(true);

                            errorMessageText.text = response.Message;
                        }
                    }
                    else
                    {
                        errorMessage.SetActive(true);
                        errorMessageText.text = "Something went wrong. Try again later!";
                    }
                }));
        }
        else
        {
            errorMessage.SetActive(true);
            errorMessageText.text = "Missing username or password!";
        }
        
    }

    public void OnSignUpPressed()
    {
        errorMessage.SetActive(false);
        loginObject.SetActive(false);
        registerObject.SetActive(true);
        
    }

    public void OnBackPressed()
    {
        errorMessage.SetActive(false);
        loginObject.SetActive(true);
        registerObject.SetActive(false);
    }

    public void OnRegisterPressed()
    {
        string username = userNameInputReg.text;
        string password = passwordInputReg.text;
        string confirmPassword = confirmPasswordInputReg.text;

        if (string.IsNullOrWhiteSpace(username))
        {
            errorMessageText.text = "Missing username";
            errorMessage.SetActive(true);
        }

        else if(string.IsNullOrEmpty(password))
        {
            errorMessage.SetActive(true);
            errorMessageText.text = "Missing password";
        }
        else if (password.Length < 5)
        {
            errorMessage.SetActive(true);
            errorMessageText.text = "Password needs to be at least 6 characters long!";
        }

        else if (string.IsNullOrEmpty(confirmPassword))
        {
            errorMessage.SetActive(true);
            errorMessageText.text = "Missing confirmation password";
        }

        else if (confirmPassword != password)
        {
            errorMessage.SetActive(true);
            errorMessageText.text = "The two passwords are not the same!";
        }
        else
        {
            var request = new RegisterRequest();
            request.UserName = username;
            request.Password = password;
            request.ConfirmPassword = confirmPassword;

            StartCoroutine(api.Register(request, (response) =>
            {
                if (response != null)
                {
                    if (response.Code == 200)
                    {
                        errorMessage.SetActive(false);
                        registerObject.SetActive(false);
                        loginObject.SetActive(true);
                        regSuccessfulText.alpha = 1;
                        StartCoroutine(Animations.FadeTextToZeroAlpha(3f, regSuccessfulText));

                    }
                    else
                    {
                        errorMessage.SetActive(true);
                        errorMessageText.text = response.Message;
                    }
                }
                else
                {
                    errorMessage.SetActive(true);
                    errorMessageText.text = "Something went wrong. Try again later!";
                }
            }));
        }


    }
    

}
