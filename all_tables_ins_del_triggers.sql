-- job triggers
--drop trigger insJob
create trigger trg_job_audit
on jobs
after insert, delete
as
begin
set nocount on;
INSERT INTO
    log_job_ins_del
        (
         job_id,
         job_title,
         min_salary,
		 max_salary,
		 process_type,
		 process_date
        )
SELECT
    i.job_id,
    i.job_title,
    i.min_salary,
    i.max_salary,
	  'INS',
    GETDATE()
  
FROM
    inserted AS i
UNION ALL
    SELECT
    d.job_id,
    d.job_title,
    d.min_salary,
    d.max_salary,
    'DEL',
	  GETDATE()
    FROM
        deleted AS d;
end

--region triggers

create trigger tgr_region_audit
on dbo.regions
after insert, delete
as
begin
set nocount on;
insert into log_region_ins_del(
region_id,
region_name,
process_type,
process_date
)
select i.region_id,
i.region_name,
'INS',
getdate() from inserted as i
union all
select d.region_id,
d.region_name,
'DEL',
getdate() from deleted as d
end

-- country triggers
create trigger tgr_country_audit
on countries
after insert, delete
as
begin
set nocount on;
insert into log_country_ins_del(
country_id,
country_name,
region_id,
process_type,
process_date
)
select i.country_id,
i.country_name,
i.region_id,
'INS',
getdate() from inserted as i
union all
select d.country_id,
d.country_name,
d.region_id,
'DEL',
getdate() from deleted as d
end


-- departments triggers
alter trigger tgr_department_audit
on departments
after insert, delete
as
begin
set nocount on;
insert into log_department_ins_del(
department_id,
department_name,
location_id,
process_type,
process_date
)
select i.department_id,
i.department_name,
i.location_id,
'INS',
getdate() from inserted as i
union all
select d.department_id,
d.department_name,
d.location_id,
'DEL',
getdate() from deleted as d
end

-- dependents triggers
create trigger tgr_dependent_audit
on dependents
after insert, delete
as
begin
set nocount on;
insert into log_dependent_ins_del(
dependent_id,
first_name,
last_name,
relationship,
employee_id,
process_type,
process_date
)
select i.dependent_id,
i.first_name,
i.last_name,
i.relationship,
i.employee_id,
'INS',
getdate() from inserted as i
union all
select d.dependent_id,
d.first_name,
d.last_name,
d.relationship,
d.employee_id,
'DEL',
getdate() from deleted as d
end

--employee triggers
create trigger tgr_employee_audit
on employees
after insert, delete
as
begin
set nocount on;
insert into log_employee_ins_del(
employee_id,
first_name,
last_name,
email,
phone_number,
hire_date,
job_id,
salary,
manager_id,
department_id,
process_type,
process_date
)
select i.employee_id,
i.first_name,
i.last_name,
i.email,
i.phone_number,
i.hire_date,
i.job_id,
i.salary,
i.manager_id,
i.department_id,
'INS',
getdate() from inserted as i

select d.employee_id,
d.first_name,
d.last_name,
d.email,
d.phone_number,
d.hire_date,
d.job_id,
d.salary,
d.manager_id,
d.department_id
'DEL',
getdate() from deleted as d
end


--location_triggers
create trigger tgr_location_audit
on locations
after insert, delete
as
begin
set nocount on;
insert into log_location_ins_del(
location_id,
street_address,
postal_code,
city,
state_province,
country_id,
process_type,
process_date
)
select i.location_id,
i.street_address,
i.postal_code,
i.city,
i.state_province,
i.country_id,
'INS',
getdate() from inserted as i

select d.location_id,
d.street_address,
d.postal_code,
d.city,
d.state_province,
d.country_id,
'DEL',
getdate() from deleted as d
end