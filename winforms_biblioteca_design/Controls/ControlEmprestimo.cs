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
        }

        private void AbrirTela(Control tela)
        {
            panelMolde.Controls.Clear(); // remove da tela (mas não destrói)

            tela.Dock = DockStyle.Fill;
            panelMolde.Controls.Add(tela);
            tela.BringToFront();
        }





        public void CorBotao(Button botao)
        {

            btnConsultar.BackColor = Color.FromArgb(15, 29, 57);
            btnDevolver.BackColor = Color.FromArgb(15, 29, 57);
            btnEmprestar.BackColor = Color.FromArgb(15, 29, 57);

            botao.BackColor = Color.FromArgb(50, 170, 94);

        }

       

       /* private void btnEmprestar_Click(object sender, EventArgs e)
        {
            if (emprestimo != null)
            {
                return;
            }
            emprestimo = new Emprestimo();
            emprestimo.Dock = DockStyle.Fill;
            tcEmprestimo.SelectTab(tpEmprestar);
            tpEmprestar.Controls.Add(emprestimo);
        }*/

        

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            CorBotao(btnEmprestar);
            if (emprestimo == null)
                emprestimo = new Emprestimo();

            AbrirTela(emprestimo);
                emprestimo.CarregarListBoxLivros();
                emprestimo.CarregarListBoxUsuarios();
                emprestimo.ResetarTela();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CorBotao(btnConsultar);

            if (consulta == null)
                consulta = new Consulta();

            AbrirTela(consulta);
            consulta.CarregarDados();
            consulta.ResetarTela();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            CorBotao(btnDevolver);

            Devolver devolver = new Devolver();
            AbrirTela(devolver);
            devolver.AtualizarCampos();
        }
    }
}
