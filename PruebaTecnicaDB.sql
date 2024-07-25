CREATE DATABASE PruebaTecnicaDB;

USE PruebaTecnicaDB;

CREATE TABLE Roles (
        RoleId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Users (
        UserId  INT IDENTITY(1,1) PRIMARY KEY,
        Email NVARCHAR(100) NOT NULL,
        Password NVARCHAR(100) NOT NULL,
        Username NVARCHAR(50) NOT NULL,
        Phone NVARCHAR(15),
        RoleId INT,
        FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

INSERT INTO Roles (Name) VALUES ('admin'), ('usuario');

INSERT INTO Users (Email, Password, Username, Phone, RoleId)
VALUES 
('admin@example.com', 'hashedpassword1', 'adminuser', '1234567890', 1),
('user@example.com', 'hashedpassword2', 'normaluser', '0987654321', 2);



