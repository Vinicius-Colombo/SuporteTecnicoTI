using System;
using System.Windows.Forms;

namespace SuporteTI.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializa o formulário de login
            Application.Run(new LoginForm());
        }
    }
}
