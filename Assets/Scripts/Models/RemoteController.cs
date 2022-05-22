using System.Collections.Generic;

namespace Models
{

    public class RemoteController
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();
    }
}