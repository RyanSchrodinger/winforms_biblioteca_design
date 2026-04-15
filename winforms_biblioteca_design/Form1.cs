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

        private void btnLivros_Click(object sender, EventArgs e)
        {
            tcControle.SelectedTab = tpLivros;
            livro = new Livro();
            livro.Dock = DockStyle.Fill;
            tpLivros.Controls.Add(livro);
        }

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

   
    }
}
