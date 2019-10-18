using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {

            return View(GetEmployees());
        }

        private List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            for (int index = 1; index <= 15; index++)
            {
                employees.Add(new EmployeeViewModel()
                {
                    EmployeeCode = "100000" + index,
                    Name = "Employee-" + index,
                    Address = "Address-" + index,
                    Department = "Department-" + index,
                    Title = "Title-" + index,
                    ContactNumber = "ContactNumber-" + index
                });
            }

            return employees;
        }
    }
}