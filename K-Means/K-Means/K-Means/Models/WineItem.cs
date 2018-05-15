using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means.Models
{
    public class WineItem
    {
        public List<float> WineData { get; set; }


        public WineItem()
        {
            WineData = new List<float>();
        }
    }
}
