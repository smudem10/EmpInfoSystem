using Employee.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.BAL
{
    public class EmployeeBAL
    {
        Creator concrete = new ConcreteCreator();

        public EmployeeDTO GetEmployeeByID(int empID)
        {
            EmployeeRepository employee = new EmployeeRepository();
            Task<EmployeeBO> task = employee.GetEmployeeByID(empID);
            IEmployee empl= concrete.FactoryMethod(task.Result.contractTypeName);
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                contractTypeName = task.Result.contractTypeName,
                id = task.Result.id,
                name = task.Result.name,
                roleDescription = task.Result.roleDescription,
                roleId = task.Result.roleId,
                roleName = task.Result.roleName,
                annualSalary = empl.getAnnualSalary(task.Result.hourlySalary)
            };
            return employeeDTO;
        }

        public List<EmployeeDTO> getEmployees()
        {
            EmployeeRepository employee = new EmployeeRepository();
            Task<List<EmployeeBO>> task = employee.GetEmployees();
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            foreach (var item in task.Result)
            {
                IEmployee empl = concrete.FactoryMethod(item.contractTypeName);

                EmployeeDTO employeeDTO = new EmployeeDTO()
                {
                    contractTypeName = item.contractTypeName,
                    id = item.id,
                    name = item.name,
                    roleDescription = item.roleDescription,
                    roleId = item.roleId,
                    roleName = item.roleName,
                    annualSalary = empl.getAnnualSalary(item.monthlySalary)
                };

            }

            return employees;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EmployeeBAL() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
