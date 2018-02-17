using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.DAL
{
    public interface IEmployeeRepository : IDisposable
    {

        Task<List<EmployeeBO>> GetEmployees();
        Task<EmployeeBO> GetEmployeeByID(int empId);
    }
}
