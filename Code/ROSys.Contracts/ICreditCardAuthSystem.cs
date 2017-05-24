using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Contracts
{
    public interface ICreditCardAuthSystem
    {
        bool Initialize();
        bool Authorize(Model.LineOfCredit credit);
    }
}
