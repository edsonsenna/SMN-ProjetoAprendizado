
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_InsOperacao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_InsOperacao]
GO

CREATE PROCEDURE [dbo].[BNK_InsOperacao]
	
	@Cod_TipoOperacao TINYINT,
	@Num_SeqlContaOrigem INT = NULL,
	@Num_SeqlContaDestino INT = NULL,
	@Num_ValorOperacao DECIMAL(18,2) = 0

	AS
	
	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_OPERACAO.sql
	Objetivo..........: Procedure criada com o objetivo de inserir na tabela de operações uma
						nova operação, em seguida atualizar o saldo das contas envolvidas. Re
						cebe como parâmetros o tipo da operação, os id's das contas envolvidas
						e o valor.
	Autor.............: SMN - Edson de Senna Junior
 	Data..............: 01/08/2019
	Ex................: EXEC [dbo].[BNK_InsOperacao] @Cod_TipoOperacao = 1, @Num_SeqlContaOrigem = 1, @Num_ValorOperacao = 20
	Retornos..........: 0 - Operação Sucesso
						1 - Operação Falha
	*/

	BEGIN

		DECLARE @Ind_SinalTipoOperacao SMALLINT;
		DECLARE @Valor_Final DECIMAL(18,2);
		DECLARE @Saldo_Cliente DECIMAL(18,2);

		SELECT @Ind_SinalTipoOperacao = Ind_SinalTipoOperacao 
			FROM [dbo].[BNK_TipoOperacao] WITH(NOLOCK)
			WHERE Cod_TipoOperacao = @Cod_TipoOperacao;

		SELECT @Saldo_Cliente = [dbo].[BNK_SelSaldoCliente] (@Num_SeqlContaOrigem);

		SET @Valor_Final = (COALESCE(@Ind_SinalTipoOperacao,1) * @Num_ValorOperacao);

		IF (@Saldo_Cliente + @Valor_Final) < 0
			RETURN 1;
		ELSE
			INSERT INTO [dbo].[BNK_Operacao] VALUES(@Cod_TipoOperacao, @Num_SeqlContaOrigem, @Num_SeqlContaDestino, @Valor_Final, GETDATE());

			RETURN 0;
			
	END
GO

EXEC [dbo].[BNK_InsOperacao] @Cod_TipoOperacao = 2, @Num_SeqlContaOrigem = 1, @Num_ValorOperacao = 20


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_AttOperacao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_AttOperacao]
GO

CREATE PROCEDURE [dbo].[BNK_AttOperacao]
	
	@Cod_TipoOperacao TINYINT,
	@Num_SeqlContaOrigem INT = NULL,
	@Num_SeqlContaDestino INT = NULL,
	@Num_ValorOperacao DECIMAL(18,2) = 0

	AS
	
	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_OPERACAO.sql
	Objetivo..........: Procedure criada com o objetivo de atualizar o saldo das contas envolvidas. Re
						cebe como parâmetros o tipo da operação, os id's das contas envolvidas
						e o valor.
	Autor.............: SMN - Edson de Senna Junior
 	Data..............: 01/08/2019
	Ex................: EXEC [dbo].[BNK_AttOperacao] @Cod_TipoOperacao = 1, @Num_SeqlContaOrigem = 1, @Num_ValorOperacao = 20
	Retornos..........: 0 - Operação Sucesso
						1 - Operação Falha
	*/

	BEGIN

		DECLARE @Ind_SinalTipoOperacao SMALLINT;
		DECLARE @Valor_Final DECIMAL(18,2);
		DECLARE @Saldo_Cliente DECIMAL(18,2);

		SELECT @Ind_SinalTipoOperacao = Ind_SinalTipoOperacao 
			FROM [dbo].[BNK_TipoOperacao] WITH(NOLOCK)
			WHERE Cod_TipoOperacao = @Cod_TipoOperacao;

		SELECT @Saldo_Cliente = [dbo].[BNK_SelSaldoCliente] (@Num_SeqlContaOrigem);

		SET @Valor_Final = (COALESCE(@Ind_SinalTipoOperacao,1) * @Num_ValorOperacao);

		IF (@Saldo_Cliente + @Valor_Final) < 0
			RETURN 1;
		ELSE

			IF @Num_SeqlContaDestino = NULL
				UPDATE [dbo].[BNK_Conta] SET Num_SaldoConta += @Valor_Final WHERE Num_SeqlConta = @Num_SeqlContaOrigem; 
			ELSE
				UPDATE [dbo].[BNK_Conta] SET Num_SaldoConta += @Valor_Final WHERE Num_SeqlConta = @Num_SeqlContaOrigem; 
				UPDATE [dbo].[BNK_Conta] SET Num_SaldoConta -= @Valor_Final WHERE Num_SeqlConta = @Num_SeqlContaDestino;

			RETURN 0;
			
	END
GO

EXEC [dbo].[BNK_AttOperacao] @Cod_TipoOperacao = 2, @Num_SeqlContaOrigem = 1, @Num_ValorOperacao = 20		

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_SelOperacoesCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_SelOperacoesCliente]
GO

CREATE PROCEDURE [dbo].[BNK_SelOperacoesCliente]
	
	@Num_SeqlConta INT

	AS

	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_OPERACAO.sql
	Objetivo..........: Procedure criada para retornar todas as operações realizadas pela conta
						referente ao id passado como parâmetro.
	Autor.............: SMN - Edson de Senna Junior
 	Data..............: 01/08/2019
	Ex................: EXEC [dbo].[BNK_SelOperacoesCliente] @Num_SeqlConta

	*/

	BEGIN
	
		SELECT 
			o.Cod_TipoOperacao,
			o.Num_SeqlContaOrigem,
			o.Num_SeqlContaDestino,
			o.Num_ValorOperacao,
			o.Date_DataOperacao,
			o.Num_SeqlOperacao,
			tpo.Nom_TipoOperacao 
				FROM [dbo].[BNK_Operacao] o
				INNER JOIN [dbo].[BNK_TipoOperacao] tpo ON tpo.Cod_TipoOperacao = o.Cod_TipoOperacao
				WHERE o.Num_SeqlContaOrigem = @Num_SeqlConta;

	END
GO
				
EXEC [dbo].[BNK_SelOperacoesCliente] 1
