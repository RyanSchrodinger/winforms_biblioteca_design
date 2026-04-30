USE BibliotecaDB


-- INSERTS LIVROS
INSERT INTO Livros (Titulo, Genero, Autor, Editora, ISBN, QuantidadeDisponivel)
VALUES
('O Senhor dos Anéis - A Sociedade do Anel', 'Fantasia', 'J.R.R. Tolkien', 'HarperCollins', '978-0261102354', 5),
('1984', 'Distopia', 'George Orwell', 'Companhia das Letras', '978-0451524935', 7),
('O Pequeno Príncipe', 'Ficção', 'Antoine de Saint-Exupéry', 'Agir', '978-0156013987', 8),
('Dom Casmurro', 'Realismo', 'Machado de Assis', 'Global Editora', '978-8520912250', 3),
('Cem Anos de Solidão', 'Realismo Mágico', 'Gabriel Garcia Marquez', 'Record', '978-0060883287', 4),
('O Alquimista', 'Ficção', 'Paulo Coelho', 'Rocco', '978-0061122415', 6),
('A Revolução dos Bichos', 'Distopia', 'George Orwell', 'Companhia das Letras', '978-0451526342', 5),
('Orgulho e Preconceito', 'Romance', 'Jane Austen', 'Martins Fontes', '978-0141439518', 9),
('A Metamorfose', 'Ficção', 'Franz Kafka', 'Companhia das Letras', '978-0553213690', 4),
('O Código Da Vinci', 'Mistério', 'Dan Brown', 'Arqueiro', '978-0307474278', 7),
('A Cabana', 'Ficção', 'William P. Young', 'Vida', '978-1416524803', 6),
('A Menina que Roubava Livros', 'Drama', 'Markus Zusak', 'Intrínseca', '978-0375842207', 5),
('O Hobbit', 'Fantasia', 'J.R.R. Tolkien', 'HarperCollins', '978-0547928227', 10),
('A Sombra do Vento', 'Mistério', 'Carlos Ruiz Zafón', 'Suma', '978-0143126393', 6),
('O Morro dos Ventos Uivantes', 'Romance', 'Emily Brontë', 'Penguin', '978-0141439556', 7),
('Memórias Póstumas de Brás Cubas', 'Realismo', 'Machado de Assis', 'Penguin', '978-0142437635', 4),
('Como Fazer Amigos e Influenciar Pessoas', 'Autoajuda', 'Dale Carnegie', 'Companhia Editora Nacional', '978-0671027032', 8),
('O Diário de Anne Frank', 'Biografia', 'Anne Frank', 'Companhia das Letras', '978-0553296983', 6),
('A Arte da Guerra', 'Estratégia', 'Sun Tzu', 'Best Seller', '978-1599869773', 7),
('Sapiens: Uma Breve História da Humanidade', 'História', 'Yuval Noah Harari', 'Companhia das Letras', '978-0062316097', 10),
('O Andar do Bêbado', 'Ciência', 'Leonard Mlodinow', 'Intrínseca', '978-0385523864', 5),
('Mindset: A Nova Psicologia do Sucesso', 'Psicologia', 'Carol S. Dweck', 'Objetiva', '978-0345472328', 6),
('Os Miseráveis', 'Drama', 'Victor Hugo', 'Penguin', '978-0451419439', 4),
('O Poder do Hábito', 'Autoajuda', 'Charles Duhigg', 'Objetiva', '978-0812981605', 8),
('O Chamado de Cthulhu', 'Terror', 'H.P. Lovecraft', 'DarkSide Books', '978-0142437956', 5),
('O Menino do Pijama Listrado', 'Drama', 'John Boyne', 'Companhia das Letras', '978-0385751537', 6),
('O Silmarillion', 'Fantasia', 'J.R.R. Tolkien', 'HarperCollins', '978-0618391110', 3),
('A Guerra dos Tronos', 'Fantasia', 'George R.R. Martin', 'Leya', '978-0553593716', 7),
('A Revolta de Atlas', 'Ficção', 'Ayn Rand', 'L&PM', '978-0452011870', 5),
('Brida', 'Ficção', 'Paulo Coelho', 'Rocco', '978-0061762708', 6),
('O Processo', 'Drama', 'Franz Kafka', 'Companhia das Letras', '978-0553213683', 4),
('Ensaio sobre a Cegueira', 'Drama', 'José Saramago', 'Companhia das Letras', '978-8572329440', 6),
('O Sol é para Todos', 'Drama', 'Harper Lee', 'Leya', '978-0060935467', 7),
('Veronika Decide Morrer', 'Drama', 'Paulo Coelho', 'Rocco', '978-0061125693', 5),
('O Livro dos Baltimore', 'Ficção', 'Joël Dicker', 'Intrínseca', '978-8551000482', 4),
('O Conto da Aia', 'Distopia', 'Margaret Atwood', 'Rocco', '978-0385490818', 8),
('O Lado Bom da Vida', 'Drama', 'Matthew Quick', 'Intrínseca', '978-0385527879', 6),
('A Culpa é das Estrelas', 'Drama', 'John Green', 'Intrínseca', '978-0525478812', 7),
('Percy Jackson e o Ladrão de Raios', 'Fantasia', 'Rick Riordan', 'Intrínseca', '978-0786838653', 9),
('A Menina que Brincava com Fogo', 'Mistério', 'Stieg Larsson', 'Companhia das Letras', '978-0307949486', 5),
('O Príncipe', 'Política', 'Maquiavel', 'Companhia Editora Nacional', '978-8572328269', 6),
('A Hora da Estrela', 'Drama', 'Clarice Lispector', 'Rocco', '978-8532520443', 4),
('O Caçador de Pipas', 'Drama', 'Khaled Hosseini', 'Record', '978-8573027019', 6),
('Cidades de Papel', 'Drama', 'John Green', 'Intrínseca', '978-0525425884', 7),
('O Orfanato da Srta. Peregrine', 'Fantasia', 'Ransom Riggs', 'Intrínseca', '978-8580571294', 5),
('Comer, Rezar, Amar', 'Autoajuda', 'Elizabeth Gilbert', 'Rocco', '978-0307476425', 6),
('O Último Concerto', 'Drama', 'Raduan Nassar', 'Companhia das Letras', '978-8571643167', 4),
('O Cemitério', 'Terror', 'Stephen King', 'Suma', '978-8543100207', 6),
('O Caos', 'Ficção Científica', 'James Gleick', 'Companhia das Letras', '978-8535915479', 5)


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

-- INSERTS FUNCIONARIOS
USE BibliotecaDB
INSERT INTO Funcionarios (NomeUsuario, SenhaHash, NomeCompleto, Cargo, Email, DataCadastro, UltimoLogin, Ativo)
VALUES
('jcarvalho', HASHBYTES('SHA2_256', 'Senha123!'), 'João Carvalho', 'Analista de Sistemas', 'joao.carvalho@empresa.com', GETDATE(), NULL, 1),
('mpereira', HASHBYTES('SHA2_256', 'Senha123!'), 'Maria Pereira', 'Gerente de Projetos', 'maria.pereira@empresa.com', GETDATE(), NULL, 0),
('rlima', HASHBYTES('SHA2_256', 'Senha123!'), 'Roberto Lima', 'Desenvolvedor', 'roberto.lima@empresa.com', GETDATE(), NULL, 1),
('asouza', HASHBYTES('SHA2_256', 'Senha123!'), 'Ana Souza', 'Designer UX/UI', 'ana.souza@empresa.com', GETDATE(), NULL, 1),
('fmartins', HASHBYTES('SHA2_256', 'Senha123!'), 'Fabio Martins', 'Suporte Técnico', 'fabio.martins@empresa.com', GETDATE(), NULL, 1),
('lferreira', HASHBYTES('SHA2_256', 'Senha123!'), 'Laura Ferreira', 'Recursos Humanos', 'laura.ferreira@empresa.com', GETDATE(), NULL, 1),
('cgomes', HASHBYTES('SHA2_256', 'Senha123!'), 'Carlos Gomes', 'Diretor Financeiro', 'carlos.gomes@empresa.com', GETDATE(), NULL, 1),
('poliveira', HASHBYTES('SHA2_256', 'Senha123!'), 'Patricia Oliveira', 'Marketing', 'patricia.oliveira@empresa.com', GETDATE(), NULL, 0),
('jrodrigues', HASHBYTES('SHA2_256', 'Senha123!'), 'José Rodrigues', 'Vendas', 'jose.rodrigues@empresa.com', GETDATE(), NULL, 0),
('msilva', HASHBYTES('SHA2_256', 'Senha123!'), 'Mariana Silva', 'Desenvolvedora Frontend', 'mariana.silva@empresa.com', GETDATE(), NULL, 1)

INSERT INTO Requisicoes (UsuarioID, LivroID, FuncionarioID, Status)
VALUES
(1, 1, 1, 'Aprovada'),
(2, 3, 2, 'Pendente'),
(3, 5, 3, 'Devolvido'),
(4, 2, 4, 'Aprovada'),
(5, 4, 5, 'Devolvido'),
(6, 7, 6, 'Pendente'),
(7, 6, 7, 'Aprovada'),
(8, 9, 8, 'Devolvido'),
(9, 8, 9, 'Aprovada'),
(10, 10, 10, 'Pendente')



