-- This is a Database for a TutionManagementSystem Application  which is having three roles student, Principal , and Teacher and to meet each Roles functional requirement 
-- we need to Maintain database 


--First we need to create a database

CREATE DATABASE TMS_V1_db;  -- This is a Database TMS(Tution Management System) Version 1;

USE TMS_V1_db;


-- The we need to create Tables Which are Required for the Tutuion Management System.


--First we need to create a table for Roles 
--               the role table stores the details of the  all the Roles that are  in our application eg: Student , Teacher.. 
CREATE TABLE Roles
(
RoleId INT IDENTITY PRIMARY KEY,
RoleName VARCHAR(20) UNIQUE
);
                 --This table store the RoleId and the corresponding Role Name 
		

-------------------------------------------------------------------------------

--Then we need to create Table Users 
--    this table stores the credentials of all the users in the system along with their Role Details 
--    this table contails the RoleId as a ForeignKey From the Roles Table 
CREATE  TABLE Users
(
UserId INT IDENTITY PRIMARY KEY,
Username VARCHAR(30),
Password VARCHAR(30),
RoleId INT REFERENCES Roles(RoleId)
);


--------------------------------------------------------------------------------
--Then we need a Table to store the details of Classes , since the teachers and students has a common reference to a class it will be ideal to map them together 
CREATE TABLE Classes
(
ClassId INT IDENTITY PRIMARY KEY,
ClassName VARCHAR(5)
);

---------------------------------------------------------------------------------

--Then we need to Create a Table to store the Teachers Details  
    -- here we store the details and has a UserId as a foreign key from the Table Users to denote the particular 
	-- credentials in the Table Users belong to the particular Teacher , Then we have a Reference from the Table Classes which indicate that the 
	--Teacher belong to a particular class 

CREATE TABLE Teachers
(
TeacherId INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(25),
LastName VARCHAR(10),
Address VARCHAR(100),
Contact VARCHAR(10),
Gender VARCHAR(7),
IsActive BIT,
ClassId INT REFERENCES Classes(ClassId),
UserId INT REFERENCES Users(UserId)
);

---------------------------------------------------------------------------------
--Then we need to Create a Table for Storing the Educational Status Details ie each student will have a Educational Status and we need to 
-- to refer this table to get the status Details of Each Students 
-- the status Details will Include Status Id ,  Status

CREATE TABLE EducationalStatus
(
StatusId INT IDENTITY PRIMARY KEY,
Status VARCHAR(20)
);

---------------------------------------------------------------------------------
--Then we need to create a table to store the details of Students and there will a reference from Table Users to the Table Students to ensure the credentils in 
-- the Table Users belong to this particular Student , This table also has reference to the Table EducationalStatus to store the detail of his/her status,
-- then there is a reference to Table Classes 

CREATE TABLE Students 
(
StudentId INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(25),
LastName VARCHAR(10),
Address VARCHAR(60),
Gender VARCHAR(7),
Dob DATE,
IsActive BIT,
ClassId INT REFERENCES Classes(ClassId),
StatusId INT REFERENCES EducationalStatus(StatusId),
UserId INT REFERENCES Users(UserId)
);


-----------------------------------------------------------------------------------------------------------------------
--Some Sample Datas for each and every table 

--Table Roles 
INSERT INTO Roles (RoleName)
VALUES ('Principal'),('Teacher'),('Student');


--Table Users
INSERT INTO Users (Username, Password, RoleId)
VALUES ('jacky', '1234', 1),  
       ('sofia', '1234', 2),    
       ('studadam', '1234', 3);    


-- Table Classes
INSERT INTO Classes (ClassName)
VALUES ('10-A'),('10-B'),('9-A');

--Table Teachers
INSERT INTO Teachers (FirstName, LastName, Address, Contact, Gender, IsActive, ClassId, UserId)
VALUES ('Sofia', 'smith', 'north Tvm', '9090909012', 'Male', 1, 1, 2)
      

-- Table EducationalStatus
INSERT INTO EducationalStatus (Status)
VALUES ('Excellent'),('Good'),('Average'),('Poor');


--Table Students
INSERT INTO Students (FirstName, LastName, Address, Gender, Dob, IsActive, ClassId, StatusId, UserId)
VALUES ('Adam', 'Smith', '789 Elm Rd, Springfield', 'Male', '1990-05-01', 1, 1, 1, 3)

