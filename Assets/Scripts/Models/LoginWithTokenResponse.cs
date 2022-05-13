using System;

#nullable enable
namespace Models
{
    [Serializable]
    public class LoginWithTokenResponse
    {
        public string? UserName { get; set; }
        public int Code { get; set; }
        public string Messag { get; set; }
    }
}