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
        private Usuario usuario;
        private Livro livro;
        public Form1()

        {
            InitializeComponent();
            ArredondarCadaElemento();


        }
        #region METODOS

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
            CorBotao(btnLivros);
            tcControle.SelectedTab = tpLivros;
            livro = new Livro();
            livro.Dock = DockStyle.Fill;
            tpLivros.Controls.Add(livro);
        }


        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            CorBotao(btnFuncionarios);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CorBotao(btnUsuarios);
            tcControle.SelectedTab = tpUsuarios;
            usuario = new Usuario();
            usuario.Dock = DockStyle.Fill;
            tpUsuarios.Controls.Add(usuario);
        }
    }
}
