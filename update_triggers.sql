-- update triggers
--jobs

create trigger jobUpdated
on jobs
for update as
begin
declare @id int
declare @old_job_title varchar(35)
declare @old_min_salary decimal(8,2)
declare @old_max_salary decimal(8,2)
declare @new_job_title varchar(35)
declare @new_min_salary decimal(8,2)
declare @new_max_salary decimal(8,2)

select @id=job_id,
@old_job_title=job_title,
@old_min_salary=min_salary,
@old_max_salary=max_salary from deleted

select @new_job_title=job_title,
@new_min_salary=min_salary,
@new_max_salary=max_salary from inserted where job_id=@id

insert into log_job_upd values (
@id, @old_job_title, @new_job_title, @old_min_salary, @new_min_salary, @old_max_salary, @new_max_salary, getdate()
)
end

-- regions
create trigger regionUpdated
on regions
for update as
begin
declare @id int
declare @oName varchar(25)
declare @nName varchar(25)

select @id=region_id, @oName=region_name from deleted
select @nName=region_name from inserted where region_id=@id
insert into  log_region_upd values (@id,@oName,@nName,getdate())
end

--countries
create trigger countryUpdated
on countries
for update as
begin
declare @id int
declare @oName varchar(40)
declare @nName varchar(40)
declare @oRegionId int
declare @nRegionId int 

select @id=country_id, @oName=country_name, @oRegionId=region_id from deleted
select @nName=country_name, @nRegionId=region_id from inserted where country_id=@id
insert into log_country_upd values(@id, @oName, @nName, @oRegionId, @nRegionId, GETDATE())
end

--locations
create trigger locationUpdated
on locations
for update as
begin
declare @id int
declare @oStreet varchar(40)
declare @nStreet varchar(40)
declare @oPostal varchar(12)
declare @nPostal varchar(12)
declare @oCity varchar (30)
declare @nCity varchar(30)
declare @oState varchar(25)
declare @nState varchar(25)
declare @oCountryId char(2)
declare @nCountryId char(2) 

select @id=location_id, @oStreet=street_address, @oPostal=postal_code, @oCity=city, @oState=state_province, @oCountryId=country_id from deleted
select @nStreet=street_address, @nPostal=postal_code, @nCity=city, @nState=state_province, @nCountryId=country_id from inserted where location_id=@id
insert into log_location_upd values (
@id,
@oStreet,
@nStreet,
@oPostal,
@nPostal,
@oCity,
@nCity,
@oState,
@nState,
@oCountryId,
@nCountryId,
getdate())
end


--departments
create trigger departmentUpdated
on departments
for update as
begin
declare @id int
declare @oName varchar(40)
declare @nName varchar(40)
declare @oLocationId int
declare @nLocationId int 

select @id=department_id, @oName=department_name, @oLocationId=location_id from deleted
select @nName=department_name, @nLocationId=location_id from inserted where department_id=@id
insert into log_department_upd values(@id, @oName, @nName, @oLocationId, @nLocationId, GETDATE())
end

--employees
create trigger employeeUpdated
on employees
for update as
begin
declare @id int
declare @oFN varchar(20)
declare @nFN varchar (20)
declare @oLN varchar (25)
declare @nLN varchar(25)
declare @oEmail varchar(100)
declare @nEmail varchar(100)
declare @oPhone varchar (20)
declare @nPhone varchar (20)
declare @oHD date
declare @nHD date
declare @oJob int
declare @nJob int
declare @oSalary decimal(8,2)
declare @nSalary decimal(8,2)
declare @oManager int
declare @nManager int
declare @oDepartment int
declare @nDepartment int

select @id=employee_id, @oFN=first_name,@oLN=last_name,@oEmail=email,@oPhone=phone_number,
@oHD=hire_date,@oJob=job_id, @oSalary=salary, @oManager=manager_id, @oDepartment=department_id  from deleted

select  @nFN=first_name,@nLN=last_name,@nEmail=email,@nPhone=phone_number,
@nHD=hire_date,@nJob=job_id, @nSalary=salary, @nManager=manager_id, @nDepartment=department_id  from inserted where employee_id=@id

insert into log_employee_upd values (
@id,
@oFN,
@nFN,
@oLN,
@nLN,
@oEmail,
@nEmail,
@oPhone,
@nPhone,
@oHD,
@nHD,
@oJob,
@nJob,
@oSalary,
@nSalary,
@oManager,
@nManager,
@oDepartment,
@nDepartment,
getdate()
)
end

