using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panierAchat.Models
{
    public class Orderline
    {
        public long OrderLineId { get; set; }
        public Product Product { get; set; }
        public ShippingOrder ShippingOrder { get; set; }
        public Int16 Quantite { get; set; }
    }
}
