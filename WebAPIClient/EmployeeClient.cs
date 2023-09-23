using Intuit.Ipp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPIClient.Model;
using Task = System.Threading.Tasks.Task;

namespace WebAPIClient
{
    internal class EmployeeClient
    {
        static Uri uri = new Uri("http://localhost:5122/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }
        }
        public static async Task CallGetAllEmployeeJson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //httpget;
                HttpResponseMessage response = await client.GetAsync("GetEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach (EmpViewModel emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName}," +
                            $"{emp.LastName},{emp.Title},{emp.BirthDate},{emp.HireDate},{emp.City},{emp.ReportsTo}");
                    }
                }
            }
        }
        public static async Task AddnewEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel employee = new EmpViewModel()
                {
                    FirstName = "William",
                    LastName = "John",
                    City = "Nyc",
                    BirthDate = new DateTime(1980, 01, 01),
                    HireDate = new DateTime(2000, 01, 01),
                    Title = "Manager"
                };
                var myContent = JsonConvert.SerializeObject(employee);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //httppost:
                HttpResponseMessage response = await client.PostAsync("AddNewEmployees", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
        public static async Task UpdateEmployee(int id,EmpViewModel employee)
        {
            using (var client= new HttpClient())
            {
                client.BaseAddress = uri;       
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel updatedEmployee = new EmpViewModel()
                {
                    EmpId = 9,
                    FirstName = "Rya",
                    LastName = "Joe",
                    City = "Cdm",
                    BirthDate = new DateTime(1979, 1, 21),
                    HireDate = new DateTime(2001, 01, 01),
                    Title = "Lead Account",
                    ReportsTo = null
                };
                var myContent = JsonConvert.SerializeObject(employee);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpPut or HttpPatch:
                HttpResponseMessage response = await client.PutAsync($"UpdateEmployee?id={id}", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync($"{response.StatusCode}");
                }
            }
        }
        public static async Task DeleteEmployee(int empId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                // HttpDelete:
                HttpResponseMessage response = await client.DeleteAsync($"DeleteEmployee?id={empId}"); // Assuming the endpoint is named "DeleteEmployee"
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync($"{response.StatusCode}");
                }
            }
        }
    }
}
