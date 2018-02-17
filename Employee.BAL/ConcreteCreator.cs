using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.BAL
{
    class ConcreteCreator : Creator
    {
        public override IEmployee FactoryMethod(string type)
        {
            switch (type)
            {
                case "HourlySalaryEmployee": return new HourlyEmployee();
                case "MonthlySalaryEmployee": return new MonthlyEmployee();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
