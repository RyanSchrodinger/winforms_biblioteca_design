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
            AtivarArredondamentoControle(panelCadastrar, 20);
            AtivarArredondamentoControle(panelListBox, 20);
            AtivarArredondamentoControle(panelPesquisar, 10);

            AtivarArredondamentoControle(btnCadastrar, 10);
            AtivarArredondamentoControle(btnExcluir, 10);
            AtivarArredondamentoControle(btnAtualizar, 10);
            AtivarArredondamentoControle(btnSalvar, 10);

            // Se quiser textbox arredondado:
            // AtivarArredondamentoControle(txtTitulo, 10);
        }
        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
