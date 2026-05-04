USE BibliotecaDB

GO

CREATE PROCEDURE DevolverLivro
    @RequisicaoID INT
AS
BEGIN
    -- Atualiza a requisição
    UPDATE Requisicoes
    SET 
        Status = 'Devolvido',
        DataDevolucao = GETDATE()
    WHERE RequisicaoID = @RequisicaoID
    AND Status = 'Aprovada'

    -- Atualiza estoque do livro
    UPDATE Livros
    SET QuantidadeDisponivel = QuantidadeDisponivel + 1
    WHERE LivroID = (
        SELECT LivroID 
        FROM Requisicoes 
        WHERE RequisicaoID = @RequisicaoID
    )
END
GO