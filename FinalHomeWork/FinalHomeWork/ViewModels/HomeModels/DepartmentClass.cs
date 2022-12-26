using FinalHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalHomeWork.ViewModels.HomeModels
{
    public class DepartmentClass
    {

        public DepartmentClass()
        {
            department = new departments();
            locations = new List<locations>();
            countries = new List<countries>();

        }
        public int department_id { get; set; }

        public string department_name { get; set; }
        public string city { get; set; }

        public string country_name { get; set; }

        public List<countries> countries { get; set; }
        public List<locations> locations { get; set; }

        public departments department{ get; set; }
    }
}