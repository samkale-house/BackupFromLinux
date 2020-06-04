CREATE table Users
(
    UserId int primary key,
    Name VARCHAR(20),
    EmailID VARCHAR(35),
    PhoneNumber int
)
CREATE TABLE UserReports
(
    ReportId int PRIMARY Key,
    ReportName VARCHAR(100),
    ContentLength int,
    ReportContent VARBINARY(Max)    
)