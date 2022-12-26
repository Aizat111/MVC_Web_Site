using FinalHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalHomeWork.ViewModels.HomeModels
{
    public class CountryClass
    {
    
     public  CountryClass()
     {
            country = new countries();
            regions = new List<regions>();
     }
     public string country_id { get; set; }

     public string country_name { get; set; }

     public string region_name { get; set; }

     public List<regions> regions { get; set; }

     public countries country { get; set; }
    }
}