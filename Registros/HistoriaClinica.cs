using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
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
        string clasificacionIMC = "";
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
        //BOTON DE GUARDAR
        private void guardar_Click(object sender, EventArgs e)
        {
            CalcularIMC();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
    INSERT INTO HistoriaClinica (
        Paciente, ConsultaPor, PresenteEnfermedad, AntecedentesPersonales, PresionArterial, FrecuenciaCardiaca, FrecuenciaRespiratoria,
        SaturacionOxigeno, Peso, Talla, IndiceMasaCorporal, ClasificacionIMC,
        ExamenFisico, ExamenesLaboratorios, ExamenesGabinete,
        Impresion, [Plan]
    ) VALUES (
        @Paciente, @ConsultaPor, @PresenteEnfermedad, @AntecedentesPersonales,
         @PresionArterial, @FrecuenciaCardiaca, @FrecuenciaRespiratoria,
        @SaturacionOxigeno, @Peso, @Talla, @IndiceMasaCorporal,
        @ExamenFisico, @ExamenesLaboratorios, @ExamenesGabinete, @ClasificacionIMC,
        @Impresion, @Plan
    );";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Parámetros visibles en la imagen
                        cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);
                        cmd.Parameters.AddWithValue("@ConsultaPor", txtConsultaPor.Text);
                        cmd.Parameters.AddWithValue("@PresenteEnfermedad", txtPresenteEnfermedad.Text);
                        cmd.Parameters.AddWithValue("@AntecedentesPersonales", txtAntecedentesPersonales.Text);
     
                        cmd.Parameters.AddWithValue("@PresionArterial", txtPresion.Text);
                        cmd.Parameters.AddWithValue("@FrecuenciaCardiaca", txtFC.Text);
                        cmd.Parameters.AddWithValue("@FrecuenciaRespiratoria", txtFR.Text);
                        cmd.Parameters.AddWithValue("@SaturacionOxigeno", txtSaturacion.Text);
                        cmd.Parameters.AddWithValue("@Peso", txtPeso.Text);
                        cmd.Parameters.AddWithValue("@Talla", txtTalla.Text);
                        cmd.Parameters.AddWithValue("@IndiceMasaCorporal", txtMasaCorporal.Text);
                        cmd.Parameters.AddWithValue("@ClasificacionIMC", lblClasificacionIMC.Text);
                        cmd.Parameters.AddWithValue("@ExamenFisico", txtExamenFisico.Text);
                        cmd.Parameters.AddWithValue("@ExamenesLaboratorios", txtExamenesLaboratorio.Text);
                        cmd.Parameters.AddWithValue("@ExamenesGabinete", txtExamenesGabinete.Text);
                        cmd.Parameters.AddWithValue("@Impresion", txtImpresion.Text);
                        cmd.Parameters.AddWithValue("@Plan", txtPlan.Text);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();

                            // ================================
                            // GENERAR DOCUMENTO WORD
                            // ================================
                            string pacienteFolder = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                "Pacientes",
                                txtPaciente.Text.Trim()
                            );

                            if (!Directory.Exists(pacienteFolder))
                            {
                                MessageBox.Show($"La carpeta del paciente '{txtPaciente.Text}' no existe.\nVerifica en: {pacienteFolder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

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

                                // Contenido del documento Word
                                AddParagraph("HISTORIA CLÍNICA", bold: true, fontSize: 32);
                                AddParagraph($"Paciente: {txtPaciente.Text}");
                                AddParagraph($"Consulta por: {txtConsultaPor.Text}");
                                AddParagraph($"Presente Enfermedad: {txtPresenteEnfermedad.Text}");
                                AddParagraph($"Antecedentes Personales: {txtAntecedentesPersonales.Text}");

                                AddParagraph($"Presión Arterial: {txtPresion.Text}");
                                AddParagraph($"Frecuencia Cardiaca: {txtFC.Text}");
                                AddParagraph($"Frecuencia Respiratoria: {txtFR.Text}");
                                AddParagraph($"Saturación Oxígeno: {txtSaturacion.Text}");
                                AddParagraph($"Peso: {txtPeso.Text}");
                                AddParagraph($"Talla: {txtTalla.Text}");
                                AddParagraph($"IMC: {txtMasaCorporal.Text}");
                                AddParagraph($"Clasificación IMC: {lblClasificacionIMC.Text}");





                                AddParagraph($"Examen Físico: {txtExamenFisico.Text}");
                                AddParagraph($"Exámenes de Laboratorios: {txtExamenesLaboratorio.Text}");
                                AddParagraph($"Exámenes de Gabinete: {txtExamenesGabinete.Text}");
                                AddParagraph($"Impresión Diagnóstica: {txtImpresion.Text}");
                                AddParagraph($"Plan: {txtPlan.Text}");

                                mainPart.Document.Append(body);
                                mainPart.Document.Save();
                            }

                            MessageBox.Show("Datos guardados correctamente y documento Word generado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                txtFC.Clear();
                txtFR.Clear();
                txtSaturacion.Clear();
                txtPeso.Clear();
                txtTalla.Clear();
                txtMasaCorporal.Clear();
                txtExamenesGabinete.Clear();
                txtImpresion.Clear();
                txtExamenesLaboratorio.Clear();
                txtPlan.Clear();
                txtAntecedentesPersonales.Clear();
                txtExamenFisico.Clear();
            }
        }
        private void CalcularIMC()
        {
            if (double.TryParse(txtPeso.Text, out double peso) &&
                double.TryParse(txtTalla.Text, out double tallaEnMetros) && tallaEnMetros > 0)
            {
                double imc = peso / (tallaEnMetros * tallaEnMetros);
                txtMasaCorporal.Text = imc.ToString("0.00");

                if (imc < 18.5)
                    clasificacionIMC = "Bajo peso";
                else if (imc <= 24.9)
                    clasificacionIMC = "Normal";
                else if (imc <= 29.9)
                    clasificacionIMC = "Sobrepeso";
                else
                    clasificacionIMC = "Obesidad";

                lblClasificacionIMC.Text = clasificacionIMC;
            }
            else
            {
                txtMasaCorporal.Text = "";
                lblClasificacionIMC.Text = "";
                clasificacionIMC = "";
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
        //CALCULAR LA IMC


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


        private void txtPresion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rutaPDF = Path.Combine(Path.GetTempPath(), $"HistoriaClinica_{txtPaciente.Text.Trim()}.pdf");

                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 40f, 40f, 40f, 40f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(rutaPDF, FileMode.Create));
                writer.PageEvent = new FondoPaginaCompleto(System.Drawing.SystemColors.ActiveCaption);
                pdfDoc.Open();

                // 🖼️ Agregar imagen superior derecha (sello que SÍ se imprime)
                string rutaImagenSello = @"C:\Users\emili\OneDrive\Documentos\imagenes\selloimprimir.png";
            


                if (File.Exists(rutaImagenSello))
                {
                    iTextSharp.text.Image sello = iTextSharp.text.Image.GetInstance(rutaImagenSello);
                    sello.ScaleAbsolute(120f, 90f);
                    sello.SetAbsolutePosition(pdfDoc.PageSize.Width - sello.ScaledWidth - 40f, pdfDoc.PageSize.Height - sello.ScaledHeight - 40f);
                    pdfDoc.Add(sello);
                }
               

                // 🖋️ Fuentes
                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK);
                var fuenteCampo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // 🧩 Función para agregar campos
                void AddCampoValor(string campo, string valor)
                {
                    iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph();
                    p.SpacingAfter = 10f; // Espacio entre renglones
                    p.Add(new Chunk(campo + ": ", fuenteCampo));
                    p.Add(new Chunk(valor, fuenteTexto));
                    pdfDoc.Add(p);
                }

                void AddTitulo(string texto)
                {
                    iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph(texto, fuenteTitulo)
                    {
                        SpacingAfter = 10f,
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(p);
                }

                // 🔍 Datos desde SQL
                string nombrePaciente = txtPaciente.Text.Trim();
                string cs = "Server=LAPTOP-M35CB1FF;Database=ClinicaVargas;Integrated Security=True;";
                string sql = @"SELECT Nombre, Edad, Telefono, Direccion, DUI, Responsable, TelResponsable, DirResponsable, CorreoResponsable, FechaNacimiento, FechaHoraRegistro 
                   FROM Pacientes WHERE Nombre = @Nombre";

                int edad = 0;
                string telefono = "", direccion = "", dui = "", responsable = "", telResponsable = "", dirResponsable = "", correoResponsable = "";
                DateTime fechaNacimiento = DateTime.MinValue, fechaHoraRegistro = DateTime.Now;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Nombre", nombrePaciente);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        edad = Convert.ToInt32(dr["Edad"]);
                        telefono = dr["Telefono"].ToString();
                        direccion = dr["Direccion"].ToString();
                        dui = dr["DUI"].ToString();
                        responsable = dr["Responsable"].ToString();
                        telResponsable = dr["TelResponsable"].ToString();
                        dirResponsable = dr["DirResponsable"].ToString();
                        correoResponsable = dr["CorreoResponsable"].ToString();
                        fechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                        fechaHoraRegistro = Convert.ToDateTime(dr["FechaHoraRegistro"]);
                    }
                }

                // 📝 Escritura de datos
                AddTitulo("HISTORIA CLÍNICA");
                AddCampoValor("Paciente", nombrePaciente);
                AddCampoValor("Consulta por", txtConsultaPor.Text);
                AddCampoValor("Edad", edad + " años");
                AddCampoValor("Fecha de Nacimiento", fechaNacimiento.ToShortDateString());
                AddCampoValor("Teléfono", telefono);
                AddCampoValor("Dirección", direccion);
                AddCampoValor("DUI", dui);

                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                AddCampoValor("Responsable", responsable);
                AddCampoValor("Telefono Responsable", telResponsable);
                AddCampoValor("Direccion Responsable", dirResponsable);
                AddCampoValor("Correo Responsable", correoResponsable);
                AddCampoValor("Fecha y Hora de Registro", fechaHoraRegistro.ToString("yyyy-MM-dd hh:mm tt"));

                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                AddCampoValor("Presente Enfermedad", txtPresenteEnfermedad.Text);
                AddCampoValor("Antecedentes Personales", txtAntecedentesPersonales.Text);
                AddCampoValor("Presión Arterial", txtPresion.Text);
                AddCampoValor("Frecuencia Cardíaca", txtFC.Text);
                AddCampoValor("Frecuencia Respiratoria", txtFR.Text);
                AddCampoValor("Saturación", txtSaturacion.Text);
                AddCampoValor("Peso", txtPeso.Text);
                AddCampoValor("Talla", txtTalla.Text);
                AddCampoValor("IMC", txtMasaCorporal.Text);
                AddCampoValor("Clasificación IMC", clasificacionIMC);
                AddCampoValor("Examen Físico", txtExamenFisico.Text);
                AddCampoValor("Exámenes de Laboratorio", txtExamenesLaboratorio.Text);
                AddCampoValor("Exámenes de Gabinete", txtExamenesGabinete.Text);
                AddCampoValor("Impresión Diagnóstica", txtImpresion.Text);
                AddCampoValor("Plan", txtPlan.Text);

                pdfDoc.Close();

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

            // Método para limpiar los campos
            void LimpiarCampos()
            {
                txtConsultaPor.Clear();
                txtPaciente.Clear();
                txtPresenteEnfermedad.Clear();
                txtPresion.Clear();
                txtFC.Clear();
                txtFR.Clear();
                txtSaturacion.Clear();
                txtPeso.Clear();
                txtTalla.Clear();
                txtMasaCorporal.Clear();
                txtExamenesGabinete.Clear();
                txtImpresion.Clear();
                txtExamenesLaboratorio.Clear();
                txtPlan.Clear();
                txtAntecedentesPersonales.Clear();
                txtExamenFisico.Clear();
            }
        }

        //FONDO PDF
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

        private void txtExamenFisico_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        //BOTON DE REGRESAR
        private void button1_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu(); // Crear una instancia del formulario Menu
            this.Hide();
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            CalcularIMC();
        }

        private void txtTalla_TextChanged(object sender, EventArgs e)
        {
            CalcularIMC();
        }

        private void txtMasaCorporal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CalcularIMC();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
    INSERT INTO HistoriaClinica (
        Paciente, ConsultaPor, PresenteEnfermedad, AntecedentesPersonales, PresionArterial, FrecuenciaCardiaca, FrecuenciaRespiratoria,
        SaturacionOxigeno, Peso, Talla, IndiceMasaCorporal, ClasificacionIMC,
        ExamenFisico, ExamenesLaboratorios, ExamenesGabinete,
        Impresion, [Plan]
    ) VALUES (
        @Paciente, @ConsultaPor, @PresenteEnfermedad, @AntecedentesPersonales,
         @PresionArterial, @FrecuenciaCardiaca, @FrecuenciaRespiratoria,
        @SaturacionOxigeno, @Peso, @Talla, @IndiceMasaCorporal,
        @ExamenFisico, @ExamenesLaboratorios, @ExamenesGabinete, @ClasificacionIMC,
        @Impresion, @Plan
    );";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Parámetros visibles en la imagen
                        cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);
                        cmd.Parameters.AddWithValue("@ConsultaPor", txtConsultaPor.Text);
                        cmd.Parameters.AddWithValue("@PresenteEnfermedad", txtPresenteEnfermedad.Text);
                        cmd.Parameters.AddWithValue("@AntecedentesPersonales", txtAntecedentesPersonales.Text);

                        cmd.Parameters.AddWithValue("@PresionArterial", txtPresion.Text);
                        cmd.Parameters.AddWithValue("@FrecuenciaCardiaca", txtFC.Text);
                        cmd.Parameters.AddWithValue("@FrecuenciaRespiratoria", txtFR.Text);
                        cmd.Parameters.AddWithValue("@SaturacionOxigeno", txtSaturacion.Text);
                        cmd.Parameters.AddWithValue("@Peso", txtPeso.Text);
                        cmd.Parameters.AddWithValue("@Talla", txtTalla.Text);
                        cmd.Parameters.AddWithValue("@IndiceMasaCorporal", txtMasaCorporal.Text);
                        cmd.Parameters.AddWithValue("@ClasificacionIMC", lblClasificacionIMC.Text);
                        cmd.Parameters.AddWithValue("@ExamenFisico", txtExamenFisico.Text);
                        cmd.Parameters.AddWithValue("@ExamenesLaboratorios", txtExamenesLaboratorio.Text);
                        cmd.Parameters.AddWithValue("@ExamenesGabinete", txtExamenesGabinete.Text);
                        cmd.Parameters.AddWithValue("@Impresion", txtImpresion.Text);
                        cmd.Parameters.AddWithValue("@Plan", txtPlan.Text);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();

                            // ================================
                            // GENERAR DOCUMENTO WORD
                            // ================================
                            string pacienteFolder = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                "Pacientes",
                                txtPaciente.Text.Trim()
                            );

                            if (!Directory.Exists(pacienteFolder))
                            {
                                MessageBox.Show($"La carpeta del paciente '{txtPaciente.Text}' no existe.\nVerifica en: {pacienteFolder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

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

                                // Contenido del documento Word
                                AddParagraph("HISTORIA CLÍNICA", bold: true, fontSize: 32);
                                AddParagraph($"Paciente: {txtPaciente.Text}");
                                AddParagraph($"Consulta por: {txtConsultaPor.Text}");
                                AddParagraph($"Presente Enfermedad: {txtPresenteEnfermedad.Text}");
                                AddParagraph($"Antecedentes Personales: {txtAntecedentesPersonales.Text}");

                                AddParagraph($"Presión Arterial: {txtPresion.Text}");
                                AddParagraph($"Frecuencia Cardiaca: {txtFC.Text}");
                                AddParagraph($"Frecuencia Respiratoria: {txtFR.Text}");
                                AddParagraph($"Saturación Oxígeno: {txtSaturacion.Text}");
                                AddParagraph($"Peso: {txtPeso.Text}");
                                AddParagraph($"Talla: {txtTalla.Text}");
                                AddParagraph($"IMC: {txtMasaCorporal.Text}");
                                AddParagraph($"Clasificación IMC: {lblClasificacionIMC.Text}");





                                AddParagraph($"Examen Físico: {txtExamenFisico.Text}");
                                AddParagraph($"Exámenes de Laboratorios: {txtExamenesLaboratorio.Text}");
                                AddParagraph($"Exámenes de Gabinete: {txtExamenesGabinete.Text}");
                                AddParagraph($"Impresión Diagnóstica: {txtImpresion.Text}");
                                AddParagraph($"Plan: {txtPlan.Text}");

                                mainPart.Document.Append(body);
                                mainPart.Document.Save();
                            }

                            MessageBox.Show("Datos guardados correctamente y documento Word generado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
        
        void LimpiarCampos()
        {
            txtConsultaPor.Clear();
            txtPaciente.Clear();
            txtPresenteEnfermedad.Clear();
            txtPresion.Clear();
            txtFC.Clear();
            txtFR.Clear();
            txtSaturacion.Clear();
            txtPeso.Clear();
            txtTalla.Clear();
            txtMasaCorporal.Clear();
            txtExamenesGabinete.Clear();
            txtImpresion.Clear();
            txtExamenesLaboratorio.Clear();
            txtPlan.Clear();
            txtAntecedentesPersonales.Clear();
            txtExamenFisico.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void label19_Click_1(object sender, EventArgs e)
        {

        }

        private void txtExamenesLaboratorio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExamenesGabinete_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void txtImpresion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPresion_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtFC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaturacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtPlan_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtAntecedentesPersonales_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void txtPresenteEnfermedad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtConsultaPor_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click_1(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblClasificacionIMC_Click(object sender, EventArgs e)
        {

        }
    }

}
    




