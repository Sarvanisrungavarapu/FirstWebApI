﻿using FirstWebAPI.Models;

namespace FirstWebAPI.Model
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmployeeId(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            //Employee employee = _context.Employees.Find(id);
            //if (employee == null)
            //{
            //    throw new ArgumentException("Customer not found.");
            //}
            _context.Employees.Attach(updatedEmployee);
            // Save changes to the database
            _context.SaveChanges();
            return updatedEmployee;
        }
        public int DeleteEmployee(int id)
        {
            //Employee employee = _context.Employees.Find(id);
            //if (employee == null)
            //{
            //    throw new ArgumentException("Customer not found.");
            //}
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            return _context.SaveChanges();
        }
    }
}
