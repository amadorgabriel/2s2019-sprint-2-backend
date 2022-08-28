------------------------ DDL ----------------------------
CREATE DATABASE T_ManualPecas;
USE T_ManualPecas;

CREATE TABLE Pecas(
	IdPeca INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao  VARCHAR(255) NOT NULL,
	Peso FLOAT(2) NOT NULL
);

CREATE TABLE Fornecedores(
	IdFornecedor  INT PRIMARY KEY IDENTITY NOT NULL,
	CNPJ VARCHAR(255) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(255) NOT NULL,
	Endereco VARCHAR(255) NOT NULL
);

CREATE TABLE PecaFornecedor(
	IdFornecedor INT FOREIGN KEY REFERENCES Fornecedores(IdFornecedor) NOT NULL ,
	IdPeca INT FOREIGN KEY REFERENCES Pecas(IdPeca) NOT NULL,
	Preco FLOAT(2) NOT NULL
);

ALTER TABLE Fornecedores ADD Senha VARCHAR(255) 

------------------------ DML ----------------------------
INSERT INTO Fornecedores (CNPJ, NomeFantasia, Endereco) VALUES 
	('12345678901234', 'Fornecedor A', 'Rua do Nunca'),
	('47816514691515', 'Fornecedor B', 'Rua dos Bobos'),
	('48978465213548', 'Fornecedor C', 'Rua dos Zero');

INSERT INTO Pecas (Descricao,Peso)
	VALUES   ('Peça de motor', 1.1),
			 ('Peça de escape', 2.3),
			 ('Peça de Retrovisor', 3.6),
			 ('Peça para Roda', 4.1);

INSERT INTO PecaFornecedor (IdFornecedor, IdPeca, Preco) 
		VALUES ( 1, 1, 60.57), (1, 4, 15.00), (2, 2, 107.00), (3, 3, 8.00), (3, 2, 47.99), (2, 1, 60.00), (3, 4, 27.00);

UPDATE Fornecedores SET Senha = '123456' WHERE IdFornecedor = 1;
UPDATE Fornecedores SET Senha = '123123' WHERE IdFornecedor = 2;
UPDATE Fornecedores SET Senha = '654321' WHERE IdFornecedor = 3;

DELETE FROM PecaFornecedor WHERE IdFornecedor = 1 AND IdPeca = 1;

------------------------ DQL ----------------------------

SELECT * FROM Fornecedores ORDER BY IdFornecedor;
SELECT * FROM Pecas ORDER BY IdPeca;
SELECT * FROM PecaFornecedor ORDER BY IdFornecedor;
SELECT * FROM PecaFornecedor WHERE IdFornecedor = 1;

-- TENTA AI CRIAR UMAS PROCEDURES COM PARAMETROS E DAR UM EXECUTE

