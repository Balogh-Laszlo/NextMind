using System;

namespace Models
{
    [Serializable]
    public class AddControllerResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public RemoteController Controller { get; set; }
    }
}