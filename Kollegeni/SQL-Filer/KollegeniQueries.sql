-- Indsæt brugere
INSERT INTO Bruger (id, brugernavn, kodeord, mail, sprog, avatar)
VALUES (1, 'jdoe', '1234secure', 'jdoe@example.com', 'da', 'avatar1.png'),
       (2, 'admin01', 'adminsecure', 'admin@example.com', 'da', 'avatar2.png');

-- Gør en bruger til beboer og den anden til admin
INSERT INTO Beboer (id) VALUES (1);
INSERT INTO Admin (id, attribute) VALUES (2, 'Systemansvarlig');

-- Indsæt residens
INSERT INTO Residens (størrelse, adresse)
VALUES (85, 'Vesterbro 42, 1620 København V');

-- Knyt bruger med id 1 til residens
INSERT INTO BrugerResidens (brugerId, residensId)
VALUES (1, 1);

-- Indsæt fælleslokale
INSERT INTO Fælleslokale (id, navn, beskrivelse)
VALUES (1, 'Fællesrum 1', 'Stort rum med plads til 20 personer');

-- Opret event
INSERT INTO Event (starttidspunkt, sluttidspunkt, beskrivelse, navn, residensId)
VALUES ('2025-05-01 14:00', '2025-05-01 16:00', 'Beboermøde', 'Møde', 1);

-- Opret booking
INSERT INTO Booking (starttidspunkt, sluttidspunkt, fælleslokaleId, residensId)
VALUES ('2025-05-02 18:00', '2025-05-02 22:00', 1, 1);
