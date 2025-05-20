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
        }

        //boton de referencia
        private void button1_Click(object sender, EventArgs e) // Evento del botón de inicio de sesión
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
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", username);
                        command.Parameters.AddWithValue("@contrasena", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            // MessageBox de éxito opcional antes de cambiar de formulario
                            MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            var MenuForm = new Menu();
                            MenuForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Puedes dejar este método vacío o eliminarlo si no lo necesitas
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

// REALIZAR AUTENTICACION DE DOS VISTAS ENFERMERA Y EL DOCTOR