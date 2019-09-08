CREATE DATABASE T_ManualPecas;
USE T_ManualPecas;


CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Senha VARCHAR(255) NOT NULL
);

CREATE TABLE FornecedoresPecas(
	IdFornecedor INT FOREIGN KEY REFERENCES Fornecedores(IdFornecedor) NOT NULL ,
	IdPeca INT FOREIGN KEY REFERENCES Pecas(IdPeca) NOT NULL 
);

CREATE TABLE Fornecedores(
	IdFornecedor  INT PRIMARY KEY IDENTITY NOT NULL,
	CNPJ VARCHAR(255) NOT NULL UNIQUE,
	RazaoSocial VARCHAR(255) NOT NULL,
	NomeFantasia VARCHAR(255) NOT NULL,
	Endereco VARCHAR(255) NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario) NOT NULL UNIQUE
);

CREATE TABLE Pecas(
	IdPeca INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao  VARCHAR(255) NOT NULL,
	Peso FLOAT(2) NOT NULL,
	Preco FLOAT(2) NOT NULL,
);

DROP TABLE Pecas;
DROP TABLE Fornecedores;
DROP TABLE Usuarios;
DROP TABLE FornecedoresPecas;

------------------------ DML ----------------------------

INSERT INTO Usuarios (Email, Senha) VALUES  ('fulano@fulano.com', '123123'), ('ciclano@ciclano.com', '123456'), ('beltrano@beltrano.com', '123456');
INSERT INTO Usuarios (Email, Senha) VALUES  ('deltrano@deltrano.com', '321321');

INSERT INTO Fornecedores (CNPJ, RazaoSocial, NomeFantasia, Endereco,IdUsuario) VALUES 
	('12345678901234', 'fulano', 'Fornecedor A', 'Rua do Nunca', 1),
	('47816514691515', 'ciclano', 'Fornecedor b', 'Rua dos Bobos', 2),
	('48978465213548', 'beltrano', 'Fornecedor c', 'Rua dos Zero', 3);

INSERT INTO Pecas (Descricao,Peso, Preco)
	VALUES   ('Peça de motor', 1.1, 21)
			,('Peça de escape', 2.3, 20)
			,('Peça de Retrovisor', 3.6, 40)
			,('Peça para Roda', 4.1, 30);

INSERT INTO FornecedoresPecas (IdFornecedor, IdPeca) VALUES ( 1 , 1 ),( 1 , 3 ),( 2 , 1 ),( 3 , 1 ),( 3 , 3 ),( 3 , 4 ),( 1, 4 );

------------------------ DQL ----------------------------

SELECT * FROM Usuarios ORDER BY IdUsuario;
SELECT * FROM Fornecedores ORDER BY IdFornecedor;
SELECT * FROM Pecas ORDER BY IdPeca;
SELECT * FROM FornecedoresPecas ORDER BY IdFornecedor;
SELECT * FROM Pecas WHERE IdFornecedor = 1;

-- select * from Usuarios(DROP=Senha); 
SELECT IdUsuario, Email FROM Usuarios;

SELECT Usuarios.IdUsuario, Usuarios.Email, Fornecedores.IdFornecedor, Fornecedores.CNPJ, Fornecedores.RazaoSocial, Fornecedores.NomeFantasia, Fornecedores.Endereco , Pecas.IdPeca, Pecas.Descricao, Pecas.Peso, Pecas.Preco 
FROM Usuarios JOIN Fornecedores 
ON Usuarios.IdUsuario = Fornecedores.IdUsuario
JOIN Pecas
ON Fornecedores.IdFornecedor = Pecas.IdFornecedor

SELECT Fornecedores.*, Pecas.*
FROM FornecedoresPecas JOIN Fornecedores
ON FornecedoresPecas.IdFornecedor = Fornecedores.IdFornecedor
JOIN Pecas ON FornecedoresPecas.IdPeca =  Pecas.IdPeca
ORDER BY IdFornecedor