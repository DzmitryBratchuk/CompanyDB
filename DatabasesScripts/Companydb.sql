IF DB_ID('companydb') IS NULL
BEGIN
	CREATE DATABASE companydb;
END
GO

IF DB_ID('companydb') IS NOT NULL
BEGIN
	USE companydb;

	CREATE TABLE Educations
	(
		Id INT PRIMARY KEY IDENTITY,
		InstitutionName NVARCHAR(50) NOT NULL,
		GraduationYear SMALLINT NOT NULL,
		UNIQUE(InstitutionName,GraduationYear)
	);

	CREATE TABLE Genders
	(
		Id INT PRIMARY KEY IDENTITY,
		GenderName NVARCHAR(15) NOT NULL,
		UNIQUE(GenderName)
	);

	CREATE TABLE Projects
	(
		Id INT PRIMARY KEY IDENTITY,
		ProjectName NVARCHAR(30) NOT NULL,
		StartDate DATE,
		EndDate DATE
	);

	CREATE TABLE Employees
	(
		Id INT PRIMARY KEY IDENTITY,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		EmploymentDate DATE NOT NULL DEFAULT GETDATE(),
		EducationId INT,
		GenderId INT,
		CONSTRAINT FK_Employees_To_Educations FOREIGN KEY (EducationId) REFERENCES Educations(Id) ON DELETE SET DEFAULT,
		CONSTRAINT FK_Employees_To_Genders FOREIGN KEY (GenderId) REFERENCES Genders(Id) ON DELETE SET DEFAULT
	);

	CREATE TABLE EmployeesProjects
	(
		EmployeeId INT NOT NULL,
		ProjectId INT NOT NULL,
		CONSTRAINT PK_EmployeeID_ProjectId PRIMARY KEY (EmployeeId, ProjectId),
		CONSTRAINT FK_EmployeesProjects_To_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ON DELETE CASCADE,
		CONSTRAINT FK_EmployeesProjects_To_Projects FOREIGN KEY (ProjectId) REFERENCES Projects(Id) ON DELETE CASCADE
	);
END
GO

IF DB_ID('companydb') IS NOT NULL
BEGIN
	USE companydb;

	INSERT INTO Educations (InstitutionName, GraduationYear)
	VALUES
	('BSTU',2015),
	('BRSU',2017),
	('BSU',2019);

	INSERT INTO Genders (GenderName)
	VALUES
	('Male'),
	('Female'),
	('Undefined');

	INSERT INTO Projects (ProjectName,StartDate,EndDate)
	VALUES
	('American project', '2019-04-20', '2019-10-15'),
	('Polish project', '2019-09-22', DEFAULT),
	('French project', DEFAULT, DEFAULT);

	INSERT INTO Employees (FirstName,LastName,EmploymentDate,EducationId,GenderId)
	VALUES
	(
		'Anna', 
		'Karenina', 
		'2018-01-10', 
		(SELECT Id FROM Educations WHERE InstitutionName='BSU' AND GraduationYear=2019),
		(SELECT Id FROM Genders WHERE GenderName='Female') 
	),
	(
		'Jorge', 
		'Masvidal', 
		'2017-11-15', 
		(SELECT Id FROM Educations WHERE InstitutionName='BRSU' AND GraduationYear=2017),
		(SELECT Id FROM Genders WHERE GenderName='Male') 
	),
	(
		'Nathan', 
		'Diaz', 
		'2017-05-06', 
		(SELECT Id FROM Educations WHERE InstitutionName='BSTU' AND GraduationYear=2015),
		(SELECT Id FROM Genders WHERE GenderName='Male') 
	);

	INSERT INTO EmployeesProjects (EmployeeId,ProjectId)
	VALUES
	(
		(SELECT Id FROM Employees WHERE FirstName='Jorge' AND LastName='Masvidal'),
		(SELECT Id FROM Projects WHERE ProjectName='American project') 
	),
	(
		(SELECT Id FROM Employees WHERE FirstName='Nathan' AND LastName='Diaz'),
		(SELECT Id FROM Projects WHERE ProjectName='American project') 
	),
	(
		(SELECT Id FROM Employees WHERE FirstName='Anna' AND LastName='Karenina'),
		(SELECT Id FROM Projects WHERE ProjectName='French project') 
	);
END
GO
