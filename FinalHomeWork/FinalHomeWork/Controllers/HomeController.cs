using FinalHomeWork.Models;
using FinalHomeWork.ViewModels.HomeModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalHomeWork.Controllers
{
    public class HomeController : Controller
    {
       
        //list jobs table with stored procedure
        public ActionResult JobsList()
        {
            EmployeesInfoEntities1 entity = new EmployeesInfoEntities1();
            List<jobs> model = new List<jobs>();
            try
            {
                model = entity.Database.SqlQuery<jobs>(@"exec ListJobs").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }
        public ActionResult CreateJob( int? id =0)
        {

            
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            jobs model = new jobs();

            try
            {
                if (id > 0)
                {
                    //Update
                    model = ent.jobs.Find(id);

                }
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new job to table with stored procedure
        [HttpPost]
        public ActionResult CreateJob(jobs model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
                if(model.job_id>0)
                {
                    //update
                    ent.Database.ExecuteSqlCommand(@"exec UpdateJob @job_id, @job_title, @min_salary, @max_salary ",
                        new SqlParameter("@job_id",model.job_id),
                        new SqlParameter("@job_title", model.job_title), 
                        new SqlParameter("@min_salary", model.min_salary),
                        new SqlParameter("@max_salary", model.max_salary));
                }
                else
                {
                    //insert
                    ent.Database.ExecuteSqlCommand(@"exec InsertJob @job_title, @min_salary, @max_salary ", 
                    new SqlParameter("@job_title", model.job_title), 
                    new SqlParameter("@min_salary", model.min_salary), 
                    new SqlParameter("@max_salary", model.max_salary));
                }
               // ent.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return RedirectToAction("JobsList");
        }

        public ActionResult JobDelete(int? id = 0)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            try
            {
                jobs model = new jobs();
                ent.Database.ExecuteSqlCommand("exec DeleteJob @id", new SqlParameter("@id", id));

                //model = ent.products.Find(id);
                //ent.products.Remove(model);
                //ent.SaveChanges();

            }
            catch (Exception) { throw; }

            return RedirectToAction("JobsList");
        }


        // regions

        //list regions table with stored procedure
        public ActionResult RegionsList()
        {
            EmployeesInfoEntities1 entity = new EmployeesInfoEntities1();
            List<regions> model = new List<regions>();
            try
            {
                model = entity.Database.SqlQuery<regions>(@"exec ListRegions").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }

        public ActionResult CreateRegion(int? id = 0)
        {


            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            regions model = new regions();

            try
            {
                if (id > 0)
                {
                    //Update
                    model = ent.regions.Find(id);

                }
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new item to table with stored procedure
        [HttpPost]
        public ActionResult CreateRegion(regions model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
                if (model.region_id > 0)
                {
                    //update
                    ent.Database.ExecuteSqlCommand(@"exec UpdateRegion @region_id, @region_name ",
                        new SqlParameter("@region_id", model.region_id),
                        new SqlParameter("@region_name", model.region_name));
                }
                else
                {
                    //insert
                    ent.Database.ExecuteSqlCommand(@"exec InsertRegion @region_name",
                    new SqlParameter("@region_name", model.region_name));
                }
                // ent.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("RegionsList");
        }

        public ActionResult RegionDelete(int? id = 0)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            try
            {
                regions model = new regions();
                ent.Database.ExecuteSqlCommand("exec DeleteRegion @id", new SqlParameter("@id", id));

            }
            catch (Exception) { throw; }

            return RedirectToAction("RegionsList");
        }



        // countries
        //list

        public ActionResult CountriesList()
        {
            EmployeesInfoEntities1 entity = new EmployeesInfoEntities1();
            List<CountryClass> model = new List<CountryClass>();
            try
            {
                model = entity.Database.SqlQuery<CountryClass>(@"exec ListCountries").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }

        public ActionResult CreateCountry()
        {


            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            CountryClass model = new CountryClass();

            try
            {
                model.regions = ent.regions.ToList();
              
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new item to table with stored procedure
        [HttpPost]
        public ActionResult CreateCountry(countries model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
              
                    //insert
                    ent.Database.ExecuteSqlCommand(@"exec InsertCountry @country_id, @country_name, @region_id",
                    new SqlParameter("@country_id",model.country_id),
                    new SqlParameter("@country_name",model.country_name),
                    new SqlParameter("@region_id", model.region_id));
                
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("CountriesList");
        }

        public ActionResult EditCountry(string id = "")
        {


            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            CountryClass model = new CountryClass();

            try
            {
                model.regions = ent.regions.ToList();
                if (id != "")
                {
                    //Update
                    model.country = ent.countries.Find(id);

                }
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new item to table with stored procedure
        [HttpPost]
        public ActionResult EditCountry(countries model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
               
                    //update
                    ent.Database.ExecuteSqlCommand(@"exec UpdateCountry @country_id, @country_name, @region_id ",
                        new SqlParameter("@country_id", model.country_id),
                        new SqlParameter("@country_name", model.country_name),
                        new SqlParameter("@region_id", model.region_id));
                
            
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("CountriesList");
        }

        public ActionResult CountryDelete( string id="")
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            try
            {
                countries model = new countries();
                ent.Database.ExecuteSqlCommand("exec DeleteCountry @id", new SqlParameter("@id", id));

            }
            catch (Exception) { throw; }

            return RedirectToAction("CountriesList");
        }


        // locations

        //list locations table with stored procedure
        public ActionResult LocationsList()
        {
            EmployeesInfoEntities1 entity = new EmployeesInfoEntities1();
            List<LocationClass> model = new List<LocationClass>();
            try
            {
                model = entity.Database.SqlQuery<LocationClass>(@"exec ListLocations").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }

        public ActionResult CreateLocation(int? id = 0)
        {


            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            LocationClass model = new LocationClass();

            try
            {
                model.countries = ent.countries.ToList();
                if (id > 0)
                {
                    //Update
                    model.location = ent.locations.Find(id);

                }
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new item to table with stored procedure
        [HttpPost]
        public ActionResult CreateLocation(locations model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
                if (model.location_id > 0)
                {
                    //update
                    ent.Database.ExecuteSqlCommand(@"exec UpdateLocation @location_id, @street_address,
                     @postal_code, @city, @state_province, @country_id",
                        new SqlParameter("@location_id", model.location_id),
                        new SqlParameter("@street_address", model.street_address),
                        new SqlParameter("@postal_code",model.postal_code),
                        new SqlParameter("@city",model.city),
                        new SqlParameter("@state_province", model.state_province),
                        new SqlParameter("@country_id", model.country_id));
                }
                else
                {
                    //insert
                    ent.Database.ExecuteSqlCommand(@"exec InsertLocation  @street_address,
                     @postal_code, @city, @state_province, @country_id",
                       
                        new SqlParameter("@street_address", model.street_address),
                        new SqlParameter("@postal_code",model.postal_code),
                        new SqlParameter("@city",model.city),
                        new SqlParameter("@state_province", model.state_province),
                        new SqlParameter("@country_id", model.country_id));
                }
                // ent.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("LocationsList");
        }

        public ActionResult LocationDelete(int? id = 0)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            try
            {
                ent.Database.ExecuteSqlCommand("exec DeleteLocation @id", new SqlParameter("@id", id));

            }
            catch (Exception) { throw; }

            return RedirectToAction("LocationsList");
        }




        // departments

        //list departments table with stored procedure
        public ActionResult DepartmentsList()
        {
            EmployeesInfoEntities1 entity = new EmployeesInfoEntities1();
            List<DepartmentClass> model = new List<DepartmentClass>();
            try
            {
                model = entity.Database.SqlQuery<DepartmentClass>(@"exec ListDepartments").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }
        public ActionResult CreateDepartment(int? id = 0)
        {


            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            DepartmentClass model = new DepartmentClass();

            try
            {
                model.locations = ent.locations.ToList();
                if (id > 0)
                {
                    //Update
                    model.department = ent.departments.Find(id);

                }
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new item to table with stored procedure
        [HttpPost]
        public ActionResult CreateDepartment(departments model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
                if (model.department_id > 0)
                {
                    //update
                    ent.Database.ExecuteSqlCommand(@"exec UpdateDepartment @department_id,@department_name, @location_id",
                        new SqlParameter("@department_id",model.department_id),
                        new SqlParameter("@department_name", model.department_name),
                        new SqlParameter("@location_id", model.location_id));
                }
                else
                {
                    //insert
                    ent.Database.ExecuteSqlCommand(@"exec InsertDepartment @department_name, @location_id",
                        new SqlParameter("@department_name", model.department_name),
                        new SqlParameter("@location_id", model.location_id));
                }
                // ent.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("DepartmentsList");
        }

        public ActionResult DepartmentDelete(int? id = 0)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            try
            {
                ent.Database.ExecuteSqlCommand("exec DeleteDepartment @id", new SqlParameter("@id", id));

            }
            catch (Exception) { throw; }

            return RedirectToAction("DepartmentsList");
        }

        //employees
        //list employees table with stored procedures
        public ActionResult EmployeesList()
        {
            EmployeesInfoEntities1 entity = new EmployeesInfoEntities1();
            List<EmployeeClass> model = new List<EmployeeClass>();
            try
            {
                model = entity.Database.SqlQuery<EmployeeClass>(@"exec ListEmployees").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }
        public ActionResult CreateEmployee(int? id = 0)
        {


            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            EmployeeClass model = new EmployeeClass();

            try
            {
                model.jobs = ent.jobs.ToList();
                model.departments = ent.departments.ToList();
                model.employees = ent.employees.ToList();
                if (id > 0)
                {
                    //Update
                    model.employee = ent.employees.Find(id);

                }
            }
            catch (Exception) { throw; }

            return View(model);

        }

        // add new item to table with stored procedure
        [HttpPost]
        public ActionResult CreateEmployee(employees model)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();

            try
            {
                if (model.employee_id > 0)
                {
                    //update
                    ent.Database.ExecuteSqlCommand(@"exec UpdateEmployee @employee_id, @first_name, @last_name,
@email, @phone_number, @hire_date, @job_id, @salary, @manager_id, @department_id",
                        new SqlParameter("@employee_id", model.employee_id),
                        new SqlParameter("@first_name", model.first_name),
                        new SqlParameter("@last_name", model.last_name),
                        new SqlParameter("@email", model.email),
                        new SqlParameter("@phone_number", model.phone_number),
                        new SqlParameter("@hire_date", model.hire_date),
                        new SqlParameter("@job_id", model.job_id),
                        new SqlParameter("@salary", model.salary),
                        new SqlParameter("@manager_id", model.manager_id),
                        new SqlParameter("@department_id", model.department_id));
                }
                else
                {
                    //insert
                    ent.Database.ExecuteSqlCommand(@"exec InsertEmployee @first_name, @last_name,
@email, @phone_number, @hire_date, @job_id, @salary, @manager_id, @department_id",
                        new SqlParameter("@first_name", model.first_name),
                        new SqlParameter("@last_name", model.last_name),
                        new SqlParameter("@email", model.email),
                        new SqlParameter("@phone_number", model.phone_number),
                        new SqlParameter("@hire_date", model.hire_date),
                        new SqlParameter("@job_id", model.job_id),
                        new SqlParameter("@salary", model.salary),
                        new SqlParameter("@manager_id", model.manager_id),
                        new SqlParameter("@department_id", model.department_id));
                }
                // ent.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("EmployeesList");
        }

        public ActionResult EmployeeDelete(int? id = 0)
        {
            EmployeesInfoEntities1 ent = new EmployeesInfoEntities1();
            try
            {
                ent.Database.ExecuteSqlCommand("exec DeleteEmployee @id", new SqlParameter("@id", id));

            }
            catch (Exception) { throw; }

            return RedirectToAction("EmployeesList");
        }


    }

}