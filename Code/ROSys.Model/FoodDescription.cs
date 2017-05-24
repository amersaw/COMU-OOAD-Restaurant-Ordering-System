using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Model
{
    public class FoodDescription :IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public double Quantity { get; set; }
        public QuantityUnit QuantityUnit { get; set; }
    }
}
