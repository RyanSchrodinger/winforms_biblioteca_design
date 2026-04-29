using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_biblioteca_design
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ID - Funcionário
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login entrando = new Login();
            entrando.saida = false;
            Application.Run(entrando);
            if (entrando.saida)
            {
                entrando.Dispose();
                entrando.Close();
                Application.Run(new Form1());// Será necessário passar para os formulários             


            }
        }
    }
}
