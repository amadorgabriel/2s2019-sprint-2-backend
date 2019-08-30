/*
Disponibilizar o arquivo com o DDL, DML e DQL. Pode ser somente em um arquivo com o nome: script_ekips.sql.

- USUARIOS 
	-> Email
	-> Senha
	-> Permissão [ADMINISTRADOR/COMUM]
- FUNCIONARIOS [S1 C1 : N:1]
	-> Nome
	-> CPF
	-> DataNascimento
	-> Salario
	-> Setor
	-> Cargo
	-> Usuario [1:1]
- SETORES
	-> Nome
- CARGOS
	-> Nome
	-> Ativo

*/

--				DDL

CREATE DATABASE T_Ekips;
USE T_Ekips;

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Email VARCHAR(250) NOT NULL UNIQUE,
	Senha VARCHAR(250) NOT NULL,
	Permissao VARCHAR(250) NOT NULL
);

CREATE TABLE Cargos(
	IdCargo INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255) NOT NULL UNIQUE,
	Ativo BIT DEFAULT(0) 
);

CREATE TABLE Setores(
	IdSetor INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Funcionarios (
	IdFuncionario INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255) NOT NULL,
	Cpf VARCHAR(255) NOT NULL UNIQUE,
	DataNascimento DATE NOT NULL,
	Salario INT NOT NULL,
	IdCargo INT FOREIGN KEY REFERENCES Cargos(IdCargo),
	IdSetor INT FOREIGN KEY REFERENCES Setores(IdSetor),
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
);

--					DML

INSERT INTO Cargos (Nome, Ativo) VALUES ('Product Owner', 0),('Advogado Trabalhista', 1), ('Dev. Fullstack', 1);
INSERT INTO Setores (Nome) VALUES ('Jurídico'),('Tecnologia');
INSERT INTO Usuarios (Email, Senha, Permissao) VALUES
	('gabriel.amador@gmail.com', '123456', 'COMUM'),
	('bolinho.fofinho@gmail.com', '321321', 'ADMINISTRADOR'),
	('alameda.bonita@gmail.com', '123123', 'COMUM');
INSERT INTO Usuarios (Email, Senha, Permissao) VALUES
	('papa.capim@gmail.com', 'papa', 'COMUM');
INSERT INTO Funcionarios (Nome, Cpf, DataNascimento, Salario, IdCargo, IdSetor, IdUsuario) VALUES
	('Gabriel Rodrigues Amador', '44680781890', '25/09/2003',2500, 5, 2, 1 );


DELETE FROM Cargos;

--					DQL

SELECT * FROM Cargos ORDER BY IdCargo;
SELECT * FROM Setores ORDER BY IdSetor;
SELECT * FROM Usuarios ORDER BY IdUsuario;
SELECT * FROM Funcionarios ORDER BY IdFuncionario;

SELECT Funcionarios.IdFuncionario, Funcionarios.Nome, Funcionarios.Cpf, Funcionarios.DataNascimento, Funcionarios.Salario,
Cargos.Nome as NomeCargo, Cargos.Ativo, Setores.IdSetor, Setores.Nome as NomeSetor
FROM Funcionarios 
JOIN Cargos ON Funcionarios.IdCargo = Cargos.IdCargo
JOIN Setores ON Funcionarios.IdSetor = Setores.IdSetor
