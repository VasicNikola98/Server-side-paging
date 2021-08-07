using Microsoft.AspNetCore.Mvc;
using ServerSitePaging.Data;
using ServerSitePaging.Services;
using ServerSitePaging.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSitePaging.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetEmployeeList()
        {
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault()); 
            var searchTerm = Request.Form["search[value]"].FirstOrDefault();

            List<Employee> employeeList = new List<Employee>();
            employeeList = _employeeService.GetEmployee(start, length, searchTerm);

            var Draw = Request.Form["draw"].FirstOrDefault();
            var TotalRecords = _employeeService.TotalRecord();
            var FilteredRecords = employeeList.Count;


           var jsonData = new { data = employeeList, draw = Draw, recordsTotal = TotalRecords, recordsFiltered = TotalRecords };

            return Ok(jsonData);
        }
        
        
    }
}
