-- Inds�t brugere
INSERT INTO Bruger (id, brugernavn, kodeord, mail, sprog, avatar)
VALUES (1, 'jdoe', '1234secure', 'jdoe@example.com', 'da', 'avatar1.png'),
       (2, 'admin01', 'adminsecure', 'admin@example.com', 'da', 'avatar2.png');

-- G�r en bruger til beboer og den anden til admin
INSERT INTO Beboer (id) VALUES (1);
INSERT INTO Admin (id, attribute) VALUES (2, 'Systemansvarlig');

-- Inds�t residens
INSERT INTO Residens (st�rrelse, adresse)
VALUES (85, 'Vesterbro 42, 1620 K�benhavn V');

-- Knyt bruger med id 1 til residens
INSERT INTO BrugerResidens (brugerId, residensId)
VALUES (1, 1);

-- Inds�t f�lleslokale
INSERT INTO F�lleslokale (id, navn, beskrivelse)
VALUES (1, 'F�llesrum 1', 'Stort rum med plads til 20 personer');

-- Opret event
INSERT INTO Event (starttidspunkt, sluttidspunkt, beskrivelse, navn, residensId)
VALUES ('2025-05-01 14:00', '2025-05-01 16:00', 'Beboerm�de', 'M�de', 1);

-- Opret booking
INSERT INTO Booking (starttidspunkt, sluttidspunkt, f�lleslokaleId, residensId)
VALUES ('2025-05-02 18:00', '2025-05-02 22:00', 1, 1);
