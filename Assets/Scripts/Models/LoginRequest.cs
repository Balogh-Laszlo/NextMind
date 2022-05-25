using System;

namespace DefaultNamespace.Models
{
    [Serializable]
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}