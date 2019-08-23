CREATE DATABASE T_RoteiroFilmes;

USE T_RoteiroFilmes;

------------- QUERYS DA TABLE GENEROS  -----------------

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

SELECT * FROM Generos;
SELECT * FROM Generos WHERE IdGenero = 2;
SELECT * FROM Generos WHERE Nome = 'Romance';
INSERT INTO Generos(Nome) VALUES ('Drama'),('Ficção Cientifica');
DELETE FROM Generos WHERE IdGenero = 1;
UPDATE Generos SET Nome = 'Horror' WHERE IdGenero = 1;

------------- QUERYS DA TABLE FILME  -----------------

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

SELECT IdFilme, Titulo, IdGenero FROM Filmes;
SELECT * FROM Filmes 
SELECT Filmes.*, Generos.Nome
FROM Filmes JOIN Generos
ON Filmes.IdGenero = Generos.IdGenero
WHERE IdFilme = 1;
INSERT INTO Filmes(Titulo, IdGenero) VALUES ('Rei Leão', 1),('Marley e Eu', 2);

SELECT Filmes.*, Generos.Nome
FROM Generos JOIN Filmes
ON Generos.IdGenero = Filmes.IdGenero 
WHERE Generos.IdGenero = 1;

SELECT Filmes.*, Generos.Nome
FROM Filmes JOIN Generos
ON Filmes.IdGenero = Generos.IdGenero
WHERE Filmes.Titulo = 'Rei Leão';



