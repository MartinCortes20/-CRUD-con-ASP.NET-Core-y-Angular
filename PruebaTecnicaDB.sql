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


INSERT INTO Roles (RoleId, Name) VALUES (1, 'admin');
INSERT INTO Roles (RoleId, Name) VALUES (2, 'user');



INSERT INTO Users (Id,Email, Password,Username,Phone, RoleId)
VALUES ('1','admin@example.com', 'admin_password','Martin','5518323146',1);


DROP TABLE Roles;
DROP TABLE Users;
DROP TABLE __EFMigrationsHistory;

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Roles';

EXEC sp_rename 'Roles.Id', 'RoleId', 'COLUMN';

SELECT * FROM Users;
SET IDENTITY_INSERT Users ON;

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Users';
