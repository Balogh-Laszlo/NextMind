using System;

namespace DefaultNamespace.Models
{
    [Serializable]
    public class RegisterResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}