use haveyouseenme
go

alter procedure spGetAllEmployees
as
Begin
 Select employeeid, Name, Gender, City, deptid
 from tblEmployee
End

select * from tblemployee


use haveyouseenme
go

Create procedure spAddEmployee  
@Name nvarchar(50),  
@Gender nvarchar (10),  
@City nvarchar (50),  
@deptid int  
as  
Begin  
 Insert into tblEmployee (Name, Gender, City, deptid)  
 Values (@Name, @Gender, @City, @deptid)  
End

 