IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_SelOperacoesCliente]') AND objectproperty(id, N'IsTableFunction')=1)
	DROP FUNCTION [dbo].[BNK_SelOperacoesCliente]
GO

CREATE FUNCTION [dbo].[BNK_SelOperacoesCliente]
	(@Num_SeqlConta INT)

	RETURNS TABLE

	AS

	/*
	DocumentaÃ§Ã£o
	Arquivo Fonte.....: FUNCTION_SELOPERACOESCLIENTE.sql
	Objetivo..........: Procedure criada para retornar todas as operações realizadas pela conta
						referente ao id passado como parâmetro.
	Autor.............: SMN - Edson de Senna Júnior
 	Data..............: 01/08/2019
	Ex................: SELECT * FROM  [dbo].[BNK_SelOperacoesCliente] (@Num_SeqlConta)

	*/

	RETURN SELECT * FROM [dbo].[BNK_Operacao] WHERE Num_SeqlContaOrigem = @Num_SeqlConta;
GO