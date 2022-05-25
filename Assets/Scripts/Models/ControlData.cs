using System;
using JetBrains.Annotations;

namespace Models
{
    [Serializable]
    public class ControlData
    {
        public int ControlId { get; set; } 
        public int IFTTTKeyId { get; set; }
        public string ControlName { get; set; } = String.Empty;
        public string URl { get; set; } = String.Empty;
        public string IFTTTKey { get; set; } = String.Empty;
    }
}