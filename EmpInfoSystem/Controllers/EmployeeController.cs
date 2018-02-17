using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee.BAL;

namespace EmpInfoSystem.Controllers
{
    
    public class EmployeeesController : ApiController
    {
        // GET api/<controller>
        
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            EmployeeBAL employeeBAL = new EmployeeBAL();
            List<EmployeeDTO> emps = employeeBAL.getEmployees();
            return emps;
            
        }

        // GET api/<controller>/5
        public EmployeeDTO Get(int id)
        {
            EmployeeBAL employeeBAL = new EmployeeBAL();
            EmployeeDTO  emp= employeeBAL.GetEmployeeByID(id);
            return emp;
        }

    }
}