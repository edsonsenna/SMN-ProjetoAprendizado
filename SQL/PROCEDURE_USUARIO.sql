
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_VerAcesso]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_VerAcesso]
GO

CREATE PROCEDURE [dbo].[BNK_VerAcesso]

	@Nom_NomeUsuar VARCHAR(25),
	@Nom_SenhaUsuar VARCHAR(15)

	AS

	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_USUARIO.sql
	Objetivo..........: Procedure criada com o objetivo de verificar o acesso do usuario.
	Autor.............: SMN - Edson de Senna Júnior
 	Data..............: 08/08/2019
	Ex................: EXEC [dbo].[BNK_VerAcesso] 'edsonsjr', 'esj123'

	*/

	BEGIN
	
		SELECT
			u.Num_SeqlUsuar,
			u.Nom_NomeUsuar,
			u.Nom_SenhaUsuar
			FROM [dbo].[BNK_Usuario] u
				WHERE u.Nom_NomeUsuar = @Nom_NomeUsuar
				AND u.Nom_SenhaUsuar = @Nom_SenhaUsuar;

		

	END
GO

EXEC [dbo].[BNK_VerAcesso] 'edsonsjr', 'esj123'


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[BNK_SelContasCli]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[BNK_SelContasCli]
GO

CREATE PROCEDURE [dbo].[BNK_SelContasCli]
	
	@Num_SeqlUsuar INT

	AS

	/*
	Documentação
	Arquivo Fonte.....: PROCEDURE_USUARIO.sql
	Objetivo..........: Procedure criada com o intuito de buscar as contas vinculados a um usuario
	Autor.............: SMN - Edson de Senna Júnior
 	Data..............: 09/08/2019
	Ex................: EXEC [dbo].[BNK_SelContasCli]

	*/

	BEGIN
		SELECT
			c.Num_SeqlConta,
			c.Cod_TipoConta,
			c.Num_SeqlUsuar,
			c.Num_SaldoConta,
			c.Date_DataCriacao,
			tc.Nom_TipoConta,
			u.Nom_NomeUsuar
			FROM [dbo].[BNK_Conta] c
				INNER JOIN [dbo].[BNK_TipoConta] tc ON tc.Cod_TipoConta = c.Cod_TipoConta
				INNER JOIN [dbo].[BNK_Usuario] u ON u.Num_SeqlUsuar = c.Num_SeqlUsuar
				WHERE c.Num_SeqlUsuar = @Num_SeqlUsuar
	END
GO

EXEC [dbo].[BNK_SelContasCli] 1
				
				
				