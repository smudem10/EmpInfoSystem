using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL
{
    public class EmployeeRepository:IEmployeeRepository,IDisposable
    {


        private void InitializeHttpClient(ref HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<EmployeeBO>> GetEmployees()
        {
            List<EmployeeBO> EmpInfo = new List<EmployeeBO>();
            var client = new HttpClient();
            InitializeHttpClient(ref client);
            HttpResponseMessage response = await client.GetAsync("api/Employees/");
            if (response.IsSuccessStatusCode)
            {
                var EmpResponse = response.Content.ReadAsStringAsync().Result;
                EmpInfo = JsonConvert.DeserializeObject<List<EmployeeBO>>(EmpResponse);

            }

            return EmpInfo;
        }

        public async Task<EmployeeBO> GetEmployeeByID(int empID)
        {
            EmployeeBO EmpInfo = new EmployeeBO();
            var client = new HttpClient();
            InitializeHttpClient(ref client);
            HttpResponseMessage response = await client.GetAsync("api/Employees/" + empID.ToString());
            if (response.IsSuccessStatusCode)
            {
                var EmpResponse = response.Content.ReadAsStringAsync().Result;
                EmpInfo = JsonConvert.DeserializeObject<EmployeeBO>(EmpResponse);

            }
            return EmpInfo;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   // Disposable Objects
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
