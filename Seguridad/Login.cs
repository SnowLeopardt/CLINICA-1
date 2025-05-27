using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace CLINICA_1
{
    public partial class Login : Form
    {
        //cadena de conexion de sql
        private string connectionString = "Server=localhost;Database=ClinicaVargas;Integrated Security=True;";

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
        // BOTON DE INICIAR SESION
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
                                    lblRestantes1.ForeColor = Color.Red;
                                    lblRestantes1.Text = "Contraseña expirada.";

                                    MessageBox.Show($"Su contraseña ha expirado. Han pasado {diasDesdeCambio} días desde el último cambio.\nDebe cambiar su contraseña para continuar.",
                                        "Contraseña Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    // Abrir formulario de cambio de contraseña
                                    var cambiarForm = new CambiarContrasena(username, connectionString);
                                    cambiarForm.ShowDialog();

                                    // Detener el inicio de sesión hasta que cambie la contraseña
                                    return;
                                }
                                else
                                {
                                    int diasRestantes = 60 - diasDesdeCambio;
                                    lblRestantes1.ForeColor = Color.Black;
                                    lblRestantes1.Text = $"Quedan {diasRestantes} día(s) antes de que expire su contraseña.";
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

        //MUESTRA DE DATOS
        private void txtusername_TextChanged_1(object sender, EventArgs e)
        {
            MostrarDiasRestantes(txtusername.Text.Trim());
        }
        private void MostrarDiasRestantes(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                lblRestantes1.Text = "";
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT FechaCambioPassword FROM Usuarios WHERE Usuario = @usuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", username);

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            DateTime fechaCambio = Convert.ToDateTime(result);
                            int diasDesdeCambio = (DateTime.Now - fechaCambio).Days;

                            if (diasDesdeCambio >= 60)
                            {
                                lblRestantes1.ForeColor = Color.Red;
                                lblRestantes1.Text = "Contraseña expirada.";
                            }
                            else
                            {
                                int diasRestantes = 60 - diasDesdeCambio;
                                lblRestantes1.ForeColor = Color.Black;
                                lblRestantes1.Text = $"Quedan {diasRestantes} día(s) antes de que expire su contraseña.";
                            }
                        }
                        else
                        {
                            lblRestantes1.ForeColor = Color.Gray;
                            lblRestantes1.Text = "Sin registro de contraseña.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblRestantes1.ForeColor = Color.Red;
                lblRestantes1.Text = "Error al verificar contraseña.";
                Console.WriteLine("Error: " + ex.Message);
            }
        }


       //CONTROL MANUAL DE BOTON DE CAMBIO DE CONTRASEÑA
        private void button3_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Por favor ingrese el nombre de usuario para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el formulario de cambio de contraseña con los parámetros correctos
            CambiarContrasena form2 = new CambiarContrasena(username, connectionString);
            form2.ShowDialog(); // Mostrar el formulario de forma modal (recomendado)
        }
    }
    }