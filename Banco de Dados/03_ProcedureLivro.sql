USE BibliotecaDB

-- PROCEDURE Obter Dados 
GO
CREATE PROCEDURE ObterDados
	AS
	BEGIN
		SELECT *
		FROM Livros
	END
GO


-- PROCEDURE Atualizar Dados
GO
	CREATE PROCEDURE AtualizarDados
		@ID INT,
		@Titulo varchar(200),
		@Genero varchar(100),
		@Autor varchar(150),
		@Editora varchar(100),
		@ISBN varchar(20),
		@Quantidade int
	AS
	BEGIN
		
		UPDATE Livros
		SET
			Titulo = @Titulo,
			Genero = @Genero,
			Autor = @Autor,
			Editora = @Editora,
			ISBN = @ISBN,
			QuantidadeDisponivel = @Quantidade
		WHERE
			LivroID = @ID
	END
GO

-- PROCEDURE Deletar Livro
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
GO

-- PROCEDURE Insert Livros
GO
	CREATE PROCEDURE InserirDados
		@Titulo varchar(200),
		@Genero varchar(100),
		@Autor varchar(150),
		@Editora varchar(100),
		@ISBN varchar(20),
		@Quantidade int
	AS
	BEGIN
		INSERT INTO Livros(Titulo,Genero,Autor,Editora,ISBN,QuantidadeDisponivel)
		VALUES (@Titulo,@Genero,@Autor,@Editora,@ISBN,@Quantidade)
	END
GO





