create database PayRoll_Service22;
use PayRoll_Service22;

create table PayRoll_Service2(employeeName varchar(15),employeeSalary int,startDate Date,gender char(1),phoneNumber int,address varchar(10),department varchar(5),basicPay float,deduction int, taxeablePay float,incomeTax int,netPay int);

select *from PayRoll_Service2;

insert into PayRoll_Service2 (employeeName,employeeSalary,startDate,gender,phoneNumber,address,department,basicPay,deduction,taxeablePay,incomeTax,netPay) values('Rakesh',99,'2019-02-1','M',8007078569,'Bpur','Computer',1000,600,55,15,11);

-- Create Table
Create Procedure Employee_DetailsPro  --here created procedure Employee_DetailsPro
@employeeName varchar(50),
@basicPay  float,
@startDate Date,
@gender char(1)

AS
BEGIN			--here insert data into table " PayRoll_Service2 "
insert into PayRoll_Service2(employeeName, basicPay ,startDate,gender) values (@employeeName, @basicPay, @startDate, @gender) --insert data into PayRoll_Serivce2
END;;

select *from PayRoll_Service2;

--------Update Table

Create Procedure Employee_UpdateDetailsPro	--here created procedure Employee_DetailsPro
@name varchar(50),
@Basic_Pay  float
AS
BEGIN			--here update data into table " PayRoll_Service2 "
update PayRoll_Service2 Set basicPay=@basicPay where employeeName=@employeeName
END;;

select *from PayRoll_Service2;