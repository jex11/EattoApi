using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatto.Core.Database.Entities
{
    public class FoodHub
    {
        [Key]
        public Guid FoodHubId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
