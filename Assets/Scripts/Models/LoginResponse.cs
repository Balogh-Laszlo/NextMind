using System;
using JetBrains.Annotations;

namespace DefaultNamespace.Models
{


    [Serializable]
    public class LoginResponse
    {
        [CanBeNull] public string UserName { get; set; }
        [CanBeNull] public string Token { get; set; }
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}