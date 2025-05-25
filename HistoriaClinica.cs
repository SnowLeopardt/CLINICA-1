using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using PdfDocument = iTextSharp.text.Document;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WordDocument = DocumentFormat.OpenXml.Wordprocessing.Document;
using WordParagraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using WordRun = DocumentFormat.OpenXml.Wordprocessing.Run;
using WordBreak = DocumentFormat.OpenXml.Wordprocessing.Break;
using WordBody = DocumentFormat.OpenXml.Wordprocessing.Body;
using WordText = DocumentFormat.OpenXml.Wordprocessing.Text;
using WordRunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
using WordBold = DocumentFormat.OpenXml.Wordprocessing.Bold;
using WordFontSize = DocumentFormat.OpenXml.Wordprocessing.FontSize;


namespace CLINICA_1
{
    public partial class HistoriaClinica : Form
    {
        //Cambiar Conexion:
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

                        // =======================================
                        // GENERAR DOCUMENTO WORD CON OPEN XML SDK
                        // =======================================

                        string pacienteFolder = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                            "Pacientes",
                            txtPaciente.Text.Trim()
                        );

                        // Verificar si la carpeta del paciente ya existe
                        if (!Directory.Exists(pacienteFolder))
                        {
                            MessageBox.Show($"La carpeta del paciente '{txtPaciente.Text}' no existe.\nVerifica en: {pacienteFolder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Crear nombre de archivo con marca de tiempo para evitar sobreescrituras
                        string fileName = $"HistoriaClinica_{txtPaciente.Text.Trim()}.docx";
                        string docPath = Path.Combine(pacienteFolder, fileName);

                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(docPath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                        {
                            MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                            mainPart.Document = new WordDocument();
                            WordBody body = new WordBody();

                            void AddParagraph(string text, bool bold = false, int fontSize = 24)
                            {
                                WordRunProperties props = new WordRunProperties();
                                props.Append(new WordFontSize() { Val = fontSize.ToString() });

                                if (bold)
                                    props.Append(new WordBold());

                                WordRun run = new WordRun();
                                run.Append(props);
                                run.Append(new WordText(text));

                                WordParagraph para = new WordParagraph(run);
                                body.Append(para);
                            }

                            // Contenido del documento
                            AddParagraph("HISTORIA CLÍNICA", bold: true, fontSize: 32);
                            body.Append(new WordParagraph(new WordRun(new WordBreak()))); // Salto de línea

                            AddParagraph($"Consulta por: {txtConsultaPor.Text}");
                            AddParagraph($"Paciente: {txtPaciente.Text}");
                            AddParagraph($"Presente Enfermedad: {txtPresenteEnfermedad.Text}");
                            AddParagraph($"Signos Vitales: {txtSignosVitales.Text}");
                            AddParagraph($"Presión Arterial: {txtPresion.Text}");
                            AddParagraph($"Frecuencia Cardiaca: {txtFC.Text}");
                            AddParagraph($"Frecuencia Respiratoria: {txtFR.Text}");
                            AddParagraph($"Saturación Oxígeno: {txtSaturacion.Text}");
                            AddParagraph($"Peso: {txtPeso.Text}");
                            AddParagraph($"Talla: {txtTalla.Text}");
                            AddParagraph($"IMC: {txtMasaCorporal.Text}");
                            AddParagraph($"Gabinete: {txtExamenesGabinete.Text}");
                            AddParagraph($"Laboratorios: {txtExamenesLaboratorio.Text}");
                            AddParagraph($"Impresión Diagnóstica: {txtImpresion.Text}");

                            // Checkbox
                            AddParagraph($"Hemodiálisis: {(chkHemodialisis.Checked ? "Sí" : "No")}");
                            AddParagraph($"Hipertensión: {(chkHipertension.Checked ? "Sí" : "No")}");
                            AddParagraph($"Diabetes: {(chkDiabetes.Checked ? "Sí" : "No")}");
                            AddParagraph($"Extremidades: {(chkExtremidades.Checked ? "Sí" : "No")}");
                            AddParagraph($"Cabeza: {(chkCabeza.Checked ? "Sí" : "No")}");
                            AddParagraph($"Timpánica: {(chkTimpanica.Checked ? "Sí" : "No")}");
                            AddParagraph($"Cornetes: {(chkCornetes.Checked ? "Sí" : "No")}");
                            AddParagraph($"Boca: {(chkBoca.Checked ? "Sí" : "No")}");
                            AddParagraph($"Desviaciones: {(chkDesviaciones.Checked ? "Sí" : "No")}");
                            AddParagraph($"Palpan Masas: {(chkPalpanMasas.Checked ? "Sí" : "No")}");
                            AddParagraph($"Tirajes: {(chkTirajes.Checked ? "Sí" : "No")}");
                            AddParagraph($"Esteroides: {(chkEsteroides.Checked ? "Sí" : "No")}");
                            AddParagraph($"Circulación: {(chkCirculacion.Checked ? "Sí" : "No")}");
                            AddParagraph($"Timpanismo: {(chkTimpanismo.Checked ? "Sí" : "No")}");
                            AddParagraph($"Hundimientos: {(chkHundimientos.Checked ? "Sí" : "No")}");
                            AddParagraph($"Nariz: {(chkNariz.Checked ? "Sí" : "No")}");
                            AddParagraph($"Aleteo: {(chkAleteo.Checked ? "Sí" : "No")}");
                            AddParagraph($"Labios: {(chkLabios.Checked ? "Sí" : "No")}");
                            AddParagraph($"Faringe: {(chkFaringe.Checked ? "Sí" : "No")}");
                            AddParagraph($"Tiroides: {(chkTiroides.Checked ? "Sí" : "No")}");
                            AddParagraph($"Enfisema: {(chkEnfisema.Checked ? "Sí" : "No")}");
                            AddParagraph($"Sibilancias: {(chkSibilancias.Checked ? "Sí" : "No")}");
                            AddParagraph($"Blando: {(chkBlando.Checked ? "Sí" : "No")}");
                            AddParagraph($"Hepatoesplenomegalia: {(chkHepatoesplenomegalia.Checked ? "Sí" : "No")}");
                            AddParagraph($"Conducto: {(chkConducto.Checked ? "Sí" : "No")}");
                            AddParagraph($"Tabique: {(chkTabique.Checked ? "Sí" : "No")}");
                            AddParagraph($"Hipertrofica: {(chkHipertrofica.Checked ? "Sí" : "No")}");
                            AddParagraph($"Edema Glandulas: {(chkEdemaGlandulas.Checked ? "Sí" : "No")}");
                            AddParagraph($"Roncus: {(chkRoncus.Checked ? "Sí" : "No")}");
                            AddParagraph($"Expación: {(chkExpacion.Checked ? "Sí" : "No")}");
                            AddParagraph($"Ronchas: {(chkRonchas.Checked ? "Sí" : "No")}");
                            AddParagraph($"Frote: {(chkFrote.Checked ? "Sí" : "No")}");
                            AddParagraph($"Soplos: {(chkSoplos.Checked ? "Sí" : "No")}");
                            AddParagraph($"Irritación: {(chkIrritacion.Checked ? "Sí" : "No")}");
                            AddParagraph($"Abdomen: {(chkAbdomen.Checked ? "Sí" : "No")}");
                            AddParagraph($"Pupilas: {(chkPupilas.Checked ? "Sí" : "No")}");
                            AddParagraph($"Lengua: {(chkLengua.Checked ? "Sí" : "No")}");
                            AddParagraph($"Deformidad: {(chkDeformidad.Checked ? "Sí" : "No")}");
                            AddParagraph($"Leucomas: {(chkLeucomas.Checked ? "Sí" : "No")}");
                            AddParagraph($"Desviación: {(chkDesviacion.Checked ? "Sí" : "No")}");
                            AddParagraph($"Tórax: {(chkTorax.Checked ? "Sí" : "No")}");
                            AddParagraph($"Peristaltismo: {(chkPeristaltismo.Checked ? "Sí" : "No")}");
                            AddParagraph($"Genitales: {(chkGenitales.Checked ? "Sí" : "No")}");
                            AddParagraph($"Piel: {(chkPiel.Checked ? "Sí" : "No")}");

                            mainPart.Document.Append(body);
                            mainPart.Document.Save();
                        }

                        MessageBox.Show("Datos guardados correctamente y documento Word generado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos(); // Método para limpiar campos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
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




        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta temporal del PDF
                string rutaPDF = Path.Combine(Path.GetTempPath(), $"HistoriaClinica_{txtPaciente.Text.Trim()}.pdf");

                // Crear documento PDF sin ambigüedad
                iTextSharp.text.Document documentoPDF = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 40f, 40f, 40f, 40f);
                iTextSharp.text.pdf.PdfWriter escritorPDF = iTextSharp.text.pdf.PdfWriter.GetInstance(documentoPDF, new FileStream(rutaPDF, FileMode.Create));

                // Establecer color de fondo para toda la página
                System.Drawing.Color colorFondo = System.Drawing.SystemColors.ActiveCaption;
                escritorPDF.PageEvent = new FondoPaginaCompleto(colorFondo);

                documentoPDF.Open();

                // Estilos explícitos
                var fuenteTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 15, iTextSharp.text.BaseColor.BLACK);
                var fuenteSeccion = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 11, iTextSharp.text.BaseColor.WHITE);
                var fuenteEtiqueta = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
                var fuenteValor = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10);

                // Título
                iTextSharp.text.Paragraph encabezado = new iTextSharp.text.Paragraph("HISTORIA CLÍNICA DEL PACIENTE", fuenteTitulo);
                encabezado.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                encabezado.SpacingAfter = 20f;
                documentoPDF.Add(encabezado);

                // Tabla de 2 columnas
                iTextSharp.text.pdf.PdfPTable CrearTabla(string etiqueta, string valor)
                {
                    var tabla = new iTextSharp.text.pdf.PdfPTable(2);
                    tabla.WidthPercentage = 100;
                    tabla.SpacingAfter = 10f;
                    tabla.SetWidths(new float[] { 1f, 3f });

                    tabla.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(etiqueta, fuenteEtiqueta)) { Border = 0 });
                    tabla.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(valor, fuenteValor)) { Border = 0 });
                    return tabla;
                }

                // Datos generales
                documentoPDF.Add(new iTextSharp.text.Paragraph("Datos Generales:", fuenteSeccion));
                documentoPDF.Add(CrearTabla("Paciente:", txtPaciente.Text));
                documentoPDF.Add(CrearTabla("Consulta por:", txtConsultaPor.Text));
                documentoPDF.Add(CrearTabla("Presente Enfermedad:", txtPresenteEnfermedad.Text));

                // Signos vitales
                documentoPDF.Add(new iTextSharp.text.Paragraph("Signos Vitales:", fuenteSeccion));
                documentoPDF.Add(CrearTabla("Signos Vitales:", txtSignosVitales.Text));
                documentoPDF.Add(CrearTabla("Presión Arterial:", txtPresion.Text));
                documentoPDF.Add(CrearTabla("Frecuencia Cardiaca:", txtFC.Text));
                documentoPDF.Add(CrearTabla("Frecuencia Respiratoria:", txtFR.Text));
                documentoPDF.Add(CrearTabla("Saturación Oxígeno:", txtSaturacion.Text));
                documentoPDF.Add(CrearTabla("Peso:", txtPeso.Text));
                documentoPDF.Add(CrearTabla("Talla:", txtTalla.Text));
                documentoPDF.Add(CrearTabla("IMC:", txtMasaCorporal.Text));

                // Exámenes
                documentoPDF.Add(new iTextSharp.text.Paragraph("Exámenes Complementarios:", fuenteSeccion));
                documentoPDF.Add(CrearTabla("Gabinete:", txtExamenesGabinete.Text));
                documentoPDF.Add(CrearTabla("Laboratorios:", txtExamenesLaboratorio.Text));
                documentoPDF.Add(CrearTabla("Impresión Diagnóstica:", txtImpresion.Text));

                // CheckBoxes agrupados
                documentoPDF.Add(new iTextSharp.text.Paragraph("Exploración Clínica:", fuenteSeccion));
                string[] etiquetas = {
        "Hemodiálisis", "Hipertensión", "Diabetes", "Extremidades", "Cabeza", "Timpánica", "Cornetes", "Boca",
        "Desviaciones", "Palpan Masas", "Tirajes", "Esteroides", "Circulación", "Timpanismo", "Hundimientos",
        "Nariz", "Aleteo", "Labios", "Faringe", "Tiroides", "Enfisema", "Sibilancias", "Blando", "Hepatoesplenomegalia",
        "Conducto", "Tabique", "Hipertrofica", "Edema Glandulas", "Roncus", "Expación", "Ronchas", "Frote", "Soplos",
        "Irritación", "Abdomen", "Pupilas", "Lengua", "Deformidad", "Leucomas", "Desviación", "Tórax", "Peristaltismo",
        "Genitales", "Piel"
    };

                System.Windows.Forms.CheckBox[] checks = {
        chkHemodialisis, chkHipertension, chkDiabetes, chkExtremidades, chkCabeza, chkTimpanica, chkCornetes, chkBoca,
        chkDesviaciones, chkPalpanMasas, chkTirajes, chkEsteroides, chkCirculacion, chkTimpanismo, chkHundimientos,
        chkNariz, chkAleteo, chkLabios, chkFaringe, chkTiroides, chkEnfisema, chkSibilancias, chkBlando, chkHepatoesplenomegalia,
        chkConducto, chkTabique, chkHipertrofica, chkEdemaGlandulas, chkRoncus, chkExpacion, chkRonchas, chkFrote, chkSoplos,
        chkIrritacion, chkAbdomen, chkPupilas, chkLengua, chkDeformidad, chkLeucomas, chkDesviacion, chkTorax, chkPeristaltismo,
        chkGenitales, chkPiel
    };
                var tablaChecks = new iTextSharp.text.pdf.PdfPTable(3);
                tablaChecks.WidthPercentage = 100;
                tablaChecks.SpacingBefore = 10f;
                tablaChecks.DefaultCell.Border = 0;

                // Color de fondo
                System.Drawing.Color colorSystem = System.Drawing.SystemColors.ActiveCaption;
                var fondoCelda = new iTextSharp.text.BaseColor(colorSystem.R, colorSystem.G, colorSystem.B);

                // Fuente para todo el texto
                var fuenteTexto = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.BaseColor.BLACK);

                for (int i = 0; i < etiquetas.Length; i++)
                {
                    bool marcado = checks[i].Checked;

                    string valor = marcado ? "Sí" : "No";

                    // Construir texto como: "Cabeza: Sí"
                    string texto = $"{etiquetas[i]}: {valor}";

                    var frase = new iTextSharp.text.Phrase(texto, fuenteTexto);

                    var celda = new iTextSharp.text.pdf.PdfPCell(frase)
                    {
                        Border = 0,
                        BackgroundColor = fondoCelda,
                        Padding = 5f,
                        VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    };

                    tablaChecks.AddCell(celda);
                }

                documentoPDF.Add(tablaChecks);

                documentoPDF.Close();

                // Abrir PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }

        public class FondoPaginaCompleto : iTextSharp.text.pdf.PdfPageEventHelper
        {
            private readonly iTextSharp.text.BaseColor fondoColor;

            public FondoPaginaCompleto(System.Drawing.Color colorWindows)
            {
                fondoColor = new iTextSharp.text.BaseColor(colorWindows.R, colorWindows.G, colorWindows.B);
            }

            public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
            {
                var content = writer.DirectContentUnder;
                content.SaveState();
                content.SetColorFill(fondoColor);

                // Rectángulo que cubre TODA la página
                content.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);

                content.Fill();
                content.RestoreState();
            }
        }



    }
}