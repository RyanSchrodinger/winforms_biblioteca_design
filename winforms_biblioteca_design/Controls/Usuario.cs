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
    public partial class Usuario : UserControl
    {
        public Usuario()
        {
            InitializeComponent();
            AtualizarLista();
            AtivarArredondamento();
        }


        #region METODOS

        #region METODO PARA ARREDONAR

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

            AtivarArredondamentoControle(btnNovoUsuario, 10);
            AtivarArredondamentoControle(btnExcluir, 10);
            AtivarArredondamentoControle(btnAtualizar, 10);


        }

        #endregion
        public void AtualizarLista()
        {
            lboUsuarios.Items.Clear();
            var usuario = new UsuariosTableAdapter();
            var dados = from linha in usuario.GetData()
                        select linha;

            foreach (UsuariosRow dado in dados) lboUsuarios.Items.Add(dado);
        }


        #endregion

        private void lboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione algum usuário");
                return;
            }
            UsuariosRow usuario = lboUsuarios.SelectedItem as UsuariosRow;
            if (usuario == null) return; 
            txtEmail.Text = usuario.Email;
            txtNome.Text = usuario.Nome;
            txtTelefone.Text = usuario.IsTelefoneNull() ? "" : usuario.Telefone;
            txtDataCadastro.Text = usuario.DataCadastro.ToString("dd/MM/yyyy");
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            TextBox pesquisa = sender as TextBox;
            if (pesquisa.Text == "")
            {
                AtualizarLista();
                return;
            }
            lboUsuarios.ClearSelected();
            lboUsuarios.Items.Clear();
            string textoDigitado = txtPesquisar.Text;
            UsuariosTableAdapter dados = new UsuariosTableAdapter();
            var usuarios = from linha in dados.GetData()
                           where linha.Nome.ToLower().Contains(textoDigitado.ToLower())
                           select linha;
            foreach (var usuario in usuarios) lboUsuarios.Items.Add(usuario);
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;

            try
            {
                UsuariosTableAdapter usuarios = new UsuariosTableAdapter();
                usuarios.Insert(nome, email, telefone);
                AtualizarLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lboUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um usuário para excluir.");
                return;
            }

            UsuariosRow usuario = lboUsuarios.SelectedItem as UsuariosRow;
            if (usuario == null)
            {
                MessageBox.Show("Seleção inválida.");
                return;
            }

            var usuarios = new UsuariosTableAdapter();
            usuarios.Delete(usuario.UsuarioID);
            AtualizarLista();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            if (lboUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um usuário para atualizar.");
                return;
            }

            UsuariosRow usuario = lboUsuarios.SelectedItem as UsuariosRow;
            if (usuario == null)
            {
                MessageBox.Show("Seleção inválida.");
                return;
            }
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.DataCadastro = DateTime.Parse(txtDataCadastro.Text);
            try
            {
                var usuarios = new UsuariosTableAdapter();
                usuarios.Update(usuario.UsuarioID, usuario.Nome, usuario.Email, usuario.Telefone);
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message);
            }
        }
    }
}
