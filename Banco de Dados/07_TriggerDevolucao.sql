USE BibliotecaDB

-- TRIGGER 
GO
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

