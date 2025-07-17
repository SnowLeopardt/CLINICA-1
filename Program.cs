using System;
using System.Windows.Forms;

namespace CLINICA_1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login ()); // Cambia 'Form1' si tu formulario principal tiene otro nombre
        }
    }
}
