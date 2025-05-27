using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CLINICA_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rEGISTRARDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RegistroEnfermera VentanaDeRegistro = new RegistroEnfermera();
            VentanaDeRegistro.Show();
        }

        private void hISTORIACLINICAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string rutaPacientes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Pacientes");

            // Si la carpeta no existe, puedes crearla (opcional)
            if (!Directory.Exists(rutaPacientes))
            {
                Directory.CreateDirectory(rutaPacientes);
            }

            // Abre la carpeta en el explorador de archivos
            Process.Start("explorer.exe", rutaPacientes);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual
            this.Hide();

            // Volver al formulario de login
            Login login = new Login();
            login.Show();
        }
    }
}
