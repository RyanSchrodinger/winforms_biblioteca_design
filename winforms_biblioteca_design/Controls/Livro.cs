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
using winforms_biblioteca_design.BibliotecaDBDataSetTableAdapters;
using static winforms_biblioteca_design.BibliotecaDBDataSet;

namespace winforms_biblioteca_design.Controls
{
    public partial class Livro : UserControl
    {
        public Livro()
        {
            InitializeComponent();
            AtivarArredondamento();
            AtualizarLista();

        }

        #region METODOS

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

            AtivarArredondamentoControle(btnNovoLivro, 10);
            AtivarArredondamentoControle(btnExcluir, 10);
            AtivarArredondamentoControle(btnAtualizar, 10);



        }
        #endregion




        public void LimparCampos() 
        {
            txtAnoPublicacao.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            txtGenero.Clear();
            txtISBN.Clear();
            txtQuantidade.Clear();
            txtTitulo.Clear();
        }

        public void AtualizarLista()
        {
            lboLivros.Items.Clear();
            var livro = new LivrosTableAdapter();
            var dados = from linha in livro.GetData()
                        select linha;

            foreach (LivrosRow dado in dados) lboLivros.Items.Add(dado);
        }


        #endregion

      

       

        private void lboLivros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboLivros.SelectedItem == null) return;
            LivrosRow livro = lboLivros.SelectedItem as LivrosRow;
            if (livro == null) return;
            txtAutor.Text = livro.Autor;
            txtEditora.Text = livro.Editora;
            txtGenero.Text = livro.Genero;
            txtISBN.Text = livro.ISBN;
            txtTitulo.Text = livro.Titulo;
            txtQuantidade.Text = livro.QuantidadeDisponivel.ToString();
            txtAnoPublicacao.Text = livro.DataCadastro.ToString("dd/MM/yyyy");

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            TextBox pesquisa = sender as TextBox;
            if (pesquisa.Text == "")
            {
                AtualizarLista();
                return;
            }
            lboLivros.ClearSelected();
            lboLivros.Items.Clear();
            string textoDigitado = txtPesquisar.Text;
            LivrosTableAdapter dados = new LivrosTableAdapter();
            var livros = from linha in dados.GetData()
                         where linha.Titulo.ToLower().Contains(textoDigitado.ToLower())
                         select linha;
            foreach (var livro in livros) lboLivros.Items.Add(livro);
        }

        

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

       

     

        private void btnNovoLivro_Click(object sender, EventArgs e)
        {

            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            string editora = txtEditora.Text;
            string isbn = txtISBN.Text;
            string genero = txtGenero.Text;

            try
            {
                int quantidade = int.Parse(txtQuantidade.Text);
                var livros = new LivrosTableAdapter();
                livros.Insert(titulo, genero, autor, editora, isbn, quantidade);
                AtualizarLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lboLivros.SelectedItem == null)
            {
                MessageBox.Show("Selecione um livro para excluir.");
                return;
            }

            LivrosRow livro = lboLivros.SelectedItem as LivrosRow;
            if (livro == null)
            {
                MessageBox.Show("Seleção inválida.");
                return;
            }

            var livros = new LivrosTableAdapter();
            livros.Delete(livro.LivroID);
            AtualizarLista();
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (lboLivros.SelectedItem == null)
            {
                MessageBox.Show("Selecione um livro para atualizar.");
                return;
            }

            LivrosRow livro = lboLivros.SelectedItem as LivrosRow;
            if (livro == null)
            {
                MessageBox.Show("Seleção inválida.");
                return;
            }
            livro.Titulo = txtTitulo.Text;
            livro.Autor = txtAutor.Text;
            livro.Editora = txtEditora.Text;
            livro.ISBN = txtISBN.Text;
            livro.Genero = txtGenero.Text;

            try
            {
                livro.QuantidadeDisponivel = int.Parse(txtQuantidade.Text);
                var livros = new LivrosTableAdapter();
                livros.Update(livro.LivroID, livro.Titulo, livro.Genero, livro.Autor, livro.Editora, livro.ISBN, livro.QuantidadeDisponivel);
                AtualizarLista();
                LimparCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Quantidade deve ser um número inteiro.");
            }
        }
    }
}
