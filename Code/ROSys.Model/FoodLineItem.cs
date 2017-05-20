using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Model
{
    public class FoodLineItem : IEntity
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public FoodDescription Description { get; set; }
    }
}
