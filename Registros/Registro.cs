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
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;

namespace CLINICA_1
{
    public partial class Registro : Form
    {
        // Cadena de conexión a SQL Server  //Cambiar Conexion:
        private string connectionString = "Server=localhost;Database=ClinicaVargas;Integrated Security=True;";

        public static string NombrePacienteSeleccionado = "";
        public Registro()
        {
            InitializeComponent();

            Button botonAbrirCarpeta = new Button();
            botonAbrirCarpeta.Click += botonAbrirCarpeta_Click;

            this.Controls.Add(botonAbrirCarpeta);

            dateTimePickerNacimiento.ValueChanged += dateTimePickerNacimiento_ValueChanged;
        }


        //boton eliminar
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdui.Text) ||
     string.IsNullOrWhiteSpace(txtNombre.Text) ||
     string.IsNullOrWhiteSpace(txtEdad.Text) ||
     string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor complete todos los campos del formulario para eliminar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = @"DELETE FROM Pacientes 
                             WHERE DUI = @DUI AND 
                                   Nombre = @Nombre AND 
                                   Edad = @Edad AND 
                                   Direccion = @Direccion";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@DUI", txtdui.Text);
                        command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        command.Parameters.AddWithValue("@Edad", txtEdad.Text);
                        command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnNuevo.PerformClick(); // Limpia los campos
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún registro con los datos proporcionados.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }




        //boton de guardar

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query para insertar y obtener el ID recién insertado
                    string query = @"
            INSERT INTO Pacientes 
            (Nombre, Edad, Telefono, Direccion, DUI, Responsable, TelResponsable, DirResponsable, CorreoResponsable, FechaNacimiento, FechaHoraRegistro) 
            VALUES 
            (@Nombre, @Edad, @Telefono, @Direccion, @DUI, @Responsable, @TelResponsable, @DirResponsable, @CorreoResponsable, @FechaNacimiento, @FechaHoraRegistro);
            SELECT SCOPE_IDENTITY();"; // Obtener el último ID insertado

                    SqlCommand command = new SqlCommand(query, connection);

                    // Fecha de nacimiento y cálculo de edad
                    DateTime fechaNacimiento = dateTimePickerNacimiento.Value;
                    int edad = DateTime.Now.Year - fechaNacimiento.Year;
                    if (DateTime.Now.Date < fechaNacimiento.Date.AddYears(edad))
                        edad--;

                    DateTime fechaHoraRegistro = dateTimePicker1.Value;

                    // Asignar parámetros
                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@Edad", edad);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@DUI", txtdui.Text);
                    command.Parameters.AddWithValue("@Responsable", txtresponsable.Text);
                    command.Parameters.AddWithValue("@TelResponsable", txttelefono2.Text);
                    command.Parameters.AddWithValue("@DirResponsable", txtdireccion2.Text);
                    command.Parameters.AddWithValue("@CorreoResponsable", txtcorreo.Text);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento.Date);
                    command.Parameters.AddWithValue("@FechaHoraRegistro", fechaHoraRegistro);

                    // Ejecutar y obtener ID insertado
                    int idPaciente = Convert.ToInt32(command.ExecuteScalar());

                    // Crear carpeta del paciente
                    string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string carpetaBase = Path.Combine(carpetaDocumentos, "Pacientes");

                    if (!Directory.Exists(carpetaBase))
                        Directory.CreateDirectory(carpetaBase);

                    string nombrePaciente = txtNombre.Text.Trim();
                    foreach (char c in Path.GetInvalidFileNameChars())
                        nombrePaciente = nombrePaciente.Replace(c, '_');

                    string rutaPaciente = Path.Combine(carpetaBase, nombrePaciente);

                    if (!Directory.Exists(rutaPaciente))
                        Directory.CreateDirectory(rutaPaciente);

                    // Crear documento Word con los datos
                    string nombreArchivo = $"Datos Personales del Paciente - {DateTime.Now:yyyy-MM-dd - hh-mm-ss tt}.docx";
                    string rutaArchivoWord = Path.Combine(rutaPaciente, nombreArchivo);

                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(rutaArchivoWord, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        Body body = new Body();

                        void AddTexto(string texto)
                        {
                            body.Append(new Paragraph(new Run(new Text(texto))));
                        }

                        AddTexto("Datos del Paciente:");
                        AddTexto($"Nombre: {txtNombre.Text}");
                        AddTexto($"Edad: {edad} años");
                        AddTexto($"Fecha de Nacimiento: {fechaNacimiento:yyyy-MM-dd}");
                        AddTexto($"Teléfono: {txtTelefono.Text}");
                        AddTexto($"Dirección: {txtDireccion.Text}");
                        AddTexto($"DUI: {txtdui.Text}");
                        AddTexto($"Responsable: {txtresponsable.Text}");
                        AddTexto($"Teléfono Responsable: {txttelefono2.Text}");
                        AddTexto($"Dirección Responsable: {txtdireccion2.Text}");
                        AddTexto($"Correo Responsable: {txtcorreo.Text}");
                        AddTexto($"Fecha y Hora de Registro: {fechaHoraRegistro:yyyy-MM-dd hh:mm tt}");

                        mainPart.Document.Append(body);
                        mainPart.Document.Save();
                    }

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Datos guardados, carpeta creada y documento generado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir formulario Historia Clínica y pasar el ID del paciente
                    HistoriaClinica historiaForm = new HistoriaClinica(idPaciente);
                    historiaForm.Show();
                    this.Hide();

                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtdui.Clear();
            txtresponsable.Clear();
            txttelefono2.Clear();
            txtdireccion2.Clear();
            txtcorreo.Clear();

        }



        // Evento del botón NUEVO
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            // Limpia todos los campos del formulario
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtdui.Text = "";

            txtresponsable.Text = "";
            txttelefono2.Text = "";
            txtdireccion2.Text = "";
            txtcorreo.Text = "";

            txtNombre.Focus();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdui.Text))
            {
                MessageBox.Show("Debe buscar o ingresar un paciente con DUI válido antes de editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor complete los campos requeridos antes de editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Verificar si el paciente con ese DUI existe y obtener su nombre real
                    string obtenerNombreQuery = "SELECT Nombre FROM Pacientes WHERE DUI = @DUI";
                    SqlCommand obtenerNombreCmd = new SqlCommand(obtenerNombreQuery, connection);
                    obtenerNombreCmd.Parameters.AddWithValue("@DUI", txtdui.Text);
                    object resultado = obtenerNombreCmd.ExecuteScalar();

                    if (resultado == null)
                    {
                        MessageBox.Show("No se encontró un paciente con ese DUI. No se puede editar.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string nombrePacienteBD = resultado.ToString();

                    // Actualizar en base de datos
                    string updateQuery = @"
                UPDATE Pacientes SET
                    Nombre = @Nombre,
                    Edad = @Edad,
                    Telefono = @Telefono,
                    Direccion = @Direccion,
                    Responsable = @Responsable,
                    TelResponsable = @TelResponsable,
                    DirResponsable = @DirResponsable,
                    CorreoResponsable = @CorreoResponsable
                WHERE DUI = @DUI";

                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@Edad", edad);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Responsable", txtresponsable.Text);
                    command.Parameters.AddWithValue("@TelResponsable", txttelefono2.Text);
                    command.Parameters.AddWithValue("@DirResponsable", txtdireccion2.Text);
                    command.Parameters.AddWithValue("@CorreoResponsable", txtcorreo.Text);
                    command.Parameters.AddWithValue("@DUI", txtdui.Text);

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        // Crear ruta segura desde nombre real del paciente
                        string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string carpetaBase = Path.Combine(carpetaDocumentos, "Pacientes");

                        string nombreSeguro = nombrePacienteBD.Trim();
                        foreach (char c in Path.GetInvalidFileNameChars())
                            nombreSeguro = nombreSeguro.Replace(c, '_');

                        string rutaPaciente = Path.Combine(carpetaBase, nombreSeguro);
                        if (!Directory.Exists(rutaPaciente))
                            Directory.CreateDirectory(rutaPaciente);

                        string rutaArchivoWord = Path.Combine(rutaPaciente, "Datos Personales del Paciente.docx");

                        // Eliminar archivo anterior si existe
                        if (File.Exists(rutaArchivoWord))
                            File.Delete(rutaArchivoWord);

                        // Crear documento Word actualizado
                        DateTime fechaNacimiento = dateTimePickerNacimiento.Value;
                        DateTime fechaHoraRegistro = dateTimePicker1.Value;

                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(rutaArchivoWord, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                        {
                            MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                            mainPart.Document = new Document();
                            Body body = new Body();

                            void AddTexto(string texto)
                            {
                                body.Append(new Paragraph(new Run(new Text(texto))));
                            }

                            AddTexto("Datos del Paciente:");
                            AddTexto($"Nombre: {txtNombre.Text}");
                            AddTexto($"Edad: {edad} años");
                            AddTexto($"Fecha de Nacimiento: {fechaNacimiento:yyyy-MM-dd}");
                            AddTexto($"Teléfono: {txtTelefono.Text}");
                            AddTexto($"Dirección: {txtDireccion.Text}");
                            AddTexto($"DUI: {txtdui.Text}");
                            AddTexto($"Responsable: {txtresponsable.Text}");
                            AddTexto($"Teléfono Responsable: {txttelefono2.Text}");
                            AddTexto($"Dirección Responsable: {txtdireccion2.Text}");
                            AddTexto($"Correo Responsable: {txtcorreo.Text}");
                            AddTexto($"Fecha y Hora de Registro: {fechaHoraRegistro:yyyy-MM-dd hh:mm tt}");

                            mainPart.Document.Append(body);
                            mainPart.Document.Save();
                        }

                        MessageBox.Show("Datos actualizados correctamente en la base de datos y el documento Word ha sido reemplazado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string criterio = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nombre, DUI, teléfono o cualquier dato del paciente:", "Buscar paciente", "");

            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Debe ingresar algún dato para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT TOP 1 * FROM Pacientes
                WHERE 
                    Nombre LIKE @criterio OR
                    DUI LIKE @criterio OR
                    Telefono LIKE @criterio OR
                    Direccion LIKE @criterio OR
                    Responsable LIKE @criterio OR
                    TelResponsable LIKE @criterio OR
                    DirResponsable LIKE @criterio OR
                    CorreoResponsable LIKE @criterio";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@criterio", "%" + criterio + "%");

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtEdad.Text = reader["Edad"].ToString();
                        txtTelefono.Text = reader["Telefono"].ToString();
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtdui.Text = reader["DUI"].ToString();
                        txtresponsable.Text = reader["Responsable"].ToString();
                        txttelefono2.Text = reader["TelResponsable"].ToString();
                        txtdireccion2.Text = reader["DirResponsable"].ToString();
                        txtcorreo.Text = reader["CorreoResponsable"].ToString();

                        MessageBox.Show("Paciente encontrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún paciente con ese dato.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void botonAbrirCarpeta_Click(object sender, EventArgs e)
        {
            string ruta = @"C:\Users\User\OneDrive\Documentos\Pacientes"; // Cambia esta ruta si está en otro lugar

            if (Directory.Exists(ruta))
            {
                Process.Start("explorer", ruta);
            }
            else
            {
                MessageBox.Show("La carpeta 'Pacientes' no existe en la ruta:\n" + ruta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txttelefono2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaNacimiento = dateTimePickerNacimiento.Value;
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (DateTime.Now.Date < fechaNacimiento.Date.AddYears(edad))
                edad--;

            txtEdad.Text = edad.ToString();
        }

        //BOTON DE REGRESAR
        private void button1_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu(); // Crear una instancia del formulario Menu
            this.Hide();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            string input = txttelefono2.Text.Trim().Replace("-", "").Replace(" ", "");

            if (input.Length == 8 && long.TryParse(input, out _))
            {
                // Formato +503-XXXX-XXXX
                string formatted = $"+503-{input.Substring(0, 4)}-{input.Substring(4, 4)}";
                txttelefono2.Text = formatted;
            }
            else if (input.StartsWith("+503") && input.Length == 13)
            {
                // Ya está correctamente formateado
                txttelefono2.Text = input;
            }
            else
            {
                // No hacer nada, dejar el texto como está
            }
        }


        private void txttelefono2_Leave(object sender, EventArgs e)
        {
            string input = txttelefono2.Text.Trim().Replace("-", "").Replace(" ", "");

            if (input.Length == 8 && long.TryParse(input, out _))
            {
                // Formato +503-XXXX-XXXX
                string formatted = $"+503-{input.Substring(0, 4)}-{input.Substring(4, 4)}";
                txttelefono2.Text = formatted;
            }
            else if (input.StartsWith("+503") && input.Length == 13)
            {
                // Ya está correctamente formateado
                txttelefono2.Text = input;
            }
            else
            {
                // No hacer nada, dejar el texto como está
            }
        }
    }
}
