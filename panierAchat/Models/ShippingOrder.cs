using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panierAchat.Models
{ 
    public class ShippingOrder
    {
        public long ShippingOrderId { get; set; }
        public Customer Customer { get; set; }
        public Decimal Total { get; set; }
        public ICollection<Orderline> Orderlines { get; set; }

        public ShippingOrder() 
        {
            // creation du ShippingOrderId?

            Orderlines = new List<Orderline>();
        }

        public ShippingOrder(Customer customer)
        {
            // creation du ShippingOrderId?

            this.Customer = customer;
            Orderlines = new List<Orderline>();

        } 
    }
}
