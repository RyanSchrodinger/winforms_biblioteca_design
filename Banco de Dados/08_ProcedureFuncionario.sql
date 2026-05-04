USE BibliotecaDB


-- PROCEDURE Obter Funcionários

GO
	CREATE PROCEDURE ObterFuncionarios
	@ID INT
	AS
	BEGIN
		SELECT * FROM Funcionarios
	END

GO

-- PROCEDURE Deletar Funcionários (cascade)