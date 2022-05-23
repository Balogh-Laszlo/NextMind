using System;
using System.Collections;
using System.Threading.Tasks;
using DefaultNamespace.Models;
using Models;

namespace API
{

    public interface IAPIHelper
    {
        public IEnumerator Register(RegisterRequest request, Action<RegisterResponse> result);
        public IEnumerator Login(LoginRequest request, Action<LoginResponse> result);
        public IEnumerator LoginWithToken(string token, Action<LoginWithTokenResponse> result);

        public IEnumerator GetRemoteControllers(Action<GetRemoteControllersResponse> result);
        public IEnumerator Ping(string customEvent, string key,Action<string> result);
        public string Token { get; set; }
        public string UserName { get; set; }
        
    }
}