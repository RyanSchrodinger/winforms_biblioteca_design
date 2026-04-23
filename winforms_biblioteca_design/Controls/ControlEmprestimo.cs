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

namespace winforms_biblioteca_design.Controls
{
    public partial class ControlEmprestimo : UserControl
    {
        Emprestimo emprestimo;
        public ControlEmprestimo()
        {
            InitializeComponent();
            ArredondarCadaElemento();
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
            ArredondarBotao(btnEmprestar, 15);
            ArredondarBotao(btnDevolver, 15);
            ArredondarBotao(btnConsultar, 15);
            ArredondarBotao(panelEmprestar,15);
            ArredondarBotao(panelDevolver, 15);
            ArredondarBotao(panelConsultar, 15);
        }

        public void CorBotao(Button botao)
        {
            btnConsultar.BackColor = Color.FromArgb(15, 29, 57);
            btnDevolver.BackColor = Color.FromArgb(15, 29, 57);
            btnEmprestar.BackColor = Color.FromArgb(15, 29, 57);

            botao.BackColor = Color.FromArgb(42, 75, 148);
        }


        #endregion

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            if(emprestimo != null)
            {
                return;
            }
            emprestimo = new Emprestimo();
            emprestimo.Dock = DockStyle.Fill;
            tcEmprestimo.SelectTab(tpEmprestar);
            tpEmprestar.Controls.Add(emprestimo);
        }
    }
}
