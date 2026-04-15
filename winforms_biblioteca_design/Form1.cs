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
        private Livro livro;
        public Form1()

        {
            InitializeComponent();
            ArredondarCadaBotao();


        }
        #region METODOS

        public void ArredondarBotao(Button btn, int raio)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);

            path.CloseFigure();

            btn.Region = new Region(path);
        }

        public void ArredondarCadaBotao()
        {
            ArredondarBotao(btnLivros, 10);
            ArredondarBotao(btnUsuarios, 10);
            ArredondarBotao(btnFuncionarios, 10);
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
        }
    }
}
