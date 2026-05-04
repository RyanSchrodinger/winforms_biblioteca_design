USE BibliotecaDB


-- PROCEDURE Obter Funcionários

GO
	CREATE OR ALTER PROCEDURE ObterFuncionarios
	--@ID INT brisei com esse parametro jesus
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

-- PROCEDURE Inserir Funcionários

GO
    CREATE PROCEDURE InserirFuncionario
    @NomeUsuario VARCHAR(100),
    @SenhaHash VARCHAR(100),
    @NomeCompleto VARCHAR(100),
    @Cargo VARCHAR (100)
    AS
    BEGIN
        INSERT INTO Funcionarios(NomeCompleto, NomeUsuario, SenhaHash, Cargo)
        VALUES (@NomeCompleto,@NomeUsuario,@SenhaHash,@Cargo)
    END
GO
 
-- PROCEDURE Atualizar Funcionário

GO
    CREATE PROCEDURE AtualizarFuncionario
    @ID INT,
    @NomeUsuario VARCHAR(100),
    @NomeCompleto VARCHAR(100),
    @Cargo VARCHAR (100)
    AS
    BEGIN
        UPDATE Funcionarios
        SET 
            NomeCompleto = @NomeCompleto,
            Cargo = @Cargo,
            NomeUsuario = @NomeUsuario
        WHERE 
            FuncionarioID = @ID
    END
GO