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
INSERT INTO Usuarios (Nome, Email, Telefone)
VALUES
('Alice Santos', 'alice.santos@email.com', '9999-0001'),
('Bruno Silva', 'bruno.silva@email.com', '9999-0002'),
('Camila Almeida', 'camila.almeida@email.com', '9999-0003'),
('Daniel Costa', 'daniel.costa@email.com', '9999-0004'),
('Elaine Souza', 'elaine.souza@email.com', '9999-0005'),
('Felipe Lima', 'felipe.lima@email.com', '9999-0006'),
('Gabriela Martins', 'gabriela.martins@email.com', '9999-0007'),
('Henrique Rocha', 'henrique.rocha@email.com', '9999-0008'),
('Isabela Dias', 'isabela.dias@email.com', '9999-0009'),
('João Henrique', 'joao.henrique@email.com', '9999-0010'),
('Karla Oliveira', 'karla.oliveira@email.com', '9999-0011'),
('Leonardo Santos', 'leonardo.santos@email.com', '9999-0012'),
('Mariana Lima', 'mariana.lima@email.com', '9999-0013'),
('Natan Alves', 'natan.alves@email.com', '9999-0014'),
('Olívia Costa', 'olivia.costa@email.com', '9999-0015'),
('Pedro Henrique', 'pedro.henrique@email.com', '9999-0016'),
('Raquel Martins', 'raquel.martins@email.com', '9999-0017'),
('Sérgio Rocha', 'sergio.rocha@email.com', '9999-0018'),
('Tatiane Dias', 'tatiane.dias@email.com', '9999-0019'),
('Victor Oliveira', 'victor.oliveira@email.com', '9999-0020')