# Biblioteca de Gerenciamento (CRUD + Empréstimos)

Biblioteca simples desenvolvida em C# para gerenciamento de livros, usuários e funcionários, com suporte a operações de empréstimo.

## 📌 Descrição

Este projeto permite realizar operações básicas de CRUD (Create, Read, Update, Delete) para:

* Livros
* Usuários
* Funcionários

Além disso, possui uma funcionalidade de empréstimo, onde é possível:

* Registrar empréstimos de livros para usuários
* Controlar os empréstimos realizados
* Realizar devoluções

## ⚙️ Tecnologias

* C#
* .NET (WinForms)
* ADO.NET (TableAdapter / DataSet)
* SQL Server

## 🚀 Exemplo de uso

Exemplo de realização de empréstimo:

```csharp
var livroSelecionado = lboLivros.SelectedItem as LivrosRow;
var usuarioSelecionado = lboUsuarios.SelectedItem as UsuariosRow;
var funcionarioSelecionado = cboFuncionarios.SelectedItem as FuncionariosRow;

QueriesTableAdapter consulta = new QueriesTableAdapter();
consulta.EmprestarLivro(
    livroSelecionado.LivroID,
    funcionarioSelecionado.FuncionarioID,
    usuarioSelecionado.UsuarioID
);
```

## 🎯 Objetivo

Projeto desenvolvido com foco em aprendizado, principalmente para praticar:

* Manipulação de dados com ADO.NET
* Uso de DataSet e TableAdapter
* Organização básica de regras de negócio

## ⚠️ Observações

* Projeto simples, não focado em produção
* Pode conter limitações e melhorias futuras
* Estrutura baseada em DataSet (abordagem mais tradicional)

## 📌 Funcionalidades

* CRUD de livros
* CRUD de usuários
* CRUD de funcionários
* Sistema de empréstimo de livros
* Controle de devolução

## 👨‍💻 Autor

Desenvolvido por Ryan
