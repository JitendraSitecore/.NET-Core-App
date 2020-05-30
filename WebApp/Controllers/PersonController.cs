using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting.Internal;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("http://localhost:3000/")]
    public class PersonController : Controller
    {

        private IConfiguration Configuration;

        public PersonController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public JsonResult Get()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            for (int index = 1; index <= 10; index++)
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

            return Json(employees);
        }

        //[Route("api/person/getfromdb")]
        public JsonResult GetFromDB()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            string connString = this.Configuration.GetConnectionString("ConnStr_EmployeeDB");

            try
            {
                SqlConnection connection = null;
                using (connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("select * from Employee", connection);
                    SqlDataReader sqlDataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (sqlDataReader != null && sqlDataReader.HasRows)
                    {

                        while (sqlDataReader.Read())
                        {
                            employees.Add(new EmployeeViewModel()
                            {
                                EmployeeCode = sqlDataReader["EmployeeId"].ToString(),
                                Name = sqlDataReader["Name"].ToString(),
                                Department = sqlDataReader["Department"].ToString(),
                                Address = sqlDataReader["Address"].ToString(),
                                ContactNumber = sqlDataReader["Phone"].ToString(),
                                Title = sqlDataReader["Title"].ToString()
                            });
                        }

                    }

                    connection.Close();
                }
                return Json(employees);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }

            //return Json(connString);
        }

        
    }

    
}