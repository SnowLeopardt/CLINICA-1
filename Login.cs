using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CLINICA_1
{
    public partial class Login : Form
    {
        //cadena de conexion de sql
        private string connectionString = "Server=LAPTOP-M35CB1FF;Database=ClinicaVargas;Integrated Security=True;";

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button1; // Cambia 'button1' por el nombre real de tu botón
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Puedes dejar este método vacío o eliminarlo si no lo necesitas
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit(); // Cierra toda la aplicación
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Rol, FechaCambioPassword FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", username);
                        command.Parameters.AddWithValue("@contrasena", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rol = reader["Rol"].ToString();
                                DateTime fechaCambio = reader["FechaCambioPassword"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FechaCambioPassword"]);
                                int diasDesdeCambio = (DateTime.Now - fechaCambio).Days;

                                if (diasDesdeCambio >= 60)
                                {
                                    lblDiasRestantes.Text = "Contraseña expirada.";
                                    MessageBox.Show($"Su contraseña ha expirado. Han pasado {diasDesdeCambio} días desde el último cambio.\nPor favor, cambie su contraseña.", "Contraseña Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    // Puedes abrir el formulario de cambio de contraseña aquí
                                    var cambiarForm = new CambiarContrasenaForm(username, connectionString);
                                    cambiarForm.ShowDialog();
                                    return;
                                }
                                else
                                {
                                    int diasRestantes = 60 - diasDesdeCambio;
                                    lblDiasRestantes.Text = $"Quedan {diasRestantes} día(s) antes de que expire su contraseña.";
                                }

                                MessageBox.Show("Inicio de sesión exitoso como " + rol + ".", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();

                                // Mostrar formulario correspondiente según el rol
                                if (rol == "Doctor")
                                {
                                    new Menu().Show();
                                }
                                else if (rol == "Enfermera")
                                {
                                    new Form1().Show();
                                }
                                else
                                {
                                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

