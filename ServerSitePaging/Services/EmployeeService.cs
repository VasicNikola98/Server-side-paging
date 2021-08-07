
using ServerSitePaging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSitePaging.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly MyDbContext _context;

        public EmployeeService(MyDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee newEmployee)
        {
            _context.Add(newEmployee);
            _context.SaveChanges();
        }

        public List<Employee> GetEmployee(int start, int length, string searchTerm)
        {
            var employeesList = _context.Employees.ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employeesList = employeesList.Where(x => x.FirstName.ToLower().Contains(searchTerm.ToLower())
                || x.LastName.ToLower().Contains(searchTerm.ToLower()) || x.Office.ToLower().Contains(searchTerm.ToLower())
                || x.Position.ToLower().Contains(searchTerm.ToLower())).ToList();

            }

            employeesList = employeesList.Skip(start).Take(length).ToList();

            return employeesList;
        }

        public int TotalRecord()
        {
            return _context.Employees.Count();
        }
    }
}
