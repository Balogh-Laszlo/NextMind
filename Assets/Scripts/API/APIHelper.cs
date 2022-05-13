using System;
using System.Collections;
using System.Threading.Tasks;
using DefaultNamespace.Models;
using Models;
using Newtonsoft.Json;
using Utils;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{

    public class APIHelper : IAPIHelper
    {


        public string Token { get; set; } = "";
        public string UserName { get; set; } = "";
        private static APIHelper _instance;

        public static APIHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new APIHelper();
                }

                return _instance;
            }
        }

        private APIHelper()
        {
        }
        
        public IEnumerator LoginWithToken(string token, Action<LoginWithTokenResponse> result)
        {
            UnityWebRequest www = UnityWebRequest.Get(Constants.BackEndUrl+Constants.AuthUrl+"login/"+Token);

            yield return www.SendWebRequest();

            result(JsonConvert.DeserializeObject<LoginWithTokenResponse>(www.downloadHandler.text));
        }


        public IEnumerator Register(RegisterRequest request, Action<RegisterResponse> response)
        {
            WWWForm form = new WWWForm();
            form.AddField("UserName", request.UserName);
            form.AddField("Password", request.Password);
            form.AddField("ConfirmPassword", request.ConfirmPassword);

            UnityWebRequest www = UnityWebRequest.Post(Constants.BackEndUrl + Constants.AuthUrl + "register", form);

            yield return www.SendWebRequest();
            
            response(JsonConvert.DeserializeObject<RegisterResponse>(www.downloadHandler.text));
            
        }

        public IEnumerator Login(LoginRequest request, Action<LoginResponse> result)
        {
            WWWForm form = new WWWForm();
            form.AddField("UserName", request.UserName);
            form.AddField("Password",request.Password);
            
            UnityWebRequest www = UnityWebRequest.Post(Constants.BackEndUrl+Constants.AuthUrl+"login", form);

            yield return www.SendWebRequest();

            result(JsonConvert.DeserializeObject<LoginResponse>(www.downloadHandler.text));
        }
    }
}