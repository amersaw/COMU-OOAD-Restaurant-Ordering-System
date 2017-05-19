using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var Facade = DBFacadeFactory.Instance;


            Model.Customer customer = new Model.Customer()
            {
                FirstName = "Amer",
                LastName = "Sawan",
                Id = Guid.NewGuid()
            };

            var res = Facade.Put(customer);

            var allCustomers = Facade.GetAll(typeof(Model.Customer));

        }
    }
}
