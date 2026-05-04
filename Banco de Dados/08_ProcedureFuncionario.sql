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
GO
    CREATE OR ALTER PROCEDURE DeletarFuncionario
        @ID INT
    AS 
    BEGIN
        SET NOCOUNT ON
        BEGIN TRANSACTION 
            DELETE FROM Requisicoes
            WHERE FuncionarioID = @ID
            DELETE FROM Funcionarios
            WHERE FuncionarioID = @ID
        COMMIT 
    END 
GO

