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
    public partial class Registro : Form
    {
        // Cadena de conexión a SQL Server
        private string connectionString = "Server=LAPTOP-M35CB1FF;Database=ClinicaVargas;Integrated Security=True;";

        public Registro()
        {
            InitializeComponent();
        }

        // Evento del botón NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
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

        // Evento del botón GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO Pacientes 
                    (Nombre, Edad, Telefono, Direccion, DUI, Responsable, TelResponsable, DirResponsable, CorreoResponsable) 
                    VALUES 
                    (@Nombre, @Edad, @Telefono, @Direccion, @DUI, @Responsable, @TelResponsable, @DirResponsable, @CorreoResponsable)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@Edad", int.Parse(txtEdad.Text));
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@DUI", txtdui.Text);
                    command.Parameters.AddWithValue("@Responsable", txtresponsable.Text);
                    command.Parameters.AddWithValue("@TelResponsable", txttelefono2.Text);
                    command.Parameters.AddWithValue("@DirResponsable", txtdireccion2.Text);
                    command.Parameters.AddWithValue("@CorreoResponsable", txtcorreo.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Datos guardados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //boton eliminar
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdui.Text))
            {
                MessageBox.Show("Por favor ingrese el número de DUI para eliminar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string query = "DELETE FROM Pacientes WHERE DUI = @DUI";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@DUI", txtdui.Text);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnNuevo.PerformClick(); // Limpia los campos
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún registro con ese DUI.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //boton de editar
        private void btnEditar_Click(object sender, EventArgs e)
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Verificar si el paciente con ese DUI existe
                    string verificarQuery = "SELECT COUNT(*) FROM Pacientes WHERE DUI = @DUI";
                    SqlCommand verificarCmd = new SqlCommand(verificarQuery, connection);
                    verificarCmd.Parameters.AddWithValue("@DUI", txtdui.Text);
                    int existe = (int)verificarCmd.ExecuteScalar();

                    if (existe == 0)
                    {
                        MessageBox.Show("No se encontró un paciente con ese DUI. No se puede editar.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Si existe, actualiza
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
                    command.Parameters.AddWithValue("@Edad", int.Parse(txtEdad.Text));
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
                        MessageBox.Show("Los datos del paciente fueron actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("La edad debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
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

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}