-- jobs procedures
alter procedure ListJobs
as
select * from jobs 

create procedure DeleteJob @id int
as
delete from jobs where job_id=@id

create procedure InsertJob 
@job_title varchar(35),
@min_salary decimal(8,2),
@max_salary decimal(8,2)
as
insert into jobs values(@job_title,@min_salary,@max_salary)

create procedure UpdateJob
@job_id int,
@job_title varchar(35),
@min_salary decimal(8,2),
@max_salary decimal(8,2)
as
update jobs set 
job_title=@job_title,
min_salary=@min_salary,
max_salary=@max_salary

where job_id=@job_id

-- region procedures
create procedure ListRegions
as 
select * from regions

create procedure DeleteRegion @id int
as
delete from regions where region_id=@id

create procedure InsertRegion
@region_name varchar(25)
as
insert into regions values(@region_name)

create procedure UpdateRegion
@region_id int,
@region_name varchar(25)
as
update regions set 
region_name=@region_name
where region_id=@region_id

-- country procedures
alter procedure ListCountries
as 
select c.country_id, c.country_name, r.region_name from countries c join regions r on c.region_id=r.region_id


alter procedure DeleteCountry @id char(2)
as
delete from countries where country_id=@id


create procedure InsertCountry
@country_id char(2),
@country_name varchar(25),
@region_id int
as
insert into countries values(@country_id,@country_name,@region_id)


alter procedure UpdateCountry
@country_id char(2),
@country_name varchar(25),
@region_id int
as
update countries set 
country_name=@country_name,
region_id=@region_id
where country_id=@country_id

-- location procedures

alter procedure ListLocations
as
select l.location_id, l.street_address, l.postal_code, l.city, l.state_province, c.country_name from locations l join
countries c  on l.country_id=c.country_id

create procedure DeleteLocation @id int
as
delete from locations where location_id=@id

create procedure InsertLocation 
@street_address varchar(40),
@postal_code varchar(12),
@city varchar(30),
@state_province varchar(25),
@country_id char (2)
as
insert into locations values (@street_address, @postal_code, @city, @state_province, @country_id)

create procedure UpdateLocation
@location_id int,
@street_address varchar(40),
@postal_code varchar(12),
@city varchar(30),
@state_province varchar(25),
@country_id char (2)
as
update locations set street_address=@street_address, postal_code=@postal_code,city=@city,
state_province=@state_province, country_id=@country_id where location_id=@location_id

--departments procedures

create procedure ListDepartments
as
select d.department_id, d.department_name, l.city, c.country_name from departments d join locations l
on d.location_id=l.location_id join countries c on l.country_id=c.country_id

create procedure DeleteDepartment @id int
as
delete from departments where department_id=@id


alter procedure InsertDepartment @department_name varchar(40), @location_id int
as
insert into departments values(@department_name, @location_id)

create procedure UpdateDepartment @department_id int, @department_name varchar(30), @location_id int
as
update departments set department_name= @department_name, location_id=@location_id where department_id=@department_id 


alter procedure ListEmployees
as
select e.employee_id, e.first_name, e.last_name, e.email, e.phone_number, e.hire_date, j.job_title, e.salary,
 d.department_name,(select first_name from employees where employee_id=e.manager_id)  as manager from employees e 
join jobs j on e.job_id=j.job_id join departments d on e.department_id= d.department_id

create procedure DeleteEmployee @id int
as
delete from employees where employee_id=@id

create procedure InsertEmployee @first_name varchar(20), @last_name varchar(25),
@email varchar(100), @phone_number varchar(20), @hire_date date, @job_id int, @salary decimal(8,2), @manager_id int, @department_id int
as
insert into employees values(@first_name, @last_name, @email, @phone_number, @hire_date, @job_id, @salary, @manager_id, @department_id)

create procedure UpdateEmployee @employee_id int, @first_name varchar(20), @last_name varchar(25),
@email varchar(100), @phone_number varchar(20), @hire_date date, @job_id int, @salary decimal(8,2), @manager_id int, @department_id int
as
update employees set first_name=@first_name, last_name=@last_name, email= @email, phone_number=@phone_number, hire_date=@hire_date,
job_id=@job_id, salary=@salary, manager_id= @manager_id, department_id=@department_id where employee_id= @employee_id