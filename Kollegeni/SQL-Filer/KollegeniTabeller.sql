CREATE TABLE Bruger (
    id INT PRIMARY KEY,
    brugernavn NVARCHAR(100) NOT NULL,
    kodeord NVARCHAR(100) NOT NULL,
    mail NVARCHAR(255),
    sprog NVARCHAR(50),
    avatar NVARCHAR(255)
);

CREATE TABLE Beboer (
    id INT PRIMARY KEY,
    FOREIGN KEY (id) REFERENCES Bruger(id)
);

CREATE TABLE Admin (
    id INT PRIMARY KEY,
    attribute NVARCHAR(255),
    FOREIGN KEY (id) REFERENCES Bruger(id)
);

CREATE TABLE Residens (
    id INT PRIMARY KEY IDENTITY,
    størrelse INT,
    adresse NVARCHAR(255)
);

CREATE TABLE BrugerResidens (
    brugerId INT,
    residensId INT,
    PRIMARY KEY (brugerId, residensId),
    FOREIGN KEY (brugerId) REFERENCES Bruger(id),
    FOREIGN KEY (residensId) REFERENCES Residens(id)
);

CREATE TABLE Event (
    id INT PRIMARY KEY IDENTITY,
    starttidspunkt DATETIME NOT NULL,
    sluttidspunkt DATETIME NOT NULL,
    beskrivelse NVARCHAR(500),
    navn NVARCHAR(100),
    residensId INT,
    FOREIGN KEY (residensId) REFERENCES Residens(id)
);

CREATE TABLE Fælleslokale (
    id INT PRIMARY KEY,
    navn NVARCHAR(100),
    beskrivelse NVARCHAR(500)
);

CREATE TABLE Booking (
    id INT PRIMARY KEY IDENTITY,
    starttidspunkt DATETIME NOT NULL,
    sluttidspunkt DATETIME NOT NULL,
    fælleslokaleId INT,
    residensId INT,
    FOREIGN KEY (fælleslokaleId) REFERENCES Fælleslokale(id),
    FOREIGN KEY (residensId) REFERENCES Residens(id)
);
