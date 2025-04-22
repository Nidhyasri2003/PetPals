CREATE DATABASE PetPalsDB;
GO

USE PetPalsDB;
GO

--Pets Table
CREATE TABLE Pets (
    PetId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50),
    Age INT CHECK (Age > 0),
    Breed NVARCHAR(50),
    Type NVARCHAR(10), -- Dog or Cat
    DogBreed NVARCHAR(50), -- Nullable
    CatColor NVARCHAR(50)  -- Nullable
);

--Donations
CREATE TABLE Donations (
    DonationId INT IDENTITY PRIMARY KEY,
    DonorName NVARCHAR(100),
    Amount DECIMAL(10, 2) CHECK (Amount >= 10),
    DonationType NVARCHAR(20), -- Cash or Item
    DonationDate DATETIME,     -- For cash
    ItemType NVARCHAR(100)     -- For item
);

--AdoptionEvents table
CREATE TABLE AdoptionEvents (
    EventId INT IDENTITY PRIMARY KEY,
    EventName NVARCHAR(100),
    EventDate DATETIME
);

--Participants table
CREATE TABLE Participants (
    ParticipantId INT IDENTITY PRIMARY KEY,
    EventId INT,
    ParticipantName NVARCHAR(100),
    FOREIGN KEY (EventId) REFERENCES AdoptionEvents(EventId)
);

--sample data
INSERT INTO Pets (Name, Age, Breed, Type, DogBreed)
VALUES 
('Buddy', 3, 'Mixed', 'Dog', 'Labrador'),
('Rocky', 2, 'Bulldog', 'Dog', 'English Bulldog'),
('Max', 4, 'Terrier', 'Dog', 'Fox Terrier'),
('Bella', 1, 'Beagle', 'Dog', 'Beagle'),
('Charlie', 5, 'Husky', 'Dog', 'Siberian Husky');

INSERT INTO Pets (Name, Age, Breed, Type, CatColor)
VALUES
('Whiskers', 2, 'Siamese', 'Cat', 'White'),
('Luna', 3, 'Persian', 'Cat', 'Gray'),
('Milo', 1, 'Maine Coon', 'Cat', 'Orange'),
('Simba', 4, 'Bengal', 'Cat', 'Brown'),
('Chloe', 2, 'Ragdoll', 'Cat', 'Black');

-- Cash Donations
INSERT INTO Donations (DonorName, Amount, DonationType, DonationDate)
VALUES 
('Alice Johnson', 50.00, 'Cash', GETDATE()),
('Michael Lee', 20.00, 'Cash', GETDATE()),
('Sarah Kim', 75.00, 'Cash', GETDATE());

-- Item Donations
INSERT INTO Donations (DonorName, Amount, DonationType, ItemType)
VALUES
('David Brown', 30.00, 'Item', 'Pet Food'),
('Emma Davis', 40.00, 'Item', 'Toys'),
('Olivia Wilson', 25.00, 'Item', 'Leashes and Collars'),
('James Thomas', 35.00, 'Item', 'Pet Beds');

INSERT INTO AdoptionEvents (EventName, EventDate)
VALUES 
('Spring Pet Adoption Fair', '2025-05-01'),
('Summer Pet Drive', '2025-06-15');

-- Participants for Spring Pet Adoption Fair (EventId = 1)
INSERT INTO Participants (EventId, ParticipantName)
VALUES 
(1, 'Happy Tails Shelter'),
(1, 'PetAdopt Org'),
(1, 'John Doe');

-- Participants for Summer Pet Drive (EventId = 2)
INSERT INTO Participants (EventId, ParticipantName)
VALUES 
(2, 'Paws & Claws Shelter'),
(2, 'Jane Smith');

select* from Donations;
select * from Participants;
select*from AdoptionEvents;
select* from pets;