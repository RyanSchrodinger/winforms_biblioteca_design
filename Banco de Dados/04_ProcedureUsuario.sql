USE BibliotecaDB

-- PROCEDURE Obter Dados

GO
CREATE PROCEDURE ObterDadosUsuario
AS
BEGIN
	SELECT * FROM Usuarios
END
GO

-- PROCEDURE Deletar Usuarios

GO
    CREATE OR ALTER PROCEDURE DeletarLivro
        @ID INT
    AS 
    BEGIN
        SET NOCOUNT ON
        BEGIN TRANSACTION 
            DELETE FROM Requisicoes
            WHERE UsuarioID = @ID
            DELETE FROM Usuarios 
            WHERE UsuarioID = @ID
        COMMIT 
    END 
GO

-- PROCEDURE Inserir Usuario

GO
	CREATE PROCEDURE InserirDadosUsuarios
		@Nome varchar(100),
		@Email varchar(100),
		@Telefone varchar(15)
	AS
	BEGIN
		INSERT INTO Usuarios(Nome,Email,Telefone)
		VALUES (@Nome,@Email,@Telefone)
	END
GO

-- PROCEDURE Atualizar Usuario 

GO
    CREATE PROCEDURE AtualizarUsuarios
    @IdSelecionado INT,
    @Nome VARCHAR(100),
    @Email VARCHAR(100),
    @Telefone VARCHAR(100)
    AS
    BEGIN
        UPDATE Usuarios
        SET
            Nome = @Nome,
            Email = @Email,
            Telefone = @Telefone
        WHERE
            UsuarioID = @IdSelecionado
    END
GO


 SELECT*FROM Funcionarios