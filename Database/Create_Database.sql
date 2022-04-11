CREATE TABLE Address (
    Id INT NOT NULL PRIMARY KEY,
    Address1 VARCHAR(255) NOT NULL,
    Address2 VARCHAR(100) NULL,
    City VARCHAR(100) NOT NULL,
    ZipCode VARCHAR(100) NOT NULL,
    CountryState VARCHAR(100) NULL,
    Country VARCHAR(100) NOT NULL
); 

CREATE TABLE Pharmacy (
    Id INT NOT NULL PRIMARY KEY,
    AddressID INT NOT NULL,
	PharmacyName VARCHAR(255) NOT NULL,
    Telephone VARCHAR(30) NOT NULL,
    GeoLat NUMERIC NOT NULL,
    GeoLong NUMERIC NOT NULL,
    Website VARCHAR(255) NOT NULL,
	CONSTRAINT FK_PharmacyAddress FOREIGN KEY (AddressID) REFERENCES Address(Id)
);

CREATE TABLE Doctor (
    Id INT NOT NULL PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Telephone VARCHAR(30) NOT NULL,
    ClinicName VARCHAR(255) NOT NULL
);

CREATE TABLE Patient (
    Id INT NOT NULL PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    CprNumber VARCHAR(10) NOT NULL,
    AddressID INT NOT NULL,
	Email VARCHAR(255) NOT NULL,
    Telephone VARCHAR(30) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
	CONSTRAINT FK_PatientAddress FOREIGN KEY (AddressID) REFERENCES Address(Id)
); 

CREATE TABLE Perscription (
    Id INT NOT NULL PRIMARY KEY,
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    Medication VARCHAR(255) NOT NULL,
    Dosage VARCHAR(255) NOT NULL,
    DosageForm VARCHAR(255) NOT NULL,
    NumberOfRefillsLeft INT NOT NULL,
    DispensingInstructions VARCHAR(255) NOT NULL,
    DoctorSignature VARCHAR(255) NOT NULL,
    IsFulfilled BOOLEAN NOT NULL,
    PerscriptionDate TIMESTAMP NOT NULL,
    ExpirationDate TIMESTAMP NOT NULL,
    HasBeenNotified BOOLEAN NOT NULL,
	CONSTRAINT FK_PerscriptionPatient FOREIGN KEY (PatientID) REFERENCES Patient(Id),
	CONSTRAINT FK_PerscriptionDoctor FOREIGN KEY (DoctorID) REFERENCES Doctor(Id)
); 

CREATE TABLE AuditLog (
    Id INT NOT NULL PRIMARY KEY,
    AuditAction VARCHAR(255) NOT NULL,
    UserName VARCHAR(255) NOT NULL,
    AuditTimestamp TIMESTAMP NOT NULL,
    ItemType VARCHAR(255) NOT NULL,
    ItemId INT NULL,
    ItemJson JSON NULL
);