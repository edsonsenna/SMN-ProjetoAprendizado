BEGIN TRANSACTION

	INSERT INTO SMN_Bank.dbo.BNK_Usuario
		VALUES  ('edsonsjr', 'esj123', GETDATE()),
				('edson', 'esj123', GETDATE());

	IF @@ERROR <> 0
		ROLLBACK;

	INSERT INTO SMN_Bank.dbo.BNK_TipoConta
		VALUES	(1, 'POUPANÇA'),
				(2, 'CONTA CORRENTE');

	IF @@ERROR <> 0
		ROLLBACK;

	INSERT INTO SMN_Bank.dbo.BNK_Conta
		VALUES	('EDSON', 0, 1, 1, GETDATE()),
				('SENNA', 0, 1, 2, GETDATE()),
				('LUCAS', 0, 2, 1, GETDATE());

	IF @@ERROR <> 0
		ROLLBACK;

	INSERT INTO SMN_Bank.dbo.BNK_TipoOperacao
		VALUES	(1, 'SAQUE', -1),
				(2, 'DEPÓSITO', 1),
				(3, 'TRANSFERÊNCIA', -1),
				(4, 'ESTORNO', 1);

	IF @@ERROR <> 0
		ROLLBACK;

	COMMIT TRANSACTION;