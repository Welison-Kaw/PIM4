/******************************************/
-- LIMPA SCHEMA
/******************************************/

-- DROPA CONSTRAINTS

PRINT '**************************'
PRINT '*******  INICIADO  *******'
PRINT '**************************'
PRINT CHAR(13)

IF OBJECT_ID('FK_DEPARTAMENTO_SETOR') IS NOT NULL
	ALTER TABLE DEPARTAMENTO DROP CONSTRAINT FK_DEPARTAMENTO_SETOR

IF OBJECT_ID('FK_CLIENTE_DEPARTAMENTO') IS NOT NULL
	ALTER TABLE CLIENTE DROP CONSTRAINT FK_CLIENTE_DEPARTAMENTO

IF OBJECT_ID('FK_FUNCIONARIO_DEPARTAMENTO') IS NOT NULL
	ALTER TABLE FUNCIONARIO DROP CONSTRAINT FK_FUNCIONARIO_DEPARTAMENTO

IF OBJECT_ID('FK_CHAMADO_DEPARTAMENTO') IS NOT NULL
	ALTER TABLE CHAMADO DROP CONSTRAINT FK_CHAMADO_DEPARTAMENTO

IF OBJECT_ID('FK_CHAMADO_GRAU_URGENCIA') IS NOT NULL
	ALTER TABLE CHAMADO DROP CONSTRAINT FK_CHAMADO_GRAU_URGENCIA

IF OBJECT_ID('FK_CHAMADO_CLIENTE') IS NOT NULL
	ALTER TABLE CHAMADO DROP CONSTRAINT FK_CHAMADO_CLIENTE

IF OBJECT_ID('FK_CHAMADO_ATRIBUICAO') IS NOT NULL
	ALTER TABLE CHAMADO DROP CONSTRAINT FK_CHAMADO_ATRIBUICAO

IF OBJECT_ID('FK_CHAMADO_FUNCIONARIO') IS NOT NULL
	ALTER TABLE CHAMADO DROP CONSTRAINT FK_CHAMADO_FUNCIONARIO
PRINT 'DROP CONSTRAINTS'

-- DROPA TABLES

IF OBJECT_ID('SETOR') IS NOT NULL
	DROP TABLE SETOR

IF OBJECT_ID('DEPARTAMENTO') IS NOT NULL
	DROP TABLE DEPARTAMENTO

IF OBJECT_ID('GRAU_URGENCIA') IS NOT NULL
	DROP TABLE GRAU_URGENCIA

IF OBJECT_ID('CLIENTE') IS NOT NULL
	DROP TABLE CLIENTE

IF OBJECT_ID('FUNCIONARIO') IS NOT NULL
	DROP TABLE FUNCIONARIO

IF OBJECT_ID('ATRIBUICAO') IS NOT NULL
	DROP TABLE ATRIBUICAO

IF OBJECT_ID('CHAMADO') IS NOT NULL
	DROP TABLE CHAMADO
PRINT 'DROP TABLES'

/******************************************/
-- CRIA TABLES
/******************************************/
	
CREATE TABLE SETOR
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(50) NOT NULL
);

CREATE TABLE DEPARTAMENTO
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(50) NOT NULL,
	SETOR INT
);

CREATE TABLE GRAU_URGENCIA
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(50) NOT NULL
);

CREATE TABLE CLIENTE
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(150) NOT NULL,
	EMAIL VARCHAR(100) NOT NULL,
	SENHA VARCHAR(16) NOT NULL,
	DEPARTAMENTO INT NOT NULL
);

CREATE TABLE FUNCIONARIO
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(150) NOT NULL,
	EMAIL VARCHAR(100) NOT NULL,
	SENHA VARCHAR(16) NOT NULL,
	DEPARTAMENTO INT NOT NULL
);

CREATE TABLE ATRIBUICAO
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(100) NOT NULL
);

CREATE TABLE CHAMADO
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DEPARTAMENTO INT NOT NULL,
	GRAU_URGENCIA INT NOT NULL,
	--ANDAR VARCHAR(10) NOT NULL,
	TITULO VARCHAR(100) NOT NULL,
	DESCRICAO VARCHAR(500) NOT NULL,
	CLIENTE INT NOT NULL,
	FUNCIONARIO INT NULL,
	ATRIBUICAO INT NOT NULL,
	CONCLUSAO DATETIME
);
PRINT 'CREATE TABLES'

/******************************************/
-- CRIA CONSTRAINTS
/******************************************/

ALTER TABLE DEPARTAMENTO	ADD CONSTRAINT FK_DEPARTAMENTO_SETOR		FOREIGN KEY	(SETOR)			REFERENCES SETOR(ID)
ALTER TABLE CLIENTE			ADD CONSTRAINT FK_CLIENTE_DEPARTAMENTO		FOREIGN KEY	(DEPARTAMENTO)	REFERENCES DEPARTAMENTO(ID)
ALTER TABLE FUNCIONARIO		ADD CONSTRAINT FK_FUNCIONARIO_DEPARTAMENTO	FOREIGN KEY (DEPARTAMENTO)	REFERENCES DEPARTAMENTO(ID)
ALTER TABLE CHAMADO			ADD CONSTRAINT FK_CHAMADO_DEPARTAMENTO		FOREIGN KEY (DEPARTAMENTO)	REFERENCES DEPARTAMENTO(ID)
ALTER TABLE CHAMADO			ADD CONSTRAINT FK_CHAMADO_GRAU_URGENCIA		FOREIGN KEY (GRAU_URGENCIA)	REFERENCES GRAU_URGENCIA(ID)
ALTER TABLE CHAMADO			ADD CONSTRAINT FK_CHAMADO_CLIENTE			FOREIGN KEY (CLIENTE)		REFERENCES CLIENTE(ID)
ALTER TABLE CHAMADO			ADD CONSTRAINT FK_CHAMADO_ATRIBUICAO		FOREIGN KEY (ATRIBUICAO)	REFERENCES ATRIBUICAO(ID)
ALTER TABLE CHAMADO			ADD CONSTRAINT FK_CHAMADO_FUNCIONARIO		FOREIGN KEY (FUNCIONARIO)	REFERENCES FUNCIONARIO(ID)
PRINT 'CREATE CONSTRAINTS'

/******************************************/
-- POPULA TABLES
/******************************************/
PRINT CHAR(13)+'POPULA TABLES'
SET NOCOUNT ON

SET IDENTITY_INSERT SETOR ON

INSERT INTO SETOR(ID, NOME) VALUES (1, 'Administrativo')
INSERT INTO SETOR(ID, NOME) VALUES (2, 'Recursos Humanos')
INSERT INTO SETOR(ID, NOME) VALUES (3, 'Financeiro')
INSERT INTO SETOR(ID, NOME) VALUES (4, 'Tecnologia')
INSERT INTO SETOR(ID, NOME) VALUES (5, 'Operacional')

SET IDENTITY_INSERT SETOR OFF

PRINT CHAR(9)+'-SETOR'

SET IDENTITY_INSERT DEPARTAMENTO ON
INSERT INTO DEPARTAMENTO(ID, NOME, SETOR) VALUES (1, 'Teste', 1)
INSERT INTO DEPARTAMENTO(ID, NOME, SETOR) VALUES (2, 'Manuten�ao', 4)
INSERT INTO DEPARTAMENTO(ID, NOME, SETOR) VALUES (3, 'Compras', 5)
INSERT INTO DEPARTAMENTO(ID, NOME, SETOR) VALUES (4, 'Vendas', 5)
SET IDENTITY_INSERT DEPARTAMENTO OFF

PRINT CHAR(9)+'-DEPARTAMENTO'

SET IDENTITY_INSERT GRAU_URGENCIA ON
INSERT INTO GRAU_URGENCIA(ID, NOME) VALUES (1, 'Muito Baixo')
INSERT INTO GRAU_URGENCIA(ID, NOME) VALUES (2, 'Baixo')
INSERT INTO GRAU_URGENCIA(ID, NOME) VALUES (3, 'M�dio')
INSERT INTO GRAU_URGENCIA(ID, NOME) VALUES (4, 'Alto')
INSERT INTO GRAU_URGENCIA(ID, NOME) VALUES (5, 'Muito Alto')
SET IDENTITY_INSERT GRAU_URGENCIA OFF

PRINT CHAR(9)+'-GRAU_URGENCIA'

SET IDENTITY_INSERT CLIENTE ON
INSERT INTO CLIENTE(ID, NOME, EMAIL, SENHA, DEPARTAMENTO) VALUES (1, 'Bruno', 'bruno@unip.com.br', 'bruno123', 1)
INSERT INTO CLIENTE(ID, NOME, EMAIL, SENHA, DEPARTAMENTO) VALUES (2, 'Erick', 'erick@unip.com.br', 'erick123', 2)
SET IDENTITY_INSERT CLIENTE OFF

PRINT CHAR(9)+'-CLIENTE'

SET IDENTITY_INSERT FUNCIONARIO ON
INSERT INTO FUNCIONARIO(ID, NOME, EMAIL, SENHA, DEPARTAMENTO) VALUES (1, 'Adilanne', 'adilanne@unip.com.br', 'adilanne123', 1)
INSERT INTO FUNCIONARIO(ID, NOME, EMAIL, SENHA, DEPARTAMENTO) VALUES (2, 'Kelvin', 'kelvin@unip.com.br', 'kelvin123', 2)
INSERT INTO FUNCIONARIO(ID, NOME, EMAIL, SENHA, DEPARTAMENTO) VALUES (3, 'Welison', 'welison@unip.com.br', 'welison123', 3)
SET IDENTITY_INSERT FUNCIONARIO OFF

PRINT CHAR(9)+'-CLIENTE'

SET IDENTITY_INSERT ATRIBUICAO ON
INSERT INTO ATRIBUICAO(ID, NOME) VALUES (1, 'Aberto')
INSERT INTO ATRIBUICAO(ID, NOME) VALUES (2, 'Atribuido')
INSERT INTO ATRIBUICAO(ID, NOME) VALUES (3, 'Pausado')
INSERT INTO ATRIBUICAO(ID, NOME) VALUES (4, 'Conclu�do')
INSERT INTO ATRIBUICAO(ID, NOME) VALUES (5, 'Reaberto')
SET IDENTITY_INSERT ATRIBUICAO OFF

PRINT CHAR(9)+'-FUNCIONARIO'

SET IDENTITY_INSERT CHAMADO ON
INSERT INTO CHAMADO (ID, DEPARTAMENTO, GRAU_URGENCIA, TITULO, DESCRICAO, CLIENTE, FUNCIONARIO, ATRIBUICAO, CONCLUSAO)
VALUES (1, 1, 3, 'TITULO TESTE', 'DESCRICAO TITULO QUEBRADO', 1, 2, 1, NULL)
INSERT INTO CHAMADO (ID, DEPARTAMENTO, GRAU_URGENCIA, TITULO, DESCRICAO, CLIENTE, FUNCIONARIO, ATRIBUICAO, CONCLUSAO)
VALUES (2, 2, 5, 'TROCAR TECLADO', 'DESCRICAO DO MOTIVO DA TROCA DO TECLADO', 2, 3, 2, NULL)
SET IDENTITY_INSERT CHAMADO OFF

PRINT CHAR(9)+'-CHAMADO'

SET NOCOUNT OFF

PRINT CHAR(13)
PRINT '****************************'
PRINT '*******  FINALIZADO  *******'
PRINT '****************************'