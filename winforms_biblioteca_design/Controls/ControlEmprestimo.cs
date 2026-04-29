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
using winforms_biblioteca_design.Controls.Controles_Emprestimos;

namespace winforms_biblioteca_design.Controls
{
    public partial class ControlEmprestimo : UserControl
    {
        Consulta consulta;
        Emprestimo emprestimo;
        public ControlEmprestimo()
        {
            InitializeComponent();
            AtivarArredondamento();
        }


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
            ArredondarControle(btnConsultar, 10);



        }




        public void CorBotao(Button botao)
        {
            
            btnConsultar.BackColor = Color.FromArgb(15, 29, 57);
            btnDevolver.BackColor = Color.FromArgb(15, 29, 57);
            btnEmprestar.BackColor = Color.FromArgb(15, 29, 57);

            botao.BackColor = Color.FromArgb(42, 75, 148);
           
        }


        #endregion

        
        
       

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (consulta != null)
            {
                return;
            }
            consulta = new Consulta();
            consulta.Dock = DockStyle.Fill;
            tcEmprestimo.SelectTab(tpConsultar);
            tpConsultar.Controls.Add(consulta);
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            if (emprestimo != null)
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
