using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.WebClient.Models
{
    public class Personel
    {
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Position { get; set; }
    }
}
