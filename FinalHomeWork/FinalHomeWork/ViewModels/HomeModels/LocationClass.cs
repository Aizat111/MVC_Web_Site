using FinalHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalHomeWork.ViewModels.HomeModels
{
    public class LocationClass
    {

        public LocationClass()
        {
            location = new locations();
            countries = new List<countries>();
            
        }
        public int location_id { get; set; }

        public string street_address { get; set; }

        public string postal_code { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }  

        public string country_name { get; set; }

        public List<countries> countries { get; set; }

        public locations location { get; set; }
    }
}