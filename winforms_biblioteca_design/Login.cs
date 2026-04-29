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

namespace winforms_biblioteca_design
{
    public partial class Login : Form
    {
        public bool saida;
        public Login()
        {
            InitializeComponent();
        }

        private void llblSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            verificarUsuarioTableAdapter verificarUsuario = new verificarUsuarioTableAdapter();
            var usuario = verificarUsuario.GetData(txtUsuario.Text, txtSenha.Text);
            if (usuario == null)
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
            saida = true;
            Close();




        }

        
    }
}
