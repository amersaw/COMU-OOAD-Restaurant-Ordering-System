using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Model
{
    public class Table : IEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int NumberOfPerson { get; set; }
    }
}
