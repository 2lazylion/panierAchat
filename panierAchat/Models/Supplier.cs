using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panierAchat.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public Address Address { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public ICollection<Product> Produits { get; set; }
    }
}
