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
using winforms_biblioteca_design.Controls;

namespace winforms_biblioteca_design
{
    public partial class Form1 : Form
    {
        Livro livroControl;
        Funcionario funcionarioControl;
        ControlEmprestimo emprestimoControl;
        Usuario usuarioControl;



        public Form1()

        {
            InitializeComponent();
            ArredondarCadaElemento();


        }
        #region METODOS


        private void AbrirTela(Control tela)
        {
            // Descarta todos os controles anteriores
            foreach (Control c in panelMolde.Controls)
                c.Dispose();



            panelMolde.Controls.Clear();
            tela.Dock = DockStyle.Fill;
            panelMolde.Controls.Add(tela);
        }





        #region ARREDONDAMENTO DE CONTROLES

        public void ArredondarBotao(Control cntr, int raio)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(cntr.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(cntr.Width - raio, cntr.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, cntr.Height - raio, raio, raio, 90, 90);

            path.CloseFigure();

            cntr.Region = new Region(path);
        }

        public void ArredondarCadaElemento()
        {
            ArredondarBotao(btnLivros, 10);
            ArredondarBotao(btnUsuarios, 10);
            ArredondarBotao(btnFuncionarios, 10);
            ArredondarBotao(panelPerfil, 20);
            ArredondarBotao(btnEmprestimo, 10);
        }

        #endregion


        public void CorBotao(Button botao)
        {
            btnFuncionarios.BackColor = Color.FromArgb(15, 29, 57);
            btnUsuarios.BackColor = Color.FromArgb(15, 29, 57);
            btnLivros.BackColor = Color.FromArgb(15, 29, 57);

            botao.BackColor = Color.FromArgb(42, 75, 148);
        }
        #endregion


        private void btnLivros_Click(object sender, EventArgs e)
        {
            if (livroControl != null)
            {
                return;

            }
            CorBotao(btnLivros);
            livroControl = new Livro();
            AbrirTela(livroControl);
        }


        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            if (funcionarioControl != null)
            {
                return;

            }
            CorBotao(btnFuncionarios);
            funcionarioControl = new Funcionario();
            AbrirTela(funcionarioControl);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (usuarioControl != null)
            {
                return;

            }
            CorBotao(btnUsuarios);
            usuarioControl = new Usuario();
            AbrirTela(usuarioControl);
        }

        private void btnEmprestimo_Click(object sender, EventArgs e)
        {
            if (emprestimoControl != null)
            {
                return;

            }
            CorBotao(btnEmprestimo);
            emprestimoControl = new ControlEmprestimo();
            AbrirTela(emprestimoControl);
        }
    }
}
