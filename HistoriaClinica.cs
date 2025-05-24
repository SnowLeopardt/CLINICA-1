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

            string connectionString = "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASEDEDATOS;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO HistoriaClinica (
                ConsultaPor, Paciente, PresenteEnfermedad, PresionArterial, FrecuenciaCardiaca, 
                FrecuenciaRespiratoria, SaturacionOxigeno, Peso, Talla, IndiceMasaCorporal,
                Hemodialisis, HipertensionArterial, Diabetes, EnfermedadRenalCronica, Psoriasis,
                Extremidades, Cabeza, Timpanica, Cornetes, Boca, Desviaciones, PalpanMasas, Tirajes, 
                Esteroides, Circulacion, Timpanismo,
                Hundimientos, Nariz, Aleteo, Labios, Faringe, Tiroides, Enfisema, Sibilancias, 
                Blando, Hepatoesplenomegalia,
                Conducto, Tabique, Hipertrofica, EdemaGlandulas, Roncus, Expacion, Ronchas, 
                Frote, Soplos, Irritacion,
                Abdomen, Pupilas, Lengua, Deformidad, Leucomas, Desviacion, Torax, Peristaltismo, 
                Genitales, Piel
            ) VALUES (
                @ConsultaPor, @Paciente, @PresenteEnfermedad, @PresionArterial, @FrecuenciaCardiaca,
                @FrecuenciaRespiratoria, @SaturacionOxigeno, @Peso, @Talla, @IndiceMasaCorporal,
                @Hemodialisis, @HipertensionArterial, @Diabetes, @EnfermedadRenalCronica, @Psoriasis,
                @Extremidades, @Cabeza, @Timpanica, @Cornetes, @Boca, @Desviaciones, @PalpanMasas, 
                @Tirajes, @Esteroides, @Circulacion, @Timpanismo,
                @Hundimientos, @Nariz, @Aleteo, @Labios, @Faringe, @Tiroides, @Enfisema, @Sibilancias, 
                @Blando, @Hepatoesplenomegalia,
                @Conducto, @Tabique, @Hipertrofica, @EdemaGlandulas, @Roncus, @Expacion, @Ronchas, 
                @Frote, @Soplos, @Irritacion,
                @Abdomen, @Pupilas, @Lengua, @Deformidad, @Leucomas, @Desviacion, @Torax, 
                @Peristaltismo, @Genitales, @Piel
            );";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Agregar TODOS los parámetros
                    cmd.Parameters.AddWithValue("@ConsultaPor", txtConsultaPor.Text);
                    cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);
                    cmd.Parameters.AddWithValue("@PresenteEnfermedad", txtPresenteEnfermedad.Text);
                    cmd.Parameters.AddWithValue("@PresionArterial", txtPresion.Text);
                    cmd.Parameters.AddWithValue("@FrecuenciaCardiaca", txtFC.Text);
                    cmd.Parameters.AddWithValue("@FrecuenciaRespiratoria", txtFR.Text);
                    cmd.Parameters.AddWithValue("@SaturacionOxigeno", txtSaturacion.Text);
                    cmd.Parameters.AddWithValue("@Peso", txtPeso.Text);
                    cmd.Parameters.AddWithValue("@Talla", txtTalla.Text);
            

                    cmd.Parameters.AddWithValue("@Hemodialisis", chkHemodialisis.Checked);
                    cmd.Parameters.AddWithValue("@HipertensionArterial", chkHipertension.Checked);
                    cmd.Parameters.AddWithValue("@Diabetes", chkDiabetes.Checked);
                    cmd.Parameters.AddWithValue("@EnfermedadRenalCronica", chkRenal.Checked);
                    cmd.Parameters.AddWithValue("@Psoriasis", chkPsoriasis.Checked);

                    cmd.Parameters.AddWithValue("@Extremidades", chkExtremidades.Checked);
                    cmd.Parameters.AddWithValue("@Cabeza", chkCabeza.Checked);
                    cmd.Parameters.AddWithValue("@Timpanica", chkTimpanica.Checked);
                    cmd.Parameters.AddWithValue("@Cornetes", chkCornetes.Checked);
                    cmd.Parameters.AddWithValue("@Boca", chkBoca.Checked);
                    cmd.Parameters.AddWithValue("@Desviaciones", chkDesviaciones.Checked);
                    cmd.Parameters.AddWithValue("@PalpanMasas", chkPalpanMasas.Checked);
                    cmd.Parameters.AddWithValue("@Tirajes", chkTirajes.Checked);
                    cmd.Parameters.AddWithValue("@Esteroides", chkEsteroides.Checked);
                    cmd.Parameters.AddWithValue("@Circulacion", chkCirculacion.Checked);
                    cmd.Parameters.AddWithValue("@Timpanismo", chkTimpanismo.Checked);

                    cmd.Parameters.AddWithValue("@Hundimientos", chkHundimientos.Checked);
                    cmd.Parameters.AddWithValue("@Nariz", chkNariz.Checked);
                    cmd.Parameters.AddWithValue("@Aleteo", chkAleteo.Checked);
                    cmd.Parameters.AddWithValue("@Labios", chkLabios.Checked);
                    cmd.Parameters.AddWithValue("@Faringe", chkFaringe.Checked);
                    cmd.Parameters.AddWithValue("@Tiroides", chkTiroides.Checked);
                    cmd.Parameters.AddWithValue("@Enfisema", chkEnfisema.Checked);
                    cmd.Parameters.AddWithValue("@Sibilancias", chkSibilancias.Checked);
                    cmd.Parameters.AddWithValue("@Blando", chkBlando.Checked);
                    cmd.Parameters.AddWithValue("@Hepatoesplenomegalia", chkHepatoesplenomegalia.Checked);

                    cmd.Parameters.AddWithValue("@Conducto", chkConducto.Checked);
                    cmd.Parameters.AddWithValue("@Tabique", chkTabique.Checked);
                    cmd.Parameters.AddWithValue("@Hipertrofica", chkHipertrofica.Checked);
                    cmd.Parameters.AddWithValue("@EdemaGlandulas", chkEdemaGlandulas.Checked);
                    cmd.Parameters.AddWithValue("@Roncus", chkRoncus.Checked);
                    cmd.Parameters.AddWithValue("@Expacion", chkExpacion.Checked);
                    cmd.Parameters.AddWithValue("@Ronchas", chkRonchas.Checked);
                    cmd.Parameters.AddWithValue("@Frote", chkFrote.Checked);
                    cmd.Parameters.AddWithValue("@Soplos", chkSoplos.Checked);
                    cmd.Parameters.AddWithValue("@Irritacion", chkIrritacion.Checked);

                    cmd.Parameters.AddWithValue("@Abdomen", chkAbdomen.Checked);
                    cmd.Parameters.AddWithValue("@Pupilas", chkPupilas.Checked);
                    cmd.Parameters.AddWithValue("@Lengua", chkLengua.Checked);
                    cmd.Parameters.AddWithValue("@Deformidad", chkDeformidad.Checked);
                    cmd.Parameters.AddWithValue("@Leucomas", chkLeucomas.Checked);
                    cmd.Parameters.AddWithValue("@Desviacion", chkDesviacion.Checked);
                    cmd.Parameters.AddWithValue("@Torax", chkTorax.Checked);
                    cmd.Parameters.AddWithValue("@Peristaltismo", chkPeristaltismo.Checked);
                    cmd.Parameters.AddWithValue("@Genitales", chkGenitales.Checked);
                    cmd.Parameters.AddWithValue("@Piel", chkPiel.Checked);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos guardados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                }
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

