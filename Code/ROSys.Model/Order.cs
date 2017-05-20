using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Model
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public DateTime TimeDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSubmited { get; set; }

    }
}
