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
            QueriesTableAdapter consulta = new QueriesTableAdapter();
            consulta.EmprestarLivro(
                livroSelecionado.LivroID,
                funcionarioSelecionado.FuncionarioID, 
                usuarioSelecionado.UsuarioID
                );
            MessageBox.Show($"Empréstimo realizado com sucesso!\n\nLivro: {livroSelecionado.Titulo}\nUsuário: {usuarioSelecionado.Nome}\nFuncionário: {funcionarioSelecionado.NomeCompleto}\nData de devolução: {DateTime.Now.AddDays(7):dd/MM/yyyy}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
