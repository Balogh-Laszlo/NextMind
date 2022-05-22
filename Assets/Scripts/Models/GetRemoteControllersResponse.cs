using System.Collections.Generic;

namespace Models
{

    public class GetRemoteControllersResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<RemoteController> RemoteControllers { get; set; } = new List<RemoteController>();
    }
}