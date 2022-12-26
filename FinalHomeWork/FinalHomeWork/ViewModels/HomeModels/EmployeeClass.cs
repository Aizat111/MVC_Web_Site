using FinalHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalHomeWork.ViewModels.HomeModels
{
    public class EmployeeClass
    {

        public EmployeeClass()
        {
            employee = new employees();
            jobs = new List<jobs>();
            departments = new List<departments>();
            employees = new List<employees>();
        }
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public string job_title { get; set; }
        public decimal salary { get; set; }
        public string department_name { get; set; }
        public string manager { get; set; }


        public List<departments> departments { get; set; }

        public List<jobs> jobs { get; set; }

        public List<employees> employees { get; set; }
        public employees employee { get; set; }
    }
}