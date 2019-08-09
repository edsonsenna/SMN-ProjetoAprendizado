

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_SelInfoCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_SelInfoCliente]
GO

CREATE PROCEDURE [dbo].[BNK_SelInfoCliente]
	
	@Num_SeqlConta INT

	AS

	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_CONTA.sql
	Objetivo..........: Proc criado para retornar os dados de uma conta
	Autor.............: SMN - Edson de Senna Júnior
 	Data..............: 07/08/2019
	Ex................: EXEC [dbo].[BNK_SelInfoCliente] 1

	*/

	BEGIN
	
		SELECT
			i.Cod_TipoConta,
			i.Nom_ClienteConta,
			i.Num_SaldoConta,
			i.Num_SeqlConta,
			i.Date_DataCriacao,
			i.Num_SeqlUsuar,
			tpc.Nom_TipoConta,
			u.Nom_NomeUsuar
			FROM [dbo].[BNK_Conta] i
			INNER JOIN [dbo].[BNK_TipoConta] tpc ON tpc.Cod_TipoConta = i.Cod_TipoConta
			INNER JOIN [dbo].[BNK_Usuario] u ON u.Num_SeqlUsuar = i.Num_SeqlUsuar
			WHERE i.Num_SeqlConta = @Num_SeqlConta

	END
GO

EXEC [dbo].[BNK_SelInfoCliente] 1


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_AttConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_AttConta]
GO

CREATE PROCEDURE [dbo].[BNK_AttConta]

	@Num_SeqlConta INT,
	@Cod_TipoConta TINYINT

	AS

	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_CONTA.sql
	Objetivo..........: Procedure criada com o objetivo de atualizar as informações de uma conta
	Autor.............: SMN - Edson de Senna Júnior
 	Data..............: 08/08/2019
	Ex................: EXEC [dbo].[BNK_AttConta] 1, 1, "EDSON Jr"

	*/

	BEGIN
		UPDATE [dbo].BNK_Conta 
			SET Cod_TipoConta = @Cod_TipoConta
			WHERE Num_SeqlConta = @Num_SeqlConta;

		RETURN 0;
		
	END
GO

EXEC [dbo].[BNK_AttConta] 1, 1

