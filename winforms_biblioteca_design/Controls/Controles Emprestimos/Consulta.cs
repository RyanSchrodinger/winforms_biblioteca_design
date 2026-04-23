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

namespace winforms_biblioteca_design.Controls.Controles_Emprestimos
{
    public partial class Consulta : UserControl
    {
        public Consulta()
        {
            InitializeComponent();
            RequisicoesTableAdapter requisicoes = new RequisicoesTableAdapter();
            lboConsulta.Items.AddRange(requisicoes.GetData().ToArray());

        }

        private void lboConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequisicoesRow requisicao = lboConsulta.SelectedItem as RequisicoesRow;
            if (requisicao == null) return;
            lblDataEmprestimo.Text = requisicao.DataRequisicao.ToString();
            lblDataDevolucao.Text = requisicao.Devolucao;
            lblStatus.Text = requisicao.Status.ToString();
            LivrosTableAdapter livros = new LivrosTableAdapter();
            LivrosRow livro = (from linha in livros.GetData()
                               where linha.LivroID == requisicao.LivroID
                               select linha).FirstOrDefault();
            if (livro == null) return;
            lblTitulo.Text = livro.Titulo;
            FuncionariosTableAdapter funcionarios = new FuncionariosTableAdapter();
            FuncionariosRow funcionario = (from linha in funcionarios.GetData()
                                           where linha.FuncionarioID == requisicao.FuncionarioID
                                           select linha).FirstOrDefault();
            if (funcionario == null) return;
            lblFuncionario.Text = funcionario.NomeCompleto;
            UsuariosTableAdapter usuarios = new UsuariosTableAdapter();
            UsuariosRow usuario = (from linha in usuarios.GetData()
                                   where linha.UsuarioID == requisicao.UsuarioID
                                   select linha).FirstOrDefault();
            if (usuario == null) return;
            lblUsuario.Text = usuario.Nome;
        }

        private void textPesquisar_TextChanged(object sender, EventArgs e)
        {
            if(txtPesquisar.Text == "")
            {
                var dado = new RequisicoesTableAdapter();
                lboConsulta.Items.AddRange(dado.GetData().ToArray());
                return;


            }
            var requisicoes = new RequisicoesTableAdapter();
            lboConsulta.Items.Clear();
            lboConsulta.Items.AddRange((from linha in requisicoes.GetData()
                                        where requisicoes.ToString().ToLower().Contains(txtPesquisar.Text)
                                        select linha).ToArray());




        }
    }
}
