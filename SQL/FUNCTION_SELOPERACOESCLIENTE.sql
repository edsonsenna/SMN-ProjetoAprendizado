IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_SelOperacoesCliente]') AND objectproperty(id, N'IsTableFunction')=1)
	DROP FUNCTION [dbo].[BNK_SelOperacoesCliente]
GO

CREATE FUNCTION [dbo].[BNK_SelOperacoesCliente]
	(@Num_SeqlConta INT)

	RETURNS TABLE

	AS

	/*
	Documentação
	Arquivo Fonte.....: FUNCTION_SELOPERACOESCLIENTE.sql
	Objetivo..........: Procedure criada para retornar todas as opera��es realizadas pela conta
						referente ao id passado como par�metro.
	Autor.............: SMN - Edson de Senna J�nior
 	Data..............: 01/08/2019
	Ex................: SELECT * FROM  [dbo].[BNK_SelOperacoesCliente] (@Num_SeqlConta)

	*/

	RETURN SELECT * FROM [dbo].[BNK_Operacao] WHERE Num_SeqlContaOrigem = @Num_SeqlConta;
GO