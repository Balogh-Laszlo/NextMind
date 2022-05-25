using System;

namespace Models
{
    [Serializable]
    public class Key
    {
        public int Id { get; set; }
        public string iftttKey { get; set; } = string.Empty;
    }
}