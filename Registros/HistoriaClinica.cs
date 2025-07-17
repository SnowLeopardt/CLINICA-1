using System;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WordDocument = DocumentFormat.OpenXml.Wordprocessing.Document;
using WordParagraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using WordRun = DocumentFormat.OpenXml.Wordprocessing.Run;
using WordBody = DocumentFormat.OpenXml.Wordprocessing.Body;
using WordText = DocumentFormat.OpenXml.Wordprocessing.Text;
using WordRunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
using WordBold = DocumentFormat.OpenXml.Wordprocessing.Bold;
using WordFontSize = DocumentFormat.OpenXml.Wordprocessing.FontSize;
using DocumentFormat.OpenXml;
using System.Globalization;

namespace CLINICA_1
{

    public partial class HistoriaClinica : Form
    {
        //Cambiar Conexion:
        private string connectionString = "Server=localhost;Database=ClinicaVargas;Integrated Security=True;";
        string clasificacionIMC = "";
        private int pacienteId;


        public HistoriaClinica() : this(0) { }
        public HistoriaClinica(int idPaciente)
        {
            InitializeComponent();


            txtPaciente.KeyDown += txtPaciente_KeyDown;

            pacienteId = idPaciente;

            CargarNombrePaciente();

            txtPeso.KeyPress += txtPeso_KeyPress;
            txtTalla.KeyPress += txtTalla_KeyPress;

            txtMasaCorporal.ReadOnly = true;
        }

        //EXAMENES 
        private void btnAnteriores_Click(object sender, EventArgs e)
        {
            string examenes = ObtenerExamenesLaboratorioAnteriores();
            ores ventana = new ores(examenes);
            ventana.ShowDialog();
        }

        //EXAMENES
        private string ObtenerExamenesLaboratorioAnteriores()
        {
            string resultado = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
SELECT TOP 1 FechaRegistro, ExamenesLaboratorios, ExamenesGabinete
FROM HistoriaClinica
WHERE Paciente = @Paciente
ORDER BY FechaRegistro DESC";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 📅 Mostrar fecha
                            DateTime fecha = reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                            resultado += "#####################################\n";
                            resultado += "         FECHA: " + fecha.ToString("dd/MM/yyyy") + "\n";
                            resultado += "#####################################\n\n";

                            // ✅ EXÁMENES DE LABORATORIO
                            string examenesLab = reader["ExamenesLaboratorios"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(examenesLab))
                            {
                                resultado += "------ EXÁMENES DE LABORATORIO ------\n";
                                string[] listaLab = examenesLab.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var examen in listaLab)
                                {
                                    string limpio = examen.TrimStart('•', ' ', '\t');
                                    resultado += "• " + limpio.Trim() + Environment.NewLine;
                                }
                                resultado += Environment.NewLine;
                            }

                            // ✅ EXÁMENES DE GABINETE
                            string examenesGab = reader["ExamenesGabinete"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(examenesGab))
                            {
                                resultado += "-------- EXÁMENES DE GABINETE --------\n";
                                string[] listaGab = examenesGab.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var examen in listaGab)
                                {
                                    string limpio = examen.TrimStart('•', ' ', '\t');
                                    resultado += "• " + limpio.Trim() + Environment.NewLine;
                                }
                                resultado += Environment.NewLine;
                            }

                            resultado += Environment.NewLine;
                        }
                    }
                }
            }

            return resultado;
        }




        private void CargarNombrePaciente()
        {
            string connectionString = "Server=localhost;Database=ClinicaVargas;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Nombre FROM Pacientes WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", pacienteId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtPaciente.Text = reader["Nombre"].ToString(); // Asegúrate que el TextBox se llame txtPaciente
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HistoriaClinica_Load(object sender, EventArgs e)
        {
            txtMasaCorporal.ReadOnly = true;
            txtPlan.Text = "1. ";
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
            // Validación
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show("El campo 'Paciente' no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
INSERT INTO HistoriaClinica(
    Paciente, ConsultaPor, PresenteEnfermedad, AntecedentesPersonales, PresionArterial,
    FrecuenciaCardiaca, FrecuenciaRespiratoria, SaturacionOxigeno, Peso, Talla,
    IndiceMasaCorporal, ClasificacionIMC, ExamenFisico, ExamenesLaboratorios,
    ExamenesGabinete, Impresion, [Plan], FechaHoraRegistro
) VALUES(
    @Paciente, @ConsultaPor, @PresenteEnfermedad, @AntecedentesPersonales, @PresionArterial,
    @FrecuenciaCardiaca, @FrecuenciaRespiratoria, @SaturacionOxigeno, @Peso, @Talla,
    @IndiceMasaCorporal, @ClasificacionIMC, @ExamenFisico, @ExamenesLaboratorios,
    @ExamenesGabinete, @Impresion, @Plan, @FechaHoraRegistro
);";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Parámetros
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

                        string clasificacionIMC = lblClasificacionIMC.Text;
                        if (clasificacionIMC.Length > 50)
                        {
                            clasificacionIMC = clasificacionIMC.Substring(0, 50);
                        }
                        cmd.Parameters.AddWithValue("@ClasificacionIMC", clasificacionIMC);

                        cmd.Parameters.AddWithValue("@ExamenFisico", txtExamenFisico.Text);
                        cmd.Parameters.AddWithValue("@ExamenesLaboratorios", txtExamenesLaboratorio.Text);
                        cmd.Parameters.AddWithValue("@ExamenesGabinete", txtExamenesGabinete.Text);
                        cmd.Parameters.AddWithValue("@Impresion", rtbImpresionDiagnostica.Text);
                        cmd.Parameters.AddWithValue("@Plan", txtPlan.Text);
                        cmd.Parameters.AddWithValue("@FechaHoraRegistro", DateTime.Now);

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

                            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                            string fileName = $"HistoriaClinica_{txtPaciente.Text.Trim()}_{timestamp}.docx";
                            string docPath = Path.Combine(pacienteFolder, fileName);

                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(docPath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                            {
                                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                                mainPart.Document = new WordDocument();
                                WordBody body = new WordBody();

                                void AddLabeledParagraph(string label, string value)
                                {
                                    var labelPara = new WordParagraph(
                                        new WordRun(
                                            new WordRunProperties(new WordBold()),
                                            new WordText() { Text = label, Space = SpaceProcessingModeValues.Preserve }
                                        )
                                    );
                                    labelPara.ParagraphProperties = new ParagraphProperties(
                                        new SpacingBetweenLines() { After = "0" },
                                        new Justification() { Val = JustificationValues.Both }
                                    );
                                    body.Append(labelPara);

                                    string[] lines = value.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                                    foreach (string line in lines)
                                    {
                                        var valuePara = new WordParagraph(
                                            new WordRun(
                                                new WordText() { Text = line, Space = SpaceProcessingModeValues.Preserve }
                                            )
                                        );
                                        valuePara.ParagraphProperties = new ParagraphProperties(
                                            new SpacingBetweenLines() { After = "100" },
                                            new Justification() { Val = JustificationValues.Both }
                                        );
                                        body.Append(valuePara);
                                    }
                                }

                                void AddTitle(string text, int fontSize = 32)
                                {
                                    WordRunProperties props = new WordRunProperties(new WordBold(), new WordFontSize() { Val = fontSize.ToString() });
                                    WordParagraph para = new WordParagraph(new WordRun(props, new WordText(text)));
                                    body.Append(para);
                                }

                                // Contenido del documento Word
                                AddTitle("HISTORIA CLÍNICA");

                                AddLabeledParagraph("Paciente:", txtPaciente.Text);
                                AddLabeledParagraph("Consulta por:", txtConsultaPor.Text);
                                AddLabeledParagraph("Fecha y Hora:", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                                AddLabeledParagraph("Presente Enfermedad:", txtPresenteEnfermedad.Text);
                                AddLabeledParagraph("Antecedentes Personales:", txtAntecedentesPersonales.Text);

                                AddLabeledParagraph("Presión Arterial:", txtPresion.Text);
                                AddLabeledParagraph("Frecuencia Cardiaca:", txtFC.Text);
                                AddLabeledParagraph("Frecuencia Respiratoria:", txtFR.Text);
                                AddLabeledParagraph("Saturación Oxígeno:", txtSaturacion.Text);
                                AddLabeledParagraph("Peso:", txtPeso.Text);
                                AddLabeledParagraph("Talla:", txtTalla.Text);
                                AddLabeledParagraph("IMC:", txtMasaCorporal.Text);
                                AddLabeledParagraph("Clasificación IMC:", lblClasificacionIMC.Text);

                                AddLabeledParagraph("Examen Físico:", txtExamenFisico.Text);
                                AddLabeledParagraph("Exámenes de Laboratorios:", txtExamenesLaboratorio.Text);
                                AddLabeledParagraph("Exámenes de Gabinete:", txtExamenesGabinete.Text);
                                AddLabeledParagraph("Impresión Diagnóstica:", rtbImpresionDiagnostica.Text);
                                AddLabeledParagraph("Plan:", txtPlan.Text);

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
                rtbImpresionDiagnostica.Clear();
                txtExamenesLaboratorio.Clear();
                txtPlan.Clear();
                txtAntecedentesPersonales.Clear();
                txtExamenFisico.Clear();
            }
        }



        public string LeerAntecedentesPaciente(string ruta)
        {
            try
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(ruta, false))
                {
                    var body = doc.MainDocumentPart.Document.Body;
                    var paragraphs = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().ToList();

                    bool dentroDeAntecedentes = false;
                    StringBuilder resultado = new StringBuilder();

                    foreach (var p in paragraphs)
                    {
                        string texto = p.InnerText.Trim();

                        if (!dentroDeAntecedentes)
                        {
                            if (texto.Equals("Antecedentes Personales:", StringComparison.OrdinalIgnoreCase))
                            {
                                dentroDeAntecedentes = true;
                                continue;
                            }
                        }
                        else
                        {
                            if (texto.EndsWith(":") && texto.Length < 50)
                                break;

                            if (!string.IsNullOrWhiteSpace(texto))
                                resultado.AppendLine(texto);
                        }
                    }

                    return resultado.ToString().Trim();
                }
            }
            catch
            {
                return "";
            }
        }

        private void CalcularIMC()
        {
            if (double.TryParse(txtPeso.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double peso) &&
         double.TryParse(txtTalla.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double tallaEnMetros) && tallaEnMetros > 0)
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
                bool modoImpresion = true; // true = fondo blanco para imprimir, false = fondo de color para pantalla
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(rutaPDF, FileMode.Create));
                if (modoImpresion)
                {
                    writer.PageEvent = new FondoPaginaBlanco();
                }
                else
                {
                    writer.PageEvent = new FondoPaginaCompleto(System.Drawing.SystemColors.ActiveCaption);
                }
                pdfDoc.Open();

                // ============================== ENCABEZADO ==============================
                string rutaLogo = @"C:\Users\User\OneDrive\Documentos\imagenes\logoredondo.png"; // Ruta real del logo
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(80f, 80f); // Tamaño del logo
                    logo.SetAbsolutePosition(40f, pdfDoc.PageSize.Height - 100f); // Arriba izquierda
                    pdfDoc.Add(logo);
                }

                var fuenteTituloClinica = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fuenteDatosClinica = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                // Espacio debajo del logo
                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                // Nombre clínica centrado
                iTextSharp.text.Paragraph nombreClinica = new iTextSharp.text.Paragraph("CLÍNICA DE EMERGENCIAS MEDICAS VARGAS", fuenteTituloClinica)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 4f
                };
                pdfDoc.Add(nombreClinica);

                // Nombre doctor
                iTextSharp.text.Paragraph nombreDoctor = new iTextSharp.text.Paragraph("Dr. Atilio Vargas Trejo No. Inscripcion: 1763.", fuenteDatosClinica)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                pdfDoc.Add(nombreDoctor);


                // Dirección
                iTextSharp.text.Paragraph direccionClinica = new iTextSharp.text.Paragraph("16ª. Avenida Norte #12 Bis.Laboratorio Clínico “Vargas” Col.Soriano Usulután Este.", fuenteDatosClinica)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 15f
                };

                pdfDoc.Add(direccionClinica);
                // ========================== LÍNEA DESPUÉS DEL ENCABEZADO ==========================
                PdfContentByte cb = writer.DirectContent;
                cb.SetLineWidth(1f);

                float margenIzquierdo = 40f;
                float margenDerecho = pdfDoc.PageSize.Width - 40f;
                float posicionY = pdfDoc.PageSize.Height - 150f; // Ajusta si necesitas moverla más arriba o abajo

                cb.MoveTo(margenIzquierdo, posicionY);
                cb.LineTo(margenDerecho, posicionY);
                cb.Stroke();
                // ==================================================================================
                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                // Agregar imagen sello arriba a la derecha
                string rutaImagenSello = Path.Combine(Application.StartupPath, "imagenes", "selloimprimir.png");
                if (File.Exists(rutaImagenSello))
                {
                    iTextSharp.text.Image sello = iTextSharp.text.Image.GetInstance(rutaImagenSello);
                    sello.ScaleAbsolute(120f, 90f);
                    sello.SetAbsolutePosition(pdfDoc.PageSize.Width - sello.ScaledWidth - 40f, pdfDoc.PageSize.Height - sello.ScaledHeight - 40f);
                    pdfDoc.Add(sello);
                }

                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK);
                var fuenteCampo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                void AddCampoValor(string campo, string valor)
                {
                    iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph();
                    p.SpacingAfter = 10f;
                    p.Alignment = Element.ALIGN_JUSTIFIED;

                    // Usamos dos frases separadas para mantener estilos
                    Phrase frase = new Phrase();
                    frase.Add(new Chunk(campo + ":\n", fuenteCampo));
                    frase.Add(new Chunk(valor, fuenteTexto));

                    p.Add(frase);
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

                string nombrePaciente = txtPaciente.Text.Trim();
                string cs = "Server=localhost;Database=ClinicaVargas;Integrated Security=True;";
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

                AddTitulo("HISTORIA CLÍNICA");
                AddCampoValor("Paciente", nombrePaciente);
                AddCampoValor("Consulta por", txtConsultaPor.Text);
                AddCampoValor("Edad", edad + " años");
                AddCampoValor("Fecha de Nacimiento", fechaNacimiento.ToShortDateString());
                AddCampoValor("Teléfono", telefono);
                AddCampoValor("Dirección", direccion);
                AddCampoValor("DUI", dui);
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
                AddCampoValor("Impresión Diagnóstica", rtbImpresionDiagnostica.Text);
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
                rtbImpresionDiagnostica.Clear();
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
        // Conformacion de el calculo de el IMC
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
        //VERDADERO GUARDAR______________________________________________________
        private void Guardar_Click(object sender, EventArgs e)
        {
            CalcularIMC();
            // Validación
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show("El campo 'Paciente' no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
INSERT INTO HistoriaClinica(
    Paciente, ConsultaPor, PresenteEnfermedad, AntecedentesPersonales, PresionArterial,
    FrecuenciaCardiaca, FrecuenciaRespiratoria, SaturacionOxigeno, Peso, Talla,
    IndiceMasaCorporal, ClasificacionIMC, ExamenFisico, ExamenesLaboratorios,
    ExamenesGabinete, Impresion, [Plan], FechaHoraRegistro
) VALUES(
    @Paciente, @ConsultaPor, @PresenteEnfermedad, @AntecedentesPersonales, @PresionArterial,
    @FrecuenciaCardiaca, @FrecuenciaRespiratoria, @SaturacionOxigeno, @Peso, @Talla,
    @IndiceMasaCorporal, @ClasificacionIMC, @ExamenFisico, @ExamenesLaboratorios,
    @ExamenesGabinete, @Impresion, @Plan, @FechaHoraRegistro
);";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Parámetros
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

                        string clasificacionIMC = lblClasificacionIMC.Text;
                        if (clasificacionIMC.Length > 50)
                        {
                            clasificacionIMC = clasificacionIMC.Substring(0, 50);
                        }
                        cmd.Parameters.AddWithValue("@ClasificacionIMC", clasificacionIMC);

                        cmd.Parameters.AddWithValue("@ExamenFisico", txtExamenFisico.Text);
                        cmd.Parameters.AddWithValue("@ExamenesLaboratorios", txtExamenesLaboratorio.Text);
                        cmd.Parameters.AddWithValue("@ExamenesGabinete", txtExamenesGabinete.Text);
                        cmd.Parameters.AddWithValue("@Impresion", rtbImpresionDiagnostica.Text);
                        cmd.Parameters.AddWithValue("@Plan", txtPlan.Text);
                        cmd.Parameters.AddWithValue("@FechaHoraRegistro", DateTime.Now);

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

                            string timestamp = DateTime.Now.ToString("yyyy-MM-dd - hh-mm-ss tt", CultureInfo.InvariantCulture);
                            string fileName = $"HistoriaClinica_{txtPaciente.Text.Trim()}_{timestamp}.docx";
                            string docPath = Path.Combine(pacienteFolder, fileName);

                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(docPath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                            {
                                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                                mainPart.Document = new WordDocument();
                                WordBody body = new WordBody();

                                void AddLabeledParagraph(string label, string value)
                                {
                                    var labelPara = new WordParagraph(
                                        new WordRun(
                                            new WordRunProperties(new WordBold()),
                                            new WordText() { Text = label, Space = SpaceProcessingModeValues.Preserve }
                                        )
                                    );
                                    labelPara.ParagraphProperties = new ParagraphProperties(
                                        new SpacingBetweenLines() { After = "0" },
                                        new Justification() { Val = JustificationValues.Both }
                                    );
                                    body.Append(labelPara);

                                    string[] lines = value.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                                    foreach (string line in lines)
                                    {
                                        var valuePara = new WordParagraph(
                                            new WordRun(
                                                new WordText() { Text = line, Space = SpaceProcessingModeValues.Preserve }
                                            )
                                        );
                                        valuePara.ParagraphProperties = new ParagraphProperties(
                                            new SpacingBetweenLines() { After = "100" },
                                            new Justification() { Val = JustificationValues.Both }
                                        );
                                        body.Append(valuePara);
                                    }
                                }

                                void AddTitle(string text, int fontSize = 32)
                                {
                                    WordRunProperties props = new WordRunProperties(new WordBold(), new WordFontSize() { Val = fontSize.ToString() });
                                    WordParagraph para = new WordParagraph(new WordRun(props, new WordText(text)));
                                    body.Append(para);
                                }

                                // Contenido del documento Word
                                AddTitle("HISTORIA CLÍNICA");

                                AddLabeledParagraph("Paciente:", txtPaciente.Text);
                                AddLabeledParagraph("Consulta por:", txtConsultaPor.Text);
                                AddLabeledParagraph("Fecha y Hora:", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                                AddLabeledParagraph("Presente Enfermedad:", txtPresenteEnfermedad.Text);
                                AddLabeledParagraph("Antecedentes Personales:", txtAntecedentesPersonales.Text);

                                AddLabeledParagraph("Presión Arterial:", txtPresion.Text);
                                AddLabeledParagraph("Frecuencia Cardiaca:", txtFC.Text);
                                AddLabeledParagraph("Frecuencia Respiratoria:", txtFR.Text);
                                AddLabeledParagraph("Saturación Oxígeno:", txtSaturacion.Text);
                                AddLabeledParagraph("Peso:", txtPeso.Text);
                                AddLabeledParagraph("Talla:", txtTalla.Text);
                                AddLabeledParagraph("IMC:", txtMasaCorporal.Text);
                                AddLabeledParagraph("Clasificación IMC:", lblClasificacionIMC.Text);

                                AddLabeledParagraph("Examen Físico:", txtExamenFisico.Text);
                                AddLabeledParagraph("Exámenes de Laboratorios:", txtExamenesLaboratorio.Text);
                                AddLabeledParagraph("Exámenes de Gabinete:", txtExamenesGabinete.Text);
                                AddLabeledParagraph("Impresión Diagnóstica:", rtbImpresionDiagnostica.Text);
                                AddLabeledParagraph("Plan:", txtPlan.Text);

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
            rtbImpresionDiagnostica.Clear();
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

        private string ObtenerRutaUltimoArchivo(string nombrePaciente)
        {
            string nombreLimpio = LimpiarNombreArchivo(nombrePaciente);

            string carpetaPaciente = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Pacientes",
                nombreLimpio
            );

            if (!Directory.Exists(carpetaPaciente))
            {
                MessageBox.Show($"La carpeta no existe:\n{carpetaPaciente}", "Error");
                return null;
            }

            // Buscar todos los .docx de la carpeta
            var todosLosArchivos = Directory.GetFiles(carpetaPaciente, "*.docx");

            // Filtrar los que tengan el nombre del paciente en cualquier parte del nombre
            var archivosFiltrados = todosLosArchivos
                .Where(f => Path.GetFileName(f).ToUpper().Contains($"HISTORIACLINICA_{nombrePaciente.ToUpper()}"))
                .ToList();

            if (archivosFiltrados.Count == 0)
            {
                MessageBox.Show($"No se encontraron archivos que contengan:\nHISTORIACLINICA_{nombrePaciente.ToUpper()}\n\nEn carpeta:\n{carpetaPaciente}", "Aviso");
                return null;
            }

            // Retornar el más reciente
            return archivosFiltrados.OrderByDescending(f => File.GetLastWriteTime(f)).First();
        }




        private string LimpiarNombreArchivo(string nombre)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                nombre = nombre.Replace(c.ToString(), "");
            }
            return nombre.Trim();
        }


        private void txtPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string nombrePaciente = txtPaciente.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombrePaciente) || nombrePaciente.Length < 3)
                {
                    txtAntecedentesPersonales.Clear();
                    return;
                }

                string ruta = ObtenerRutaUltimoArchivo(nombrePaciente);

                if (!string.IsNullOrEmpty(ruta) && File.Exists(ruta))
                {
                    string antecedentes = LeerAntecedentesPaciente(ruta);
                    txtAntecedentesPersonales.Text = antecedentes;
                }
                else
                {
                    // ✅ Depuración: mostrar la ruta que intentó buscar
                    string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Pacientes", LimpiarNombreArchivo(nombrePaciente));
                    string[] archivos = Directory.Exists(carpeta)
                        ? Directory.GetFiles(carpeta)
                        : new string[0];

                    string mensaje = $"No se encontró el archivo para el paciente: {nombrePaciente}\n\n";
                    mensaje += $"Carpeta buscada: {carpeta}\n";
                    mensaje += archivos.Length == 0
                        ? "No hay archivos en esa carpeta."
                        : $"Archivos encontrados:\n{string.Join("\n", archivos)}";

                    MessageBox.Show(mensaje, "Depuración");
                    txtAntecedentesPersonales.Clear();
                }
            }
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

        private void txtPlan_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPlan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se agregue una nueva línea automática

                int totalLines = txtPlan.Lines.Length;
                txtPlan.AppendText(Environment.NewLine + (totalLines + 1).ToString() + ". ");
            }
        }




        public class FondoPaginaBlanco : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
            {
                var content = writer.DirectContentUnder;
                content.SaveState();
                content.SetColorFill(iTextSharp.text.BaseColor.WHITE);
                content.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);
                content.Fill();
                content.RestoreState();
            }
        }

        private void rtbImpresionDiagnostica_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbImpresionDiagnostica_Enter(object sender, EventArgs e)
        {
            rtbImpresionDiagnostica.SelectionBullet = true;
        }

        private void rtbImpresionDiagnostica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtbImpresionDiagnostica.SelectionBullet = true;
            }
        }
    }
}


    




