using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class Page
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public List<ControlToClient> Controls { get; set; } = new List<ControlToClient>();
    }
}