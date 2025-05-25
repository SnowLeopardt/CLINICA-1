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
                    string query = "SELECT Rol FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", username);
                        command.Parameters.AddWithValue("@contrasena", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string rol = result.ToString();

                            MessageBox.Show("Inicio de sesión exitoso como " + rol + ".", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();

                            // Mostrar el formulario correspondiente según el rol
                            if (rol == "Doctor")
                            {
                                var doctorForm = new Menu();
                                doctorForm.Show();
                            }
                            else if (rol == "Enfermera")
                            {
                                var enfermeraForm = new Form1();
                                enfermeraForm.Show();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
       

    }
}

