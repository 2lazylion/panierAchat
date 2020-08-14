using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace panierAchat.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public Supplier Supplier { get; set; }
        public string Nom { get; set; }
        public Decimal PrixUnitaire { get; set; }
        public int QuantiteStock { get; set; }
        public string Description { get; set; }
        public string Marque { get; set; }
        public string Categorie { get; set; }
        //public ICollection<Orderline> Orderlines { get; set; }
    }
}
