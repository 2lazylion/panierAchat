using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace panierAchat.Models
{
    public class Credentials
    {
        public long CredentialsId { get; set; }
        
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public ICollection<Customer> Customers { get; set; }
    }
}
