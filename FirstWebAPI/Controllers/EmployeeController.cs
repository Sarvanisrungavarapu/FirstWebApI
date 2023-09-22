using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> GetAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            var empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId =emp.EmployeeId,
                    FirstName=emp.FirstName,
                    LastName=emp.LastName,
                    BirthDate=(DateTime)emp.BirthDate,
                    HireDate=(DateTime)emp.HireDate,
                    Title=emp.Title,
                    City=emp.City,
                    ReportsTo=(int)emp.ReportsTo
                }
                ).ToList();
            return empList;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
        [HttpPut]
        public Employee EditEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            updatedEmployee.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployee);
            return savedEmployee;
        }
        [HttpDelete]
        public Employee DeleteEmployee(int id)
        {
            return _repositoryEmployee.DeleteEmployee(id);
        }
    }
}
}
