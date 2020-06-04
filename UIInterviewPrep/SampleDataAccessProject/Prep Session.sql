create table

select * from Product
drop table dbo.Product
create table Products(
    ID int not null Identity,
    Product_Name VARCHAR(20),
    Company VARCHAR(20),
    Product_Type VARCHAR(10) 
)