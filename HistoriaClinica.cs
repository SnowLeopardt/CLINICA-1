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
using Xceed.Document.NET;
using System.IO;
using Xceed.Words.NET;


namespace CLINICA_1
{
    public partial class HistoriaClinica : Form
    {

        private string connectionString = "Server=LAPTOP-M35CB1FF;Database=ClinicaVargas;Integrated Security=True;";

        public HistoriaClinica()
        {
            InitializeComponent();

            txtPeso.KeyPress += txtPeso_KeyPress;
            txtTalla.KeyPress += txtTalla_KeyPress;

            txtMasaCorporal.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HistoriaClinica_Load(object sender, EventArgs e)
        {
            txtMasaCorporal.ReadOnly = true;
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
    INSERT INTO HistoriaClinica (
        ConsultaPor, Paciente, PresenteEnfermedad, PresionArterial, FrecuenciaCardiaca, 
        FrecuenciaRespiratoria, SaturacionOxigeno, Peso, Talla, IndiceMasaCorporal,
        Hemodialisis, HipertensionArterial, Diabetes,
        Extremidades, Cabeza, Timpanica, Cornetes, Boca, Desviaciones, PalpanMasas, Tirajes, 
        Esteroides, Circulacion, Timpanismo,
        Hundimientos, Nariz, Aleteo, Labios, Faringe, Tiroides, Enfisema, Sibilancias, 
        Blando, Hepatoesplenomegalia,
        Conducto, Tabique, Hipertrofica, EdemaGlandulas, Roncus, Expacion, Ronchas, 
        Frote, Soplos, Irritacion,
        Abdomen, Pupilas, Lengua, Deformidad, Leucomas, Desviacion, Torax, Peristaltismo, 
        Genitales, Piel, ExamenesGabinete, ExamenesLaboratorios, Impresion, SignosVitales
    ) VALUES (
        @ConsultaPor, @Paciente, @PresenteEnfermedad, @PresionArterial, @FrecuenciaCardiaca,
        @FrecuenciaRespiratoria, @SaturacionOxigeno, @Peso, @Talla, @IndiceMasaCorporal,
        @Hemodialisis, @HipertensionArterial, @Diabetes,
        @Extremidades, @Cabeza, @Timpanica, @Cornetes, @Boca, @Desviaciones, @PalpanMasas, 
        @Tirajes, @Esteroides, @Circulacion, @Timpanismo,
        @Hundimientos, @Nariz, @Aleteo, @Labios, @Faringe, @Tiroides, @Enfisema, @Sibilancias, 
        @Blando, @Hepatoesplenomegalia,
        @Conducto, @Tabique, @Hipertrofica, @EdemaGlandulas, @Roncus, @Expacion, @Ronchas, 
        @Frote, @Soplos, @Irritacion,
        @Abdomen, @Pupilas, @Lengua, @Deformidad, @Leucomas, @Desviacion, @Torax, 
        @Peristaltismo, @Genitales, @Piel, @ExamenesGabinete, @ExamenesLaboratorios, @Impresion, @SignosVitales
    );";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Agregar TODOS los parámetros
                    cmd.Parameters.AddWithValue("@ConsultaPor", txtConsultaPor.Text);
                    cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);
                    cmd.Parameters.AddWithValue("@PresenteEnfermedad", txtPresenteEnfermedad.Text);
                    cmd.Parameters.AddWithValue("@PresionArterial", txtPresion.Text);
                    cmd.Parameters.AddWithValue("@SignosVitales", txtSignosVitales.Text);
                    cmd.Parameters.AddWithValue("@FrecuenciaCardiaca", txtFC.Text);
                    cmd.Parameters.AddWithValue("@FrecuenciaRespiratoria", txtFR.Text);
                    cmd.Parameters.AddWithValue("@SaturacionOxigeno", txtSaturacion.Text);
                    cmd.Parameters.AddWithValue("@Peso", txtPeso.Text);
                    cmd.Parameters.AddWithValue("@Talla", txtTalla.Text);
                    cmd.Parameters.AddWithValue("@IndiceMasaCorporal", txtMasaCorporal.Text);
                    cmd.Parameters.AddWithValue("@ExamenesGabinete", txtExamenesGabinete.Text);
                    cmd.Parameters.AddWithValue("@ExamenesLaboratorios", txtExamenesLaboratorio.Text);
                    cmd.Parameters.AddWithValue("@Impresion", txtImpresion.Text);


                    cmd.Parameters.AddWithValue("@Hemodialisis", chkHemodialisis.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@HipertensionArterial", chkHipertension.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Diabetes", chkDiabetes.Checked ? "SI" : "NO");
    

                    cmd.Parameters.AddWithValue("@Extremidades", chkExtremidades.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Cabeza", chkCabeza.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Timpanica", chkTimpanica.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Cornetes", chkCornetes.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Boca", chkBoca.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Desviaciones", chkDesviaciones.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@PalpanMasas", chkPalpanMasas.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Tirajes", chkTirajes.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Esteroides", chkEsteroides.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Circulacion", chkCirculacion.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Timpanismo", chkTimpanismo.Checked ? "SI" : "NO");

                    cmd.Parameters.AddWithValue("@Hundimientos", chkHundimientos.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Nariz", chkNariz.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Aleteo", chkAleteo.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Labios", chkLabios.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Faringe", chkFaringe.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Tiroides", chkTiroides.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Enfisema", chkEnfisema.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Sibilancias", chkSibilancias.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Blando", chkBlando.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Hepatoesplenomegalia", chkHepatoesplenomegalia.Checked ? "SI" : "NO");

                    cmd.Parameters.AddWithValue("@Conducto", chkConducto.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Tabique", chkTabique.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Hipertrofica", chkHipertrofica.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@EdemaGlandulas", chkEdemaGlandulas.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Roncus", chkRoncus.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Expacion", chkExpacion.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Ronchas", chkRonchas.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Frote", chkFrote.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Soplos", chkSoplos.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Irritacion", chkIrritacion.Checked ? "SI" : "NO");

                    cmd.Parameters.AddWithValue("@Abdomen", chkAbdomen.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Pupilas", chkPupilas.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Lengua", chkLengua.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Deformidad", chkDeformidad.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Leucomas", chkLeucomas.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Desviacion", chkDesviacion.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Torax", chkTorax.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Peristaltismo", chkPeristaltismo.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Genitales", chkGenitales.Checked ? "SI" : "NO");
                    cmd.Parameters.AddWithValue("@Piel", chkPiel.Checked ? "SI" : "NO");

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos(); // Llama al método para limpiar los campos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al intentar guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            try
            {
                // ==========================
                // GENERACIÓN DEL DOCUMENTO
                // ==========================
                string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HistoriaClinica_" + txtPaciente.Text + ".docx");

                using (var doc = DocX.Create(docPath))
                {
                    // Título
                    var titulo = doc.InsertParagraph("Historia Clínica")
                                    .FontSize(16)
                                    .Bold();
                    titulo.Alignment = Alignment.center;

                    doc.InsertParagraph(Environment.NewLine);

                    // TextBox
                    doc.InsertParagraph($"Consulta por: {txtConsultaPor.Text}");
                    doc.InsertParagraph($"Paciente: {txtPaciente.Text}");
                    doc.InsertParagraph($"Presente Enfermedad: {txtPresenteEnfermedad.Text}");
                    doc.InsertParagraph($"Signos Vitales: {txtSignosVitales.Text}");
                    doc.InsertParagraph($"Presión Arterial: {txtPresion.Text}");
                    doc.InsertParagraph($"Frecuencia Cardiaca: {txtFC.Text}");
                    doc.InsertParagraph($"Frecuencia Respiratoria: {txtFR.Text}");
                    doc.InsertParagraph($"Saturación Oxígeno: {txtSaturacion.Text}");
                    doc.InsertParagraph($"Peso: {txtPeso.Text}");
                    doc.InsertParagraph($"Talla: {txtTalla.Text}");
                    doc.InsertParagraph($"IMC: {txtMasaCorporal.Text}");
                    doc.InsertParagraph($"Gabinete: {txtExamenesGabinete.Text}");
                    doc.InsertParagraph($"Laboratorios: {txtExamenesLaboratorio.Text}");
                    doc.InsertParagraph($"Impresión Diagnóstica: {txtImpresion.Text}");

                    // CheckBox
                    doc.InsertParagraph($"Hemodiálisis: {(chkHemodialisis.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Hipertensión Arterial: {(chkHipertension.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Diabetes: {(chkDiabetes.Checked ? "Sí" : "No")}");

                    doc.InsertParagraph($"Extremidades: {(chkExtremidades.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Cabeza: {(chkCabeza.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Timpánica: {(chkTimpanica.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Cornetes: {(chkCornetes.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Boca: {(chkBoca.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Desviaciones: {(chkDesviaciones.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Palpan Masas: {(chkPalpanMasas.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Tirajes: {(chkTirajes.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Esteroides: {(chkEsteroides.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Circulación: {(chkCirculacion.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Timpanismo: {(chkTimpanismo.Checked ? "Sí" : "No")}");

                    doc.InsertParagraph($"Hundimientos: {(chkHundimientos.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Nariz: {(chkNariz.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Aleteo: {(chkAleteo.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Labios: {(chkLabios.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Faringe: {(chkFaringe.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Tiroides: {(chkTiroides.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Enfisema: {(chkEnfisema.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Sibilancias: {(chkSibilancias.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Blando: {(chkBlando.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Hepatoesplenomegalia: {(chkHepatoesplenomegalia.Checked ? "Sí" : "No")}");

                    doc.InsertParagraph($"Conducto: {(chkConducto.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Tabique: {(chkTabique.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Hipertrofica: {(chkHipertrofica.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Edema Glandulas: {(chkEdemaGlandulas.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Roncus: {(chkRoncus.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Expación: {(chkExpacion.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Ronchas: {(chkRonchas.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Frote: {(chkFrote.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Soplos: {(chkSoplos.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Irritación: {(chkIrritacion.Checked ? "Sí" : "No")}");

                    doc.InsertParagraph($"Abdomen: {(chkAbdomen.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Pupilas: {(chkPupilas.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Lengua: {(chkLengua.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Deformidad: {(chkDeformidad.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Leucomas: {(chkLeucomas.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Desviación: {(chkDesviacion.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Tórax: {(chkTorax.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Peristaltismo: {(chkPeristaltismo.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Genitales: {(chkGenitales.Checked ? "Sí" : "No")}");
                    doc.InsertParagraph($"Piel: {(chkPiel.Checked ? "Sí" : "No")}");

                    doc.Save();
                }

                MessageBox.Show("Los datos se han guardado correctamente y se generó el documento Word.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar generar el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // Método para limpiar los campos
            void LimpiarCampos()
            {
                txtConsultaPor.Clear();
                txtPaciente.Clear();
                txtPresenteEnfermedad.Clear();
                txtPresion.Clear();
                txtSignosVitales.Clear();
                txtFC.Clear();
                txtFR.Clear();
                txtSaturacion.Clear();
                txtPeso.Clear();
                txtTalla.Clear();
                txtMasaCorporal.Clear();
                txtExamenesGabinete.Clear();
                txtImpresion.Clear();
                txtExamenesLaboratorio.Clear();


                chkHemodialisis.Checked = false;
                chkHipertension.Checked = false;
                chkDiabetes.Checked = false;


                chkExtremidades.Checked = false;
                chkCabeza.Checked = false;
                chkTimpanica.Checked = false;
                chkCornetes.Checked = false;
                chkBoca.Checked = false;
                chkDesviaciones.Checked = false;
                chkPalpanMasas.Checked = false;
                chkTirajes.Checked = false;
                chkEsteroides.Checked = false;
                chkCirculacion.Checked = false;
                chkTimpanismo.Checked = false;

                chkHundimientos.Checked = false;
                chkNariz.Checked = false;
                chkAleteo.Checked = false;
                chkLabios.Checked = false;
                chkFaringe.Checked = false;
                chkTiroides.Checked = false;
                chkEnfisema.Checked = false;
                chkSibilancias.Checked = false;
                chkBlando.Checked = false;
                chkHepatoesplenomegalia.Checked = false;

                chkConducto.Checked = false;
                chkTabique.Checked = false;
                chkHipertrofica.Checked = false;
                chkEdemaGlandulas.Checked = false;
                chkRoncus.Checked = false;
                chkExpacion.Checked = false;
                chkRonchas.Checked = false;
                chkFrote.Checked = false;
                chkSoplos.Checked = false;
                chkIrritacion.Checked = false;

                chkAbdomen.Checked = false;
                chkPupilas.Checked = false;
                chkLengua.Checked = false;
                chkDeformidad.Checked = false;
                chkLeucomas.Checked = false;
                chkDesviacion.Checked = false;
                chkTorax.Checked = false;
                chkPeristaltismo.Checked = false;
                chkGenitales.Checked = false;
                chkPiel.Checked = false;
            }

        }

        private void CalcularIMC()
        {
            if (double.TryParse(txtPeso.Text, out double peso) &&
                double.TryParse(txtTalla.Text, out double tallaEnMetros) && tallaEnMetros > 0)
            {
                double imc = peso / (tallaEnMetros * tallaEnMetros);
                txtMasaCorporal.Text = imc.ToString("0.00");
            }
            else
            {
                txtMasaCorporal.Text = "";
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

        private void txtTalla_TextChanged_1(object sender, EventArgs e)
        {
            CalcularIMC();
        }

        private void txtPeso_TextChanged_1(object sender, EventArgs e)
        {
            CalcularIMC();
        }

        private bool yaMostroMensaje = false;

        private void SoloNumerosDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            // Permitir teclas de control como backspace
            if (char.IsControl(e.KeyChar))
            {
                yaMostroMensaje = false;
                return;
            }

            // Permitir punto decimal si aún no existe
            if (e.KeyChar == '.' && !textBox.Text.Contains('.'))
            {
                yaMostroMensaje = false;
                return;
            }

            // Si no es dígito o punto adicional
            if (!char.IsDigit(e.KeyChar) || (e.KeyChar == '.' && textBox.Text.Contains('.')))
            {
                e.Handled = true;

                if (!yaMostroMensaje)
                {
                    MessageBox.Show("Solo se permiten números.", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    yaMostroMensaje = true;
                }
            }
            else
            {
                yaMostroMensaje = false; // Reiniciar bandera si la entrada fue válida
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosDecimales(e, txtPeso);
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosDecimales(e, txtTalla);
        }
    }
}

