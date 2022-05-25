using System;

namespace Models
{
    [Serializable]
    public class ControlToClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URl { get; set; }
        public Key IFTTTKey { get; set; }
    }
}