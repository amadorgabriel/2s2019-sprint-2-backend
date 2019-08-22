CREATE DATABASE T_RoteiroFilmes;

USE T_RoteiroFilmes;

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

SELECT * FROM Generos;
SELECT * FROM Generos WHERE IdGenero = 2;
INSERT INTO Generos(Nome) VALUES ('Drama'),('Fic��o Cientifica');
DELETE FROM Generos WHERE IdGenero = 1;
SELECT * FROM Filmes;
INSERT INTO Filmes(Titulo, IdGenero) VALUES ('Rei Le�o', 1),('Marley e Eu', 2);

UPDATE Generos SET Nome = 'Horror' WHERE IdGenero = 1;
