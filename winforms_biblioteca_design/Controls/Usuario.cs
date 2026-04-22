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
    public partial class Usuario : UserControl
    {
        public Usuario()
        {
            InitializeComponent();
            AtualizarLista();
        }


        #region METODOS

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
    }
}
