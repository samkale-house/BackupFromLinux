use Production
create table ProdAgents(
  AGENT_ID INT NOT NULL IDENTITY(1,1),
  AGENT_NAME VARCHAR(20),
  CITY VARCHAR(20),
  COMMISSION DECIMAL(10,4),
  PHONE_NUMBER VARCHAR(11),
  BIRTH_DATE DATE,
  SALARY DECIMAL(10,4),
  PRIMARY KEY(AGENT_ID)
)

/*check constraint validates the value of a column in that table with condition*/
create table ProdAgents_Audit(
CHANGE_ID INT IDENTITY(1,1) PRIMARY KEY,
AGENT_ID INT NOT NULL,
  AGENT_NAME VARCHAR(20),
  CITY VARCHAR(20),
  COMMISSION DECIMAL(10,4),
  PHONE_NUMBER VARCHAR(11),
  BIRTH_DATE DATE,
  SALARY DECIMAL(10,4),
  updated_at DATETIME NOT NULL,
    operation CHAR(3) NOT NULL,
    CHECK(operation = 'INS' or operation='DEL') 
)

BEGIN
CREATE TRIGGER trgr_AddProdAgents
ON Production.dbo.ProdAgents
AFTER INSERT
AS
 BEGIN
  SET NOCOUNT ON;
  insert into Production.dbo.ProdAgents_Audit(
  AGENT_ID,
  AGENT_NAME,
  CITY,
  COMMISSION,
  PHONE_NUMBER,
  BIRTH_DATE,
  SALARY,
  updated_at,
  operation
  )
  SELECT
   i.AGENT_ID,
   AGENT_NAME,
  CITY,
  COMMISSION,
  PHONE_NUMBER,
  BIRTH_DATE,
  i.SALARY,   
   getdate(),
   'INS'
  From inserted i   
 END

insert into Production.dbo.ProdAgents(
  AGENT_NAME,
  CITY,
  COMMISSION,
  PHONE_NUMBER,
  BIRTH_DATE,
  SALARY
  )
  VALUES ('Michelle','Iowa',3000.00,'3196548273','1980-03-18',6000.00)
  TRUNCATE TABLE dbo.ProdAgents
  select * from Production.dbo.ProdAgents
  select * from dbo.ProdAgents_Audit

  drop TRIGGER trgr_AddProdAgents

select * from sys.triggers where TYPE='TR'
   select name,is_instead_of_trigger from sys.triggers where TYPE='TR'

BEGIN
ENABLE TRIGGER trgr_AddProdAgents on dbo.ProdAgents;
GO
end


alter TABLE ProdAgents
add newcol VARCHAR(10)