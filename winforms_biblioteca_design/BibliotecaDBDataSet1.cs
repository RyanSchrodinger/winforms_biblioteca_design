using System.Windows.Forms;

namespace winforms_biblioteca_design
{


    partial class BibliotecaDBDataSet
    {
        partial class FuncionariosRow
        {
            public override string ToString()
            {
                return this.FuncionarioID + " - " + this.NomeCompleto;
            }
        }

        partial class RequisicoesRow
        {
            public override string ToString()
            {
                return LivroID.ToString();
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
