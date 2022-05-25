using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class GetControlsResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ControlToClient> controls { get; set; }
    }
}