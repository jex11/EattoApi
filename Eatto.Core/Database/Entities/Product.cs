using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatto.Core.Database.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid FoodHubId { get; set; }
        public FoodHub FoodHub { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
