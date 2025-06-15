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
    public partial class ores : Form
    {
        public ores(string examenesGuardados)
        {
            InitializeComponent();
            txtExameness.Text = examenesGuardados;
        }

        private void FormExamenesAnteriores_Load(object sender, EventArgs e)
        {

        }
    }
}
    

