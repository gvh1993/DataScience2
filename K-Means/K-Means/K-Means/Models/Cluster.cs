using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means.Models
{
    public class Cluster
    {
        public List<WineItem> WineData{ get; set; }
        public WineItem Centroid { get; set; }

        public Cluster()
        {
            WineData = new List<WineItem>();
            Centroid = new WineItem();
        }
    }
}
