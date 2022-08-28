CREATE DATABASE T_BookStore;

USE T_BookStore;

CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);

CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Titulo             VARCHAR(255) NOT NULL UNIQUE
	,Descricao			VARCHAR(200) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

INSERT INTO Autores (Nome, Email, Ativo, DataNascimento) VALUES ('Arthur Conan Doyle','conan@doyle.com',1,'02/9/1987')
INSERT INTO Generos (Nome) VALUES ('Romance'),('Ficção');
INSERT INTO Livros(Titulo, Descricao, IdAutor, IdGenero)VALUES ('A camara Secreta', 'Um Garoto Bruxo', 25, 2), ('A Culpa é das Estrelas', 'Um Garoto Apaixonado', 1, 1)
UPDATE Livros SET Titulo = 'A Camara Secreta', Descricao = 'Um Garoto Bruxo', IdAutor = 25, IdGenero = 2 WHERE IdLivro = 1;
DELETE FROM Livros WHERE IdLivro = 4;


SELECT * FROM Autores ORDER BY IdAutor ASC;
SELECT * FROM Generos ORDER BY IdGenero ASC;
SELECT * FROM Livros ORDER BY IdLivro ASC;
SELECT Livros.*, Generos.Nome AS GeneroLivro , Autores.Nome AS NomeAutor, Autores.Email AS EmailAutor, Autores.Ativo AS AutorAtivo, Autores.DataNascimento AS DataNascimentoAutor
FROM Livros 
JOIN Autores ON Livros.IdAutor = Autores.IdAutor
JOIN Generos ON Livros.IdGenero = Generos.IdGenero
SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero WHERE Livros.IdLivro = 1
SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero WHERE Livros.IdAutor = 1 
SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero WHERE Generos.Nome LIKE '%aven%' 

