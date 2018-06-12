using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means.Models
{
    public class WineItem
    {
        public int WineOfferId { get; set; }
        public List<ClientItem> ClientsOfferTaken { get; set; }

        public WineItem()
        {
            ClientsOfferTaken = new List<ClientItem>();    
        }
    }
}
