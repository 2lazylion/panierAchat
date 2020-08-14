using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace panierAchat.Models
{
    public class Credentials
    {
        public long CredentialsId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public ICollection<Customer> Customers { get; set; }
    }
}
