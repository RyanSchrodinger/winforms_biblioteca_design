using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms_biblioteca_design.BibliotecaDBDataSetTableAdapters;
using static winforms_biblioteca_design.BibliotecaDBDataSet;

namespace winforms_biblioteca_design.Controls
{
    public partial class Funcionario : UserControl
    {
        public Funcionario()
        {
            InitializeComponent();
            AtualizarLista();
        }


        #region METODOS

        #region ARREDONDAMENTO DE CONTROLES


        public void ArredondarControle(Control ctrl, int raio)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0)
                return;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(ctrl.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(ctrl.Width - raio, ctrl.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, ctrl.Height - raio, raio, raio, 90, 90);

            path.CloseFigure();

            ctrl.Region = new Region(path);
        }


        public void AtivarArredondamentoControle(Control ctrl, int raio)
        {
            ctrl.Resize += (s, e) =>
            {
                ArredondarControle(ctrl, raio);
            };


            ArredondarControle(ctrl, raio);
        }


        public void AtivarArredondamento()
        {
            AtivarArredondamentoControle(panelCadastrar, 20);
            AtivarArredondamentoControle(panelListBox, 20);
            AtivarArredondamentoControle(panelPesquisar, 10);

            AtivarArredondamentoControle(btnNovoFuncionario, 10);
            AtivarArredondamentoControle(btnExcluir, 10);
            AtivarArredondamentoControle(btnAtualizar, 10);



        }
        #endregion




        public void LimparCampos()
        {
            txtNome.Clear();
            txtNomeUser.Clear();
            txtDataCadastro.Clear();
            txtCargo.Clear();
            txtEmail.Clear();
        }

        public void AtualizarLista()
        {
            lboFuncionarios.Items.Clear();
            var funcionario = new FuncionariosTableAdapter();
            var dados = from linha in funcionario.GetData()
                        select linha;

            foreach (FuncionariosRow dado in dados) lboFuncionarios.Items.Add(dado);
        }


        #endregion

        private void lboFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboFuncionarios.SelectedItem == null) return;
            FuncionariosRow funcionario = lboFuncionarios.SelectedItem as FuncionariosRow;
            if (funcionario == null) return;
            txtNome.Text = funcionario.NomeCompleto;
            txtNomeUser.Text = funcionario.NomeUsuario;
            txtDataCadastro.Text = funcionario.DataCadastro.ToString("dd/MM/yyyy");
            txtCargo.Text = funcionario.Cargo;
            txtEmail.Text = funcionario.Email;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(lboFuncionarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um funcionário para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FuncionariosRow funcionario = lboFuncionarios.SelectedItem as FuncionariosRow;
            if (funcionario == null) return;
            FuncionariosTableAdapter funcionarios = new FuncionariosTableAdapter();
            funcionarios.Delete(funcionario.FuncionarioID);

            AtualizarLista();
            LimparCampos();
        }

        private void btnNovoFuncionario_Click(object sender, EventArgs e)
        {
            string nomeCompleto = txtNome.Text;
            string nomeUsuario = txtNomeUser.Text;
            string cargo = txtCargo.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            try
            {
                var funcionarios = new FuncionariosTableAdapter();
                funcionarios.Insert(nomeUsuario, senha, nomeCompleto, cargo, email);
                AtualizarLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
