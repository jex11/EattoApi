using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatto.Core.Database.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime PlacedAt { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> Items { get; set; } = new();
    }

}
