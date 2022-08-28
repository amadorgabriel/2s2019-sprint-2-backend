CREATE DATABASE T_Peoples;
USE T_Peoples;

-- Pode Fazer tudo no mesmo Script
-- Script 01 : criar o banco de dados M_Peoples/T_Peoples; Tabela de Funcionarios contendo nome e sobrenome;
-- Script 02 : inserir os funcionários Catarina Strada e Tadeu Vitelli com os sobrenomes;
-- Script 03 : selecionar todos os registros;

CREATE TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(150) NOT NULL,
	Sobrenome VARCHAR(150) NOT NULL
);

INSERT INTO Funcionarios (Nome, Sobrenome) VALUES ('Catarina', 'Strada'), ('Tadeu', 'Vitelli');
SELECT * FROM Funcionarios;
SELECT * FROM Funcionarios WHERE IdFuncionario = 1;