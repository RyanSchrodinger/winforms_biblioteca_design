USE BibliotecaDB



-- Tabela de Usuários
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Telefone NVARCHAR(15),
    DataCadastro DATETIME DEFAULT GETDATE()
)
GO



-- Tabela de Funcionários (Opcional)
CREATE TABLE Funcionarios (
    FuncionarioID INT PRIMARY KEY IDENTITY(1,1),
    NomeUsuario NVARCHAR(50) NOT NULL UNIQUE,
    SenhaHash NVARCHAR(255) NOT NULL,
    NomeCompleto NVARCHAR(100) NOT NULL,
	Cargo text NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DataCadastro DATETIME DEFAULT GETDATE(),
    UltimoLogin DATETIME NULL,
    Ativo BIT DEFAULT 1
)
GO

-- Tabela de Requisições
CREATE TABLE Requisicoes (
    RequisicaoID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL,
    LivroID INT NOT NULL,
    FuncionarioID INT NULL, -- Caso um funcionário processe a requisição
    DataRequisicao DATETIME DEFAULT GETDATE(),
    DataDevolucao DATETIME NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Pendente', 'Aprovada', 'Devolvido')) NOT NULL DEFAULT 'Pendente',
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (LivroID) REFERENCES Livros(LivroID),
    FOREIGN KEY (FuncionarioID) REFERENCES Funcionarios(FuncionarioID)
)

-- INSERTS USUARIOS