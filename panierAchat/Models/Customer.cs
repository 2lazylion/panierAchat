using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace panierAchat.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public Credentials Credentials { get; set; }
        
        [Required]
        public Address Address { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Telephone { get; set; }
        public ICollection<ShippingOrder> ShippingOrders { get; set; }
    }
}
