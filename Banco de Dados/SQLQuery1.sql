

-- PROCEDURE REQUISIÇÕES

USE BibliotecaDB
    GO
        CREATE PROCEDURE ObterEmprestimos
        AS
        BEGIN
            SELECT * FROM Requisicoes
        END

    GO
    
    CREATE OR ALTER PROCEDURE EmprestarLivro
        @LivroIDEmprestado INT,
        @FuncinarioIDEmprestado INT,
        @UsuarioIDEmprestado INT
    AS
    BEGIN
        SET NOCOUNT ON;

            IF EXISTS (
                SELECT 1 
                FROM Livros 
                WHERE LivroID = @LivroIDEmprestado 
                  AND QuantidadeDisponivel > 0
            )
            BEGIN
            UPDATE Livros
            SET QuantidadeDisponivel = QuantidadeDisponivel - 1
            WHERE LivroID = @LivroIDEmprestado;

            
            INSERT INTO Requisicoes
                (UsuarioID, LivroID, FuncionarioID, DataDevolucao, Status)
            VALUES
                (@UsuarioIDEmprestado, @LivroIDEmprestado, @FuncinarioIDEmprestado,
                DATEADD(DAY, 7, GETDATE()), 'Aprovada');
            END
            ELSE
            BEGIN
                    RAISERROR('Livro indisponível ou inexistente.', 16, 1);
            END
    END

        --ALTER PROCEDURE EmprestarLivro
        --    @LivroIDEmprestado INT,
        --    @FuncinarioIDEmprestado INT,
        --    @UsuarioIDEmprestado INT
        --AS
        --BEGIN

        --UPDATE Livros
        --SET QuantidadeDisponivel = QuantidadeDisponivel - 1 
        --WHERE LivroID = @LivroIDEmprestado AND QuantidadeDisponivel > 0;

        --INSERT INTO Requisicoes (...)
        --VALUES (...)

        --    UPDATE Livros SET QuantidadeDisponivel = QuantidadeDisponivel - 1 
        --    WHERE LivroID = @LivroIDEmprestado AND QuantidadeDisponivel > 0;

        --    INSERT INTO Requisicoes(UsuarioID, LivroID, FuncionarioID, DataDevolucao,Status)
        --    VALUES(@UsuarioIDEmprestado,@LivroIDEmprestado,@FuncinarioIDEmprestado, DATEADD(DAY,7,GETDATE()),'Aprovada')
        --END
    GO



EXEC EmprestarLivro 20, 1,12 
SELECT * FROM Requisicoes

-- INSERTS USUÁRIOS

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


GO
    CREATE PROCEDURE DeletarUsuario
    @IdSelecionado INT
    AS
    BEGIN
        DELETE FROM Usuarios WHERE UsuarioID = @IdSelecionado
    END
GO

    select * from Livros


GO
    CREATE OR ALTER PROCEDURE verificarUsuario
        @usuario NVARCHAR(50),
        @senha VARCHAR(MAX)

    AS
    BEGIN
        SELECT FuncionarioID 
        FROM Funcionarios
        WHERE SenhaHash = HASHBYTES('SHA2_256',@senha) AND NomeUsuario = @usuario
    END


    EXEC verificarUsuario 'mpereira', 'Senha123!'


-- DELETE IN CASCADE
GO
    CREATE OR ALTER PROCEDURE DeletarLivro
        @ID INT
    AS 
    BEGIN
        SET NOCOUNT ON
        BEGIN TRANSACTION 
            DELETE FROM Requisicoes
            WHERE LivroID = @ID
            DELETE FROM Livros 
            WHERE LivroID = @ID
        COMMIT 
    END 
    EXEC DeletarLivro 22

-- TRIGGER 



CREATE OR ALTER TRIGGER devolucao
ON Requisicoes
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE R
    SET Status = 'Devolvido'
    FROM Requisicoes R
    INNER JOIN inserted I ON R.RequisicaoID = I.RequisicaoID
    WHERE I.DataDevolucao IS NOT NULL
      AND R.Status <> 'Devolvido';
END
GO





--GO
--    CREATE OR ALTER TRIGGER devolucao
--        ON Requisicoes
--        AFTER INSERT, UPDATE 
--    AS
--    BEGIN 
--        SET NOCOUNT ON
--        UPDATE Tabela 
--        SET  Status = 'Devolvido'
--        FROM Requisicoes Tabela 
--        WHERE Tabela.DataDevolucao IS NULL 

--    END
--GO

SELECT * FROM Requisicoes

select * from Livros
EXEC DeletarLivro 10


DROP TRIGGER devolucao