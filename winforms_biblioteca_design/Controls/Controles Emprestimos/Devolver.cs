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

namespace winforms_biblioteca_design.Controls.Controles_Emprestimos
{
    public partial class Devolver : UserControl
    {
        QueriesTableAdapter requisitos = new QueriesTableAdapter();
        public Devolver()
        {
            InitializeComponent();
            AtualizarCampos();
            var devolvidos = requisitos.ObterRequisicoesPedentes();
        }

        
        public void AtualizarCampos()
        {

            var devolvidos = new QueriesTableAdapter();
            lboDevolucao.DataSource = devolvidos;
            lboDevolucao.DisplayMember = "LivroID"; // depois melhoramos isso
            lboDevolucao.ValueMember = "RequisicaoID";

        }


    }
}
