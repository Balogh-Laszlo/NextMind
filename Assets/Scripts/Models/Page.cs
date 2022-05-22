using System.Collections.Generic;

namespace Models
{

    public class Page
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public List<ControlDB> Controls { get; set; } = new List<ControlDB>();
    }
}