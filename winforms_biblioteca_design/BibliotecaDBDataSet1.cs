using System.Data;
using System.Linq;
using System.Windows.Forms;
using winforms_biblioteca_design.BibliotecaDBDataSetTableAdapters;

namespace winforms_biblioteca_design
{


    partial class BibliotecaDBDataSet
    {






        partial class FuncionariosRow
        {
            public override string ToString()
            {
                return this.FuncionarioID + " - " + this.NomeCompleto + " - " + this.Cargo;
            }
        }

        partial class RequisicoesRow
        {
            public string Devolucao
            {
                get
                {
                    try
                    {
                        return DataDevolucao.ToString("dd/MM/yyyy HH:mm:ss");

                    }
                    catch
                    {
                        return "Devolvido";
                    }
                }
            }
            public override string ToString()
            {
                //string dataDevolucao = this.IsDataDevolucaoNull() ? "Concluido" : this.DataDevolucao.ToString("dd/MM/yyyy HH:mm:ss");
                LivrosTableAdapter livros = new LivrosTableAdapter();
                LivrosRow livro = (from linha in livros.GetData()
                                   where linha.LivroID == this.LivroID
                                   select linha).FirstOrDefault();
                return livro.Titulo;
            }
        }

        partial class UsuariosRow
        {
            public override string ToString()
            {
                return this.UsuarioID + " - " + this.Nome + " - " + this.Email;
            }
        }

        partial class LivrosRow
        {
            public override string ToString()
            {
                return this.LivroID + " - " + this.Titulo + " - " + this.Autor;
            }

        }
    }
}

