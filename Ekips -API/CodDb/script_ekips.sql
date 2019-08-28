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
