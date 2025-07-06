using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatto.Core.Database.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public List<Order> Orders { get; set; } = new();
    }

}
