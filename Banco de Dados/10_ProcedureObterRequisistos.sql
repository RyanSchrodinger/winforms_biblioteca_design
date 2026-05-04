USE BibliotecaDB

GO
	CREATE OR ALTER PROCEDURE  ObterRequisicoesAprovadas
	AS
	BEGIN
		SELECT * FROM Requisicoes
		WHERE Status = 'Aprovada'
	END
GO


