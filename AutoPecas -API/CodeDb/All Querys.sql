/*
A empresa AutoPe�as � uma administradora e convidou voc� a desenvolver uma nova API para que seja poss�vel realizar a disponibiliza��o dos registros de suas pe�as de cada fornecedor.
Devemos considerar os crit�rios mencionados abaixo:
- Cada fornecedor poder� cadastrar pe�as;
- Quando os fornecedores listarem as pe�as, dever�o listar somente as suas.
-- Por exemplo, quando o Fornecedor A cadastrar a 'Pe�a 1' e a 'Pe�a 2' e o Fornecedor B cadastrar a 'Pe�a 3' e 'Pe�a 4', ao Fornecedor A solicitar a lista de pe�as, dever� aparecer somente as Pe�as: 1 e 2.

Voc� dever� ser capaz de desenvolver os seguintes t�picos abaixo:

+ Banco de Dados

Script contendo a cria��o do banco, das tabelas e seus determinados registros.
- autopecas_script.sql
M_AutoPecas | T_AutoPecas

Tabelas contendo os seguintes dados:
- Pe�as - c�digo da pe�a (que o fornecedor define), descricao, peso, pre�o de custo, pre�o de venda e somente um fornecedor vinculado;
- Fornecedores - cnpj, raz�o social, nome fantasia, endere�o e possui somente um usu�rio vinculado;
- Usu�rios - email e senha.

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

