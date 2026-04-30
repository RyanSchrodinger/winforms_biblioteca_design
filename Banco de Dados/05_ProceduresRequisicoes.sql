USE BibliotecaDB

-- PROCEDURE Obter Emprestimos 

  GO
        CREATE PROCEDURE ObterEmprestimos
        AS
        BEGIN
            SELECT * FROM Requisicoes
        END

   GO

-- PROCEDURE Emprestar Livro

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