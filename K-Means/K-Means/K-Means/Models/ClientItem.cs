using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means.Models
{
    public class ClientItem
    {
        public int ClientId { get; set; }
        public List<float> WineData { get; set; }


        public ClientItem()
        {
            WineData = new List<float>();
        }
    }
}
