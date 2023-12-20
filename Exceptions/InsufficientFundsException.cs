﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Exceptions
{
    internal class InsufficientFundsException:ApplicationException
    {

        public InsufficientFundsException() { }
        public InsufficientFundsException(string message) : base(message) { }
    }
}