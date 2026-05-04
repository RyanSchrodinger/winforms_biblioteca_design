using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms_biblioteca_design.BibliotecaDBDataSetTableAdapters;
using static winforms_biblioteca_design.BibliotecaDBDataSet;

namespace winforms_biblioteca_design.Controls
{
    public partial class Emprestimo : UserControl
    {
        public Emprestimo()
        {
            InitializeComponent();
            CarregarComboBoxFuncionarios();
            CarregarListBoxLivros();
            CarregarListBoxUsuarios();


        }

        #region METODOS

        public void ResetarTela()
        {
            lboLivros.ClearSelected();
            lboUsuarios.ClearSelected();
            txtPesquisarLivro.Clear();
            txtPesquisarUsuario.Clear();
        }

        public void CarregarComboBoxFuncionarios()
        {
            // Será removido no futuro 
            FuncionariosTableAdapter funcionarios = new FuncionariosTableAdapter();
            var obterFuncionarios = from linha in funcionarios.GetData() select linha;
            foreach (var funcionario in obterFuncionarios)
            {
                cboFuncionarios.Items.Add(funcionario);
            }
            cboFuncionarios.SelectedIndex = 0;
        }

        public void CarregarListBoxLivros()
        {
            LivrosTableAdapter livros = new LivrosTableAdapter();
            var obterLivros = from linha in livros.GetData() select linha;
            foreach (var livro in obterLivros)
            {
                lboLivros.Items.Add(livro);
            }
        }

        public void CarregarListBoxUsuarios()
        {

            UsuariosTableAdapter usuarios = new UsuariosTableAdapter();
            var obterUsuarios = from linha in usuarios.GetData()
                                select linha;
            foreach (var usuario in obterUsuarios) lboUsuarios.Items.Add(usuario);
        }


        #endregion

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            var livroSelecionado = lboLivros.SelectedItem as LivrosRow;
            var usuarioSelecionado = lboUsuarios.SelectedItem as UsuariosRow;
            var funcionarioSelecionado = cboFuncionarios.SelectedItem as FuncionariosRow;
            if (livroSelecionado == null || usuarioSelecionado == null || funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um livro, um usuário e um funcionário para realizar o empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                QueriesTableAdapter consulta = new QueriesTableAdapter();
                consulta.EmprestarLivro(
                    livroSelecionado.LivroID,
                    funcionarioSelecionado.FuncionarioID,
                    usuarioSelecionado.UsuarioID
                    );
                MessageBox.Show(
                    $"Empréstimo realizado com sucesso!\n\n" +
                    $"Livro: {livroSelecionado.Titulo}\n" +
                    $"Usuário: {usuarioSelecionado.Nome}\n" +
                    $"Funcionário: {funcionarioSelecionado.NomeCompleto}\n" +
                    $"Data de devolução: {DateTime.Now.AddDays(7):dd/MM/yyyy}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro ao realizar empréstimo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }


        }

        #region Eventos dos TextBox de pesquisa
        private void txtPesquisarLivro_TextChanged(object sender, EventArgs e)
        {
            TextBox pesquisa = sender as TextBox;
            if (pesquisa.Text == "")
            {
                CarregarListBoxLivros();
                return;
            }
            lboLivros.ClearSelected();
            lboLivros.Items.Clear();
            string textoDigitado = txtPesquisarLivro.Text;
            LivrosTableAdapter dados = new LivrosTableAdapter();
            var livros = from linha in dados.GetData()
                         where linha.Titulo.ToLower().Contains(textoDigitado.ToLower())
                         select linha;
            foreach (var livro in livros) lboLivros.Items.Add(livro);
        }
        

        private void txtPesquisarUsuario_TextChanged(object sender, EventArgs e)
        {
            TextBox pesquisa = sender as TextBox;
            if (pesquisa.Text == "")
            {
                CarregarListBoxUsuarios();
                return;
            }
            lboUsuarios.ClearSelected();
            lboUsuarios.Items.Clear();
            string textoDigitado = txtPesquisarUsuario.Text;
            UsuariosTableAdapter dados = new UsuariosTableAdapter();
            var usuarios = from linha in dados.GetData()
                           where linha.Nome.ToLower().Contains(textoDigitado.ToLower())
                           select linha;
            foreach (var usuario in usuarios) lboUsuarios.Items.Add(usuario);
        }
        #endregion

    }
}
