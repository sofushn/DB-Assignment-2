INSERT INTO Address (Id, Address1, Address2, City, ZipCode, CountryState, Country)
VALUES (
    12,
    'Hilmehave 1',
    'Bygaden 33, 1. th.',
    'Havnebyen',
    '6729',
    'Marken',
    'Danmark'
);

INSERT INTO Address (Id, Address1, Address2, City, ZipCode, CountryState, Country)
VALUES (
    13,
    'Bussebussen 5',
    'Hovedgaden 33, 5. th.',
    'Havnebyen',
    '6729',
    'Marken',
    'Danmark'
);

INSERT INTO Pharmacy (Id, Address, PharmacyName, Telephone, GeoLat, GeoLong, Website)
VALUES ( 
    21,
    12,
    'Det gamle apotek',
    '23221971',
    385322.1424,
    7727.0008,
    'dga.dk'
);

INSERT INTO Doctor (Id, FirstName, LastName, Email, Telephone, ClinicName)
VALUES (
    31,
    'Honning',
    'Havesnegl',
    'Havesneglen@rustmail.com',
    '12345678',
    'De kliniske havesnegle'
);

INSERT INTO Patient (Id, FirstName, LastName, Address, Email, Telephone)
VALUES (
    41,
    'Hedning',
    'Havelåge',
    13,
    'Hedningens@havelåge.dk',
    '42069420'
);

INSERT INTO Perscription (Id, PatientID, DoctorID, Medication, Dosage, DosageForm, NumberOfRefillsLeft, DispensingInstructions, DoctorSignature, IsFulfilled, PerscriptionDate, ExpirationDate)
VALUES (
    99,
    41,
    31,
    'Hårde stoffer og bløde godnatsange mm.',
    '500mg hårdeste stof, 3 minutters blød godnatsang',
    'Nål og sang',
    30,
    'Først skal nålen indsættes, hvorefter sangen skal synges',
    'Signered af Sofus Banditten',
    true,
    CURRENT_TIMESTAMP,
    CURRENT_TIMESTAMP
);
