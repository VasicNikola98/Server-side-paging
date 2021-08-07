using ServerSitePaging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSitePaging.Services
{
    public interface IEmployee
    {
        void AddEmployee(Employee newEmployee);
        List<Employee> GetEmployee(int start, int length, string searchTerm);
        int TotalRecord();

    }
}
