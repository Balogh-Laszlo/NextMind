using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class AddControllerRequest
    {
        public string Token { get; set; }
        public string ControllerName { get; set; }
        public List<PageData> Pages { get; set; } = new List<PageData>();
    }
}