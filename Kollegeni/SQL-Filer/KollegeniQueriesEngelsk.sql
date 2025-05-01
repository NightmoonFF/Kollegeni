-- Indsæt brugere
INSERT INTO Users (Username, Password, Email, Language, Avatar)
VALUES ('jdoe', '1234secure', 'jdoe@example.com', 'da', 'avatar1.png'),
       ('admin01', 'adminsecure', 'admin@example.com', 'da', 'avatar2.png');

-- Gør en bruger til beboer og den anden til admin
SET IDENTITY_INSERT Tenants OFF;
SET IDENTITY_INSERT Admins OFF;
INSERT INTO Tenants (id, Name, Email, Address) VALUES (1, 'jdoe', 'jdoe@example.com', 'Kollegiet');
INSERT INTO Admins (id, Username, Password, Email, attribute) VALUES (2, 'John', 1234, 'John@gmail.com', 'Systemansvarlig');

select *
from Tenants
-- Indsæt residens
INSERT INTO Residencies (Address)
VALUES ('Vesterbro 42, 1620 København V');

-- Knyt bruger med id 1 til residens
INSERT INTO UserResidencies (UserId, ResidenceId)
VALUES (1, 1);

select *
from UserResidencies
-- Indsæt fælleslokale
INSERT INTO Rooms (Name, Description)
VALUES ('Fællesrum 1', 'Stort rum med plads til 20 personer');

-- Opret event
INSERT INTO Event (StartTime, EndTime, Description, Name, TenantId, ResidencyId)
VALUES ('2025-05-01 14:00', '2025-05-01 16:00', 'Beboermøde', 'Møde',1, 1);
select * 
from event
-- Opret booking
INSERT INTO Bookings (StartTime, EndTime, RoomId, ResidencyId)
VALUES ('2025-05-02 18:00', '2025-05-02 22:00', 1, 1);

Select *
from Bookings