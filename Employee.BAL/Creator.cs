using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.BAL
{
    abstract class Creator
    {
        public abstract IEmployee FactoryMethod(string contractType);
    }
}
