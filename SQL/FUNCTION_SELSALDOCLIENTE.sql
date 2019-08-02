IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_SelSaldoCliente]') AND objectproperty(id, N'IsScalarFunction')=1)
	DROP FUNCTION [dbo].[BNK_SelSaldoCliente]
GO

CREATE FUNCTION [dbo].[BNK_SelSaldoCliente]
	(@Num_SeqlConta INT)
	RETURNS DECIMAL(18,2)
	AS

	/*
	Documentação
	Arquivo Fonte.....: FUNCTION_SELSALDOCLIENTE.sql
	Objetivo..........: Função criada com objetivo de verificar o saldo atual do cliente passado
						por parâmetro.
	Autor.............: SMN - Edson de Senna Junior
 	Data..............: 01/08/2019
	Ex................: SELECT  [dbo].[BNK_SelSaldoCliente](@Num_SeqlConta)

	*/

	BEGIN
		DECLARE @Saldo DECIMAL(18,2);

		SELECT @Saldo = Num_SaldoConta
			FROM [dbo].[BNK_Conta]
			WHERE [dbo].[BNK_Conta].Num_SeqlConta = @Num_SeqlConta;

		RETURN @Saldo;

	END
GO