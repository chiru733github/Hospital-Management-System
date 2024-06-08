create database HospitalDB;
use HospitalDB;
create table Doctor
(
	DoctorId int primary key Identity(1,1),
	DoctorName varchar(50) not null,
	DoctorEmail varchar(50),
	PhoneNumber varchar(10),
	DoctorAge int,
	Gender varchar(10),
	DoctorAddress varchar(50),
	Qualification varchar(10),
	Specialization varchar(30),
	Experience float,
	DoctorImage varchar(100),
	IsTrash bit
);
select * from Doctor
create table Patient
(
	PatientID int primary key Identity(1,1),
	PatientName varchar(50),
	PatientEmail varchar(50),
	PhoneNumber varchar(10),
	PatientAge int,
	Gender varchar(10),
	PatientAddress varchar(50),
	PatientImage varchar(100),
	BloodGroup varchar(5),
	SufferFrom varchar(100),
	IsTrash bit
);
select * from Patient
create table Appointment
(
	AppointmentId int primary key Identity(1,1),
	DoctorFkId int FOREIGN KEY REFERENCES Doctor(DoctorId),
	PatientFkId int FOREIGN KEY REFERENCES Patient(PatientID),
	AppointmentDate Date,
	StartTime time,
	EndTime time,
	concern varchar(50)
);
select * from Appointment
select * from Doctor
select * from Patient