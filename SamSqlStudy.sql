
  create table dbo.SamProduct1(ProductName NVARCHAR(20),ProductPrice decimal,Product_id int primary key not null)
  select * from dbo.SamProduct
 
   select CONCAT('ABC',1)

Alter PROCEDURE Insert1000SamProduct

AS

DECLARE @counter INT
SET @counter=1
truncate table SamProduct
WHILE @counter<=1000	
  BEGIN  
    
	INSERT INTO [SamProduct] ([ProductName], [ProductPrice],[Product_id])
	VALUES (CONCAT('Product',@counter),10*@counter,@counter) 
 set @counter=@counter+1
END
GO
truncate table SamProduct
EXEC Insert1000SamProduct with recompile
Exec sp_recompile Insert1000SamProduct
select * from SamProduct

ALTER Table SamProduct
drop COLUMN ProductLaunched 


create table testtable (bday date)
insert into testtable (bday) values('2020-01-15')
select * from SamProduct

declare @d date='2020-12-20';
BEGIN
update testtable
set bday=@d
END
GO

alter table testtable
add col2 varchar(10)

DECLARE @d DATE = '2020-01-15';
SELECT FORMAT( @d, 'dd-MMM-yyyy', 'en-US' ) AS 'DateTime Result'

        

alter table SamProduct1 
add ProductLaunched date

select DISTINCT FORMAT( ProductLaunched, 'dd-MMM-yyyy', 'en-US' ) from SamProduct
update SamProduct
set ProductLaunched= GETDATE()


/*multiple update in table without parameters*/
Create PROCEDURE AddValuestoColumn()
AS
BEGIN
update SamProduct
set ProductLaunched='2020-01-15' where Product_id BETWEEN 1 and 200

update SamProduct
set ProductLaunched='2020-02-20' where Product_id BETWEEN 201 and 400

update SamProduct
set ProductLaunched='2020-03-12' where Product_id BETWEEN 401 and 600

update SamProduct
set ProductLaunched='2020-03-28' where Product_id BETWEEN 601 and 800

update SamProduct
set ProductLaunched='2020-04-15' where Product_id BETWEEN 801 and 1000
END
GO

/*with parameters*/
Create PROCEDURE AddValuestoColumnWithParm(@launchdate date, @product_idstart int,@prod_idend int)
AS
BEGIN
update SamProduct
set ProductLaunched=@launchdate where Product_id BETWEEN @product_idstart and @prod_idend
END
GO

EXEC AddValuestoColumnWithParm '2020-04-15',1,200

EXEC dbo.AddValuestoColumnWithParm @launchdate = '2010-01-15',@product_idstart=201,@prod_idend=400; 

select distinct ProductLaunched, count(*) from SamProduct
group by ProductLaunched

select distinct ProductLaunched, count(*) from SamProduct
where ProductLaunched > '2010-01-28'
group by ProductLaunched 

alter procedure AddStatusCol()
AS
BEGIN
alter table SamProduct
add STATUS varchar(10) NOT Null DEFAULT 'ACTV' 
END
GO

Exec AddStatusCol

select top 2 * from SamProduct


create procedure editStatus(@status varchar(10),@startLaunchDate date,@endLaunchDate date)
as
BEGIN
update SamProduct
set STATUS=@status where ProductLaunched between @startLaunchDate and @endLaunchDate
END
GO

Exec editStatus @status='DLTD', @startLaunchDate='2020-01-01', @endLaunchDate='2020-01-31'


select distinct count(*),ProductLaunched from SamProduct group by STATUS,ProductLaunched 


select MONTH('2020-03-01')


update SamProduct
 set ProductPrice=100  where MONTH(ProductLaunched)=1;


select count(*),ProductPrice from SamProduct
    group by ProductPrice

declare @c_LaunchedDate Date;
declare @c_Price INT;
declare @v_productid INT;

declare cursor_Jan cursor 
for select ProductLaunched,ProductPrice,Product_id from SamProduct
    where MONTH(ProductLaunched)=1;

    open cursor_Jan;
     
     PRINT 'I am open';
   
    FETCH NEXT FROM cursor_Jan INTO 
    @c_LaunchedDate,@c_Price,@v_productid;

    WHILE @@FETCH_STATUS = 0
    BEGIN

    PRINT 'Inside while';
    select concat('1stprice:',@c_Price);
    
    update SamProduct
set ProductPrice=@c_Price-(@c_Price*(0.1))
where MONTH(ProductLaunched)=1  and Product_id=@v_productid;

    FETCH NEXT FROM cursor_Jan INTO 
    @c_LaunchedDate,@c_Price,@v_productid;

    END
    PRINT 'update completed';
    CLOSE cursor_Jan;
    PRINT 'cursor closed';
    DEALLOCATE cursor_Jan;


create function getAverage(@num1 int,@num2 int,@num3 int)
RETURNS INT as
BEGIN
   return (@num1+@num2+@num3)/3
END

select dbo.getAverage(10,20,30);

CREATE table Employees(
FIRST_NAME VARCHAR(20),
lAST_NAME VARCHAR(20),
EMAIL VARCHAR(25),
DEPARTMENT_ID INT,
BIRTH_DATE DATE,
JOINING_DATE DATE,
EMPLOYEE_ID INT NOT NULL IDENTITY(1,1),
PRIMARY KEY(EMPLOYEE_ID))

CREATE table Departments
(DEPARTMENT_ID INT NOT NULL IDENTITY(1,1),
DEPARTMENT_NAME VARCHAR(20),
PRIMARY KEY(DEPARTMENT_ID))


select count(*),BIRTH_DATE from Employees GROUP by BIRTH_DATE

BEGIN
alter PROCEDURE Insert1000Employees
AS
DECLARE @counter INT;
SET @counter=1;
truncate table Employees;
WHILE @counter<=1000	
  BEGIN  
  IF @counter>700  
	BEGIN
  INSERT INTO [Employees] ([FIRST_NAME], [LAST_NAME],[EMAIL],[DEPARTMENT_ID],[BIRTH_DATE],[JOINING_DATE])
	VALUES (CONCAT('parth',@counter),CONCAT('mahalle',@counter),concat(CONCAT('parth',@counter),'@gmail.com'),2,'1965-08-15','2006-01-03') 
  END
  ELSE
  BEGIN 
  INSERT INTO [Employees] ([FIRST_NAME], [LAST_NAME],[EMAIL],[DEPARTMENT_ID],[BIRTH_DATE],[JOINING_DATE])
	VALUES (CONCAT('parth',@counter),CONCAT('mahalle',@counter),concat(CONCAT('parth',@counter),'@gmail.com'),2,'1987-03-01','2012-01-03') 
  END
 set @counter=@counter+1
END
GO
END


EXEC Insert1000Employees


/*calculate age, 0.25 consideration for leap year*/
create FUNCTION getAge(@birthyear date)
returns INT AS
BEGIN
return cast(DATEDIFF(DD,@birthyear,getdate())/365.25 as INT) 
END

use MoviesDB
select dbo.getAge('2013-06-04')


/*calculate experiance in year*/
create FUNCTION getExperiance(@joindate date)
returns INT AS
BEGIN
return cast(DATEDIFF(YY,@joindate,getdate()) as INT) 
END

use MoviesDB
select dbo.getExperiance('2009-11-28')


/*Add 10 departments*/
BEGIN
create procedure Add10Departments
AS
declare @counter INT
set @counter=1
WHILE @counter<=10
   BEGIN
   INSERT into Departments(DEPARTMENT_NAME)
   values (CONCAT('Dep',@counter))
   set @counter=@counter+1
   END
GO
END

EXEC Add10Departments

select * from departments
select count(*),BIRTH_DATE from Employees GROUP by BIRTH_DATE

Select EMPLOYEE_ID from Employees where dbo.getAge(BIRTH_DATE)>45 and dbo.getExperiance(JOINING_DATE)>10

update Employees
set BIRTH_DATE='1985-08-15' where EMPLOYEE_ID BETWEEN 800 and 900

update Employees
set DEPARTMENT_ID=9 where EMPLOYEE_ID BETWEEN 1 and 600

/*no employee in each dep who are older than 45 and exp greater than 10*/
use MoviesDB
select count(e.EMPLOYEE_ID) employeecount,d.DEPARTMENT_NAME from Employees as e,Departments as d
where e.DEPARTMENT_ID=d.DEPARTMENT_ID and
dbo.getAge(BIRTH_DATE)>45 and dbo.getExperiance(JOINING_DATE)>10
group by d.DEPARTMENT_NAME


/*create agents to work with view*/
create table Agents(
  AGENT_ID INT NOT NULL IDENTITY(1,1),
  AGENT_NAME VARCHAR(20),
  CITY VARCHAR(20),
  COMMISSION DECIMAL(10,4),
  PHONE_NUMBER VARCHAR(11),
  BIRTH_DATE DATE,
  SALARY DECIMAL(10,4),
  PRIMARY KEY(AGENT_ID)
)

/*insert 1000 records*/
BEGIN
alter procedure insert100Agents
As
declare @counter INT
declare @cityname VARCHAR(20)
set @counter=1
set @cityname='Kolkata'
WHILE @counter<=1000
  BEGIN
  if @counter BETWEEN 251 and 500    
    set @cityname='Mumbai'
  else if @counter BETWEEN 501 and 750    
    set @cityname='Chennai'
  else if @counter BETWEEN 751 and 1000    
    BEGIN set @cityname='Pune'    END
  
  Insert into Agents(AGENT_NAME,CITY,COMMISSION,PHONE_NUMBER,BIRTH_DATE,SALARY)
  VALUES (CONCAT('mark',@counter),@cityname,7746.353,'3194317654','1987-03-23',44465.455)  
  
  set @counter=@counter+1
  END
GO
END  

EXEC insert100Agents
truncate table Agents

/*create view*/
create view vw_Agents as
select AGENT_ID,AGENT_NAME,CITY,PHONE_NUMBER from Agents

/*operate with view*/
select count(*),city from vw_Agents group by city
delete from vw_Agents where city='Mumbai'

use MoviesDB
ALTER view vw_Agents as
select AGENT_ID,AGENT_NAME,CITY,PHONE_NUMBER,BIRTH_DATE from Agents

select * from vw_Agents