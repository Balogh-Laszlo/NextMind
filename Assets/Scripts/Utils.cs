using System.Net;
using UnityEngine;

namespace DefaultNamespace
{
    public class Utils
    {
        private const string baseURL = "https://maker.ifttt.com/trigger/";
        private const string middelURL = "/json/with/key/";
        public static void ping(string customEvent, string IFTTTKey)
        {
            using (var wb = new WebClient())
            {
                string url = baseURL + customEvent + middelURL + IFTTTKey;
                var response = wb.DownloadString(url);
                Debug.Log(response);
            }
        }
    }
}