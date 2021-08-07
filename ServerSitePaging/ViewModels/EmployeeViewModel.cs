using ServerSitePaging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSitePaging.ViewModels
{
    
    public class EmployeeListViewModel
    {
        public ICollection<Employee> EmployeList { get; set; }
    }
    
    public class EmployeeViewModel
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public DateTime StartDate { get; set; }
        public double Salary { get; set; }
    }
}
