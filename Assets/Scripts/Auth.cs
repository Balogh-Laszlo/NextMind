using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using API;
using DefaultNamespace.Models;
using UnityEngine;


public class Auth : MonoBehaviour
{
    // Start is called before the first frame update
    public IAPIHelper api;
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
        LoginRequest request = new LoginRequest();
        request.UserName = "string";
        request.Password = "string";

        StartCoroutine(api.Login(request, (response) =>
        {
            Debug.Log(response.Code + " " + response.Token);
            api.Token = response.Token;
        }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
