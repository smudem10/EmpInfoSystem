using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Employee.BAL;
using Newtonsoft.Json;


namespace EmpInfoSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getDetails(int ?id)
        {
            if (id > 0)
            {
                return GetEmployeebyId(id.Value);
            }
            else
            {
                return GetEmployees();
            }
                
        }

        private void InitializeHttpClient(ref HttpClient httpClient)
        {
            httpClient.BaseAddress = this.Request.Url;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        public ActionResult GetEmployeebyId(int id)
        {
            var client = new HttpClient();
            InitializeHttpClient(ref client);
            client.Timeout = TimeSpan.FromMinutes(10);

            Task<HttpResponseMessage> response = client.GetAsync("api/Employeees/" + id.ToString());
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            if (response.Result.IsSuccessStatusCode)
            {
                var EmpResponse = response.Result.Content.ReadAsStringAsync().Result;

                list = JsonConvert.DeserializeObject<List<EmployeeDTO>>(EmpResponse);
            }

            return View("Employees", list);

        }
        public ActionResult GetEmployees()
        {
            var client = new HttpClient();
            InitializeHttpClient(ref client);
            client.Timeout = TimeSpan.FromMinutes(10);

            Task<HttpResponseMessage> response = client.GetAsync("api/Employeees/");
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            if (response.Result.IsSuccessStatusCode)
            {
                var EmpResponse = response.Result.Content.ReadAsStringAsync().Result;

                list = JsonConvert.DeserializeObject<List<EmployeeDTO>>(EmpResponse);
            }

            return View("Employees", list);
        }

    }
}