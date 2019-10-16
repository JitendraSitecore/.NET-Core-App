using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class EmployeeViewModel
    {
        public string EmployeeCode { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public string Title { get; set; }

        public string Department { get; set; }

        public string ContactNumber { get; set; }
    }
}
