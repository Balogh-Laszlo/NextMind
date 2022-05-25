using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class PageData
    {
        public int Index{ get; set; }
        public List<ControlData> Controls { get; set; } = new List<ControlData>();
    }
}