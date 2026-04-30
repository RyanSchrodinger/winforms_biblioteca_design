USE BibliotecaDB

-- PROCEDURE LOGIN

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
GO


    --EXEC verificarUsuario 'mpereira', 'Senha123!'
