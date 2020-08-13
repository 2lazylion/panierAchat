using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace panierAchat.Models
{
    public class Address
    {

        public int AddressId { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Rue { get; set; }

        [Required]
        public string CodePostal { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
