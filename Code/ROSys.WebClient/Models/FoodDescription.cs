using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.WebClient.Models
{
    public class FoodDescription 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public double Quantity { get; set; }
        public QuantityUnit QuantityUnit { get; set; }
        public FoodDescription(Model.FoodDescription fd)
        {
            this.Id = fd.Id;
            this.Name = fd.Name;
            this.Description = fd.Description;
            this.Category = fd.Category;
            this.Price = fd.Price;
            this.Quantity = fd.Quantity;
            this.QuantityUnit = (QuantityUnit)fd.QuantityUnit;
        }
    }
}
