﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.Model
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime DateTime { get; set; }
        
    }
}