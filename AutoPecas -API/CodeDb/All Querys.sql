/*
A empresa AutoPeças é uma administradora e convidou você a desenvolver uma nova API para que seja possível realizar a disponibilização dos registros de suas peças de cada fornecedor.
Devemos considerar os critérios mencionados abaixo:
- Cada fornecedor poderá cadastrar peças;
- Quando os fornecedores listarem as peças, deverão listar somente as suas.
-- Por exemplo, quando o Fornecedor A cadastrar a 'Peça 1' e a 'Peça 2' e o Fornecedor B cadastrar a 'Peça 3' e 'Peça 4', ao Fornecedor A solicitar a lista de peças, deverá aparecer somente as Peças: 1 e 2.

Você deverá ser capaz de desenvolver os seguintes tópicos abaixo:

+ Banco de Dados

Script contendo a criação do banco, das tabelas e seus determinados registros.
- autopecas_script.sql
M_AutoPecas | T_AutoPecas

Tabelas contendo os seguintes dados:
- Peças - código da peça (que o fornecedor define), descricao, peso, preço de custo, preço de venda e somente um fornecedor vinculado;
- Fornecedores - cnpj, razão social, nome fantasia, endereço e possui somente um usuário vinculado;
- Usuários - email e senha.

*/

------------------------ DDL ----------------------------
CREATE DATABASE T_AutoPecas;
USE T_AutoPecas;

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Senha VARCHAR(255) NOT NULL
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
	CodigoPeca  VARCHAR(255) NOT NULL UNIQUE,
	Descricao  VARCHAR(255) NOT NULL,
	Peso FLOAT(2) NOT NULL,
	PrecoCusto FLOAT(2) NOT NULL,
	PrecoVenda FLOAT(2) NOT NULL,
	IdFornecedor INT FOREIGN KEY REFERENCES Fornecedores(IdFornecedor) NOT NULL 
);

------------------------ DML ----------------------------

INSERT INTO Usuarios (Email, Senha) VALUES  ('fulano@fulano.com', '123123'), ('ciclano@ciclano.com', '123456');
INSERT INTO Fornecedores (CNPJ, RazaoSocial, NomeFantasia, Endereco,IdUsuario) VALUES 
	('12345678901234', 'Fornecedor A', 'Fornecedor A', 'Rua do Nunca', 1),
	('4781651.691515', 'Fornecedor B', 'Fornecedor b', 'Rua dos Bobos', 2);
INSERT INTO Pecas (CodigoPeca, Descricao,Peso, PrecoCusto, PrecoVenda, IdFornecedor)
	VALUES ('AA', 'Descricao...', 1, 20, 40, 1)
	,('BA', 'Descricao...', 2, 20, 40, 1)
	,('CA', 'Descricao...', 3, 40, 90, 2)
	,('DA', 'Descricao...', 4, 30, 40, 2);

------------------------ DQL ----------------------------

SELECT * FROM Usuarios ORDER BY IdUsuario;
SELECT * FROM Pecas ORDER BY IdPeca;
SELECT * FROM Fornecedores ORDER BY IdFornecedor;
SELECT * FROM Pecas WHERE IdFornecedor = 1;

SELECT IdUsuario, Email FROM Usuarios;
-- select * from Usuarios(DROP=Senha); 

