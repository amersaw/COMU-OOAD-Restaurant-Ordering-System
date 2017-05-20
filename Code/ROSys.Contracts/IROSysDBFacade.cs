using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Contracts
{
    public interface IROSysDBFacade
    {

        bool Put(object obj);

        object Get(Guid id, Type type);

        List<object> GetAll(Type type);
        
    }
}
