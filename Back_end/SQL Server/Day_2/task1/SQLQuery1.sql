use test
go

CREATE TABLE Dep (
    DepID INT PRIMARY KEY,             
    DepName NVARCHAR(100) NOT NULL     
);
go

CREATE TABLE Emp (
    EmpID INT PRIMARY KEY,              
    EmpName NVARCHAR(100) NOT NULL,      
    JobTitle NVARCHAR(100),            
    Salary DECIMAL(10, 2),            
    DepID INT,                          
    CONSTRAINT FK_Emp_Dep FOREIGN KEY (DepID) REFERENCES Dep(DepID)  
	)
	go
	
INSERT INTO Dep (DepID, DepName) VALUES
(1, 'IT'),
(2, 'HR'),
(3, 'Finance');

go 
INSERT INTO Emp (EmpID, EmpName, JobTitle, Salary, DepID) VALUES
(101, 'Ali Hassan', 'Software Engineer', 12000.00, 1),
(102, 'Sara Adel', 'HR Specialist', 9000.00, 2),
(103, 'Mohamed Tarek', 'Accountant', 9500.00, 3),
(104, 'Nour Samir', 'Developer', 11000.00, 1);

go

