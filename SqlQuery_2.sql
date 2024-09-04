CREATE DATABASE ParkingManagement;

USE ParkingManagementSystem;

-- Create Feedback Table
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ReservationID INT NOT NULL,
    FeedbackText NVARCHAR(1000),
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    FeedbackDate DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES UserDetails(UserID),
    FOREIGN KEY (ReservationID) REFERENCES Reservation(ReservationID)
);

-- Create User Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Passwords NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15)
);

-- Create ParkingSpace Table
    CREATE TABLE ParkingSpace (
    ParkingSpaceID INT PRIMARY KEY IDENTITY(1,1),
    Location NVARCHAR(100) NOT NULL,
    Status NVARCHAR(20) NOT NULL
);

-- Create Reservation Table
CREATE TABLE Reservation (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ParkingSpaceID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ParkingSpaceID) REFERENCES ParkingSpace(ParkingSpaceID)
);

-- Create Payment Table
CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    FOREIGN KEY (ReservationID) REFERENCES Reservation(ReservationID)
);


INSERT INTO UserDetails(Username, Passwords, Email, PhoneNumber)
VALUES 
('john_doe', 'password123', 'john.doe@example.com', '1234567890'),
('jane_smith', 'securePass!456', 'jane.smith@example.com', '0987654321'),
('alice_jones', 'alicePass789', 'alice.jones@example.com', '1122334455'),
('bob_brown', 'bobSecure!123', 'bob.brown@example.com', '6677889900'),
('charlie_black', 'charliePass!456', 'charlie.black@example.com', '5566778899'),
('Priyanka_d','Priyanka123','Priyanka123@ByteBuffer.com','11113333');


use [ParkingManagementSystem]
select * from [dbo].[ParkingSpace] 

delete from [dbo].[ParkingSpace] where ParkingSpaceID=1000;

INSERT INTO Reservation (UserID, ParkingSpaceID, StartTime, EndTime)
VALUES
   (1, 1001, '2024-08-29 09:30:00', '2024-08-29 10:45:00'),
   (2, 1002, '2024-08-29 11:00:00', '2024-08-29 12:15:00'),
    (3, 1003, '2024-08-29 13:30:00', '2024-08-29 14:45:00'),
    (4, 1004, '2024-08-29 15:00:00', '2024-08-29 16:15:00'),
    (5, 1005, '2024-08-29 17:30:00', '2024-08-29 18:45:00');
   


	select * from [dbo].[Users]

INSERT INTO Feedback (UserID,ReservationID, FeedbackText, Rating, FeedbackDate)
VALUES
    (1, 11,'Smooth parking experience. Well-organized.', 5, '2024-08-29 10:30:00'),
    (2,12, 'Availability of spots was limited during peak hours.', 3, '2024-08-29 11:15:00'),
    (3,13, 'Clean parking area. Friendly attendants.', 4, '2024-08-29 12:00:00'),
    (4,14, 'Confusing signage. Difficult to find my spot.', 2, '2024-08-29 13:45:00'),
    (5,15, 'Quick exit process. No issues.', 5, '2024-08-29 14:30:00');

	  --Set the identity seed for ParkingSpaceID to 1000
DBCC CHECKIDENT ('ParkingSpace', RESEED, 999);
/*
Explanation:

The DBCC CHECKIDENT command allows you to manually set a new current identity value for the identity column.
By specifying RESEED and the desired value (999 in this case), you ensure that the next generated ParkingSpaceID will be 1001.
*/


	  INSERT INTO ParkingSpace (Location, Status)
VALUES
    ('Level 1, Section A', 'Available'),
    ('Level 2, Section B', 'Occupied');



	INSERT INTO Feedback (UserID,ReservationID, FeedbackText, Rating, FeedbackDate)
VALUES
    (1, 1001, 'Smooth parking experience.', 5, '2024-08-30 11:45:00');
    -- Add more feedback entries as needed
    

	INSERT INTO Payment (ReservationID, Amount, PaymentDate)
VALUES
    (11, 50.00, '2024-08-30 09:30:00'),
    (12, 75.50, '2024-08-30 10:15:00'),
    (13, 30.25, '2024-08-30 11:00:00'),
    (14, 20.00, '2024-08-30 12:30:00'),
    (15, 45.75, '2024-08-30 13:45:00');

	select* from[dbo].[Feedback]
    select* from[dbo].[Reservation]
	select * from[dbo].[ParkingSpace]
	select* from[dbo].[Payment]