using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.BAL
{
    interface IEmployee: IDisposable
    {
        //EmployeeDTO GetEmployeeByID(int empID);

        //List<EmployeeDTO> getEmployees();

        decimal getAnnualSalary(decimal salary);
    }
}
