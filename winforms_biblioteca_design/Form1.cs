using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
           

        }

        private void btnLivros_Click(object sender, EventArgs e)
        {
            tcControle.SelectedTab = tpLivros;
            livro = new Livro();
            livro.Dock = DockStyle.Fill;
            tpLivros.Controls.Add(livro);
        }
    }
}
