using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace winforms_biblioteca_design.Controls
{
    public partial class Livro : UserControl
    {
        public Livro()
        {
            InitializeComponent();
            ArredondarPanel(panelCadastrar,20);
            ArredondarBotao(btnCadastrar, 10);
            ArredondarBotao(btnExcluir, 3);
            ArredondarBotao(btnAtualizar, 3);
            ArredondarBotao(btnSalvar, 3);
            ArredondarPanel(panelPesquisar, 10);
            
        }

        public void ArredondarPanel(Panel panel, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, raio, raio), 180, 90);
            path.AddArc(new Rectangle(panel.Width - raio, 0, raio, raio), 270, 90);
            path.AddArc(new Rectangle(panel.Width - raio, panel.Height - raio, raio, raio), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - raio, raio, raio), 90, 90);

            path.CloseFigure();

            panel.Region = new Region(path);
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

        public void ArredondarTxtBox(TextBox txt, int raio)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(txt.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(txt.Width - raio, txt.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, txt.Height - raio, raio, raio, 90, 90);

            path.CloseFigure();

            txt.Region = new Region(path);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
