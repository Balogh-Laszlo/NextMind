using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace.Models;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public class Utils1
    {
        private const string baseURL = "https://maker.ifttt.com/trigger/";
        private const string middelURL = "/json/with/key/";
        private const string backendURL = "https://localhost:7053/api/";
        private const string authControllerURL = "Auth";
        


        public static async Task<RegisterResponse> register(RegisterRequest request)
        {
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(request);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(backendURL + authControllerURL + "/register", httpContent);

            Debug.Log(response.Content);
            Debug.Log(response.StatusCode);
            return null;
        }
    }
}