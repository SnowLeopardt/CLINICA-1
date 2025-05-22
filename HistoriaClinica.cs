using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CLINICA_1
{
    public partial class HistoriaClinica : Form
    {

        private string connectionString = "Server=LAPTOP-M35CB1FF;Database=ClinicaVargas;Integrated Security=True;";

        public HistoriaClinica()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HistoriaClinica_Load(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        INSERT INTO HistoriaClinica (
            ConsultaPor, Paciente, PresenteEnfermedad, PresionArterial, FrecuenciaCardiaca, FrecuenciaRespiratoria, SaturacionOxigeno, Peso, Talla, IMC,

            Hemodialisis, HipertensionArterial, Diabetes, DiabetesTipo2, HipertensionArterialCronica,

            ExtremidadesNormotroficas, CabezaNormocraneo, MembranaTimpanicaNormal, NoEdemaCorneales, BocaNoDesviaciones, NoDesviaciones1, NoSePalpanMasas, 
            NoTirajes, NoEsteroides, NoCirculacionVenosaColateral, NoTimpanismoMarcoColico,

            NoHundimientos, NarizNoDeformidad, NoAleteoNasal, LabiosNoUlceras, FaringeAmigdalasHiperemicas, GlandulasTiroidesNormal, NoEnfisemaSubcutaneo, 
            NoSibilancias, BlandoDepresible, NoHepatoesplenomegalia,

            ConductoAuditivoNormal, NoDesviacionTabiqueNasal, NoHipertrofica, NoEdemaGlandulasSalivales, NoRoncus, BuenaExpacionCosa, RonchasPustulas, 
            NoFrotePericardico, NoSoplosCardiacos, NoSignosIrritacionPeritoneal,

            AbdomenGloboso, PupilasIsocoricas, LenguaNoFrenillo, NoDeformidad, NoLeucomas, NoDesviacion2, ToraxSimetrico, PeristaltismoNormal,
            GenitalesNormales, PielConDescamacion, EnfermedadRenalCronica, Psoriasis,

            ExamenesLaboratorio, ExamenesGabinete, ImpresionDiagnostica
        ) VALUES (
            @ConsultaPor, @Paciente, @PresenteEnfermedad, @PresionArterial, @FrecuenciaCardiaca, @FrecuenciaRespiratoria, @SaturacionOxigeno, @Peso, @Talla, @IMC,

            @Hemodialisis, @HipertensionArterial, @Diabetes, @DiabetesTipo2, @HipertensionArterialCronica,

            @ExtremidadesNormotroficas, @CabezaNormocraneo, @MembranaTimpanicaNormal, @NoEdemaCorneales, @BocaNoDesviaciones, @NoDesviaciones1, @NoSePalpanMasas, 
            @NoTirajes, @NoEsteroides, @NoCirculacionVenosaColateral, @NoTimpanismoMarcoColico,

            @NoHundimientos, @NarizNoDeformidad, @NoAleteoNasal, @LabiosNoUlceras, @FaringeAmigdalasHiperemicas, @GlandulasTiroidesNormal, @NoEnfisemaSubcutaneo, 
            @NoSibilancias, @BlandoDepresible, @NoHepatoesplenomegalia,

            @ConductoAuditivoNormal, @NoDesviacionTabiqueNasal, @NoHipertrofica, @NoEdemaGlandulasSalivales, @NoRoncus, @BuenaExpacionCosa, @RonchasPustulas, 
            @NoFrotePericardico, @NoSoplosCardiacos, @NoSignosIrritacionPeritoneal,

            @AbdomenGloboso, @PupilasIsocoricas, @LenguaNoFrenillo, @NoDeformidad, @NoLeucomas, @NoDesviacion2, @ToraxSimetrico, @PeristaltismoNormal,
            @GenitalesNormales, @PielConDescamacion, @EnfermedadRenalCronica, @Psoriasis,

            @ExamenesLaboratorio, @ExamenesGabinete, @ImpresionDiagnostica
        )";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Datos generales
                cmd.Parameters.AddWithValue("@ConsultaPor", txtConsultaPor.Text);
                cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);
                cmd.Parameters.AddWithValue("@PresenteEnfermedad", txtPresenteEnfermedad.Text);
                cmd.Parameters.AddWithValue("@PresionArterial", txtPresionArterial.Text);
                cmd.Parameters.AddWithValue("@FrecuenciaCardiaca", txtFrecuenciaCardiaca.Text);
                cmd.Parameters.AddWithValue("@FrecuenciaRespiratoria", txtFrecuenciaRespiratoria.Text);
                cmd.Parameters.AddWithValue("@SaturacionOxigeno", txtOxigeno.Text);

                decimal peso = Convert.ToDecimal(txtPeso.Text);
                decimal talla = Convert.ToDecimal(txtTalla.Text);
                decimal imc = peso / (talla * talla);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Talla", talla);
                cmd.Parameters.AddWithValue("@IMC", imc);

                // Generación automática de parámetros de checkbox
                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox chk)
                    {
                        string paramName = "@" + chk.Name.Substring(3); // Elimina "chk" del nombre
                        cmd.Parameters.AddWithValue(paramName, chk.Checked);
                    }
                }

                cmd.Parameters.AddWithValue("@ExamenesLaboratorio", txtExLab.Text);
                cmd.Parameters.AddWithValue("@ExamenesGabinete", txtExGab.Text);
                cmd.Parameters.AddWithValue("@ImpresionDiagnostica", txtImpresion.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Datos guardados correctamente.");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    }
}
