using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLINICA_1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void hISTORIACLINICAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            HistoriaClinica ventanaDeHistoria = new HistoriaClinica(); // se usa el constructor sin parámetros
            ventanaDeHistoria.Show();
        }

        private void rEGISTRARDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            Registro VentanaDeRegistro = new Registro();
            VentanaDeRegistro.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Indicaciones VentanaDeIndicaciones = new Indicaciones();
            VentanaDeIndicaciones.Show();
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
