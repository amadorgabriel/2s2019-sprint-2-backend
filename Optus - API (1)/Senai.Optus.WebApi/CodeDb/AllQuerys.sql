CREATE DATABASE T_Optus;

USE T_Optus;

CREATE TABLE Estilos
(
    IdEstilo    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Artistas
(
    IdArtista     INT PRIMARY KEY IDENTITY
    ,Nome		  VARCHAR(200) UNIQUE
    ,IdEstilo     INT FOREIGN KEY REFERENCES Estilos (IdEstilo)
);

CREATE TABLE Usuarios 
(
	IdUsuario 	INT PRIMARY KEY IDENTITY
	,Email		VARCHAR(255) NOT NULL UNIQUE
	,Senha		VARCHAR(255) NOT NULL
	,Permissao	VARCHAR(255) NOT NULL
);

INSERT INTO Estilos VALUES ('Folk');
INSERT INTO Artistas (Nome, IdEstilo) VALUES ('Stu Larsen', 4);
INSERT INTO Usuarios (Email, Senha, Permissao) VALUES ('admin@email.com', '123456', 'ADMINISTRADOR');
INSERT INTO Usuarios (Email, Senha, Permissao) VALUES ('comum@email.com', '123456', 'COMUM');

SELECT * FROM Estilos;
SELECT * FROM ARTISTAS;
SELECT A.IdArtista, A.Nome, A.IdEstilo, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN Estilos E ON A.IdEstilo = E.IdEstilo;
SELECT * FROM Estilos FOR JSON AUTO; -- Óia



