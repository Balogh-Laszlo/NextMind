using System.Net;
using UnityEngine;

namespace DefaultNamespace
{
    public class Utils
    {
        public static void ping(string url)
        {
            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(url);
                Debug.Log(response);
            }
        }
    }
}