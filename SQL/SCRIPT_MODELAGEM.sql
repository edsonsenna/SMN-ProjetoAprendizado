CREATE TABLE BNK_TipoConta(
	Cod_TipoConta TINYINT,
	Nom_TipoConta VARCHAR(25),
	CONSTRAINT PK_TipoConta PRIMARY KEY (Cod_TipoConta)
);

CREATE TABLE BNK_Conta(
	Num_SeqlConta INT IDENTITY(1,1),
	Nom_ClienteConta VARCHAR(150),
	Num_SaldoConta DECIMAL(18,2),
	Cod_TipoConta TINYINT,
	Date_DataCriacao DATETIME DEFAULT GETDATE(),

	CONSTRAINT PK_Conta PRIMARY KEY (Num_SeqlConta),
	CONSTRAINT FK_TipoConta_Conta FOREIGN KEY (Cod_TipoConta)
    REFERENCES BNK_TipoConta(Cod_TipoConta)
);


CREATE TABLE BNK_TipoOperacao(
	Cod_TipoOperacao TINYINT,
	Nom_TipoOperacao VARCHAR(25),
	Ind_SinalTipoOperacao SMALLINT,

	CONSTRAINT PK_TipoOperacao PRIMARY KEY(Cod_TipoOperacao)
);

CREATE TABLE BNK_Operacao(
	Num_SeqlOperacao INT IDENTITY(1,1),
	Cod_TipoOperacao TINYINT,
	Num_SeqlContaOrigem INT,
	Num_SeqlContaDestino INT,
	Num_ValorOperacao DECIMAL(18,2),
	Date_DataOperacao DATETIME DEFAULT GETDATE(),

	CONSTRAINT PK_Operacao PRIMARY KEY (Num_SeqlOperacao),
	CONSTRAINT FK_TipoOperacao_Operacao FOREIGN KEY (Cod_TipoOperacao)
	REFERENCES BNK_TipoOperacao(Cod_TipoOperacao),
	CONSTRAINT FK1_Conta_Operacao FOREIGN KEY (Num_SeqlContaOrigem)
	REFERENCES BNK_Conta(Num_SeqlConta),
	CONSTRAINT FK2_Conta_Operacao FOREIGN KEY (Num_SeqlContaDestino)
	REFERENCES BNK_Conta(Num_SeqlConta)

);