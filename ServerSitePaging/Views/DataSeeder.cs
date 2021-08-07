using ServerSitePaging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSitePaging.Views
{
    public class DataSeeder
    {
        private MyDbContext _context;

        public DataSeeder(MyDbContext context)
        {
            _context = context;
        }

        public void SeedEmployes()
        {
            for (var i = 1; i < 1000; i++)
            {
                Employee e = new Employee();
                e.FirstName = "First Name " + i;
                e.LastName = "Last Name " + i;
                e.Office = "Office";
                e.Position = "Position";
                e.Salary = 10000.00;
                e.StartDate = DateTime.Now;

                _context.Employees.Add(e);
                _context.SaveChanges();

            }
        }
    }
}
