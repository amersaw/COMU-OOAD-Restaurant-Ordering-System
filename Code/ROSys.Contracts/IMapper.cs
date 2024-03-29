﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Contracts
{
    public interface IMapper
    {
        object Get(Guid id);

        List<object> GetAll();

        bool Put(object obj);
    }
}
