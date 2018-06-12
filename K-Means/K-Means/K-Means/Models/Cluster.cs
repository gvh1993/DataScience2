using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means.Models
{
    public class Cluster
    {
        public List<ClientItem> ClientItems{ get; set; }
        public List<WineItem> WineItems { get; set; }
        public ClientItem Centroid { get; set; }

        public Cluster()
        {
            ClientItems = new List<ClientItem>();
            Centroid = new ClientItem();
            WineItems = new List<WineItem>();
        }
    }
}
