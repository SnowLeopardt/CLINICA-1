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
    public partial class CambiarContrasena : Form
    {
        private string _usuario;
        private string _connectionString;

        public CambiarContrasena(string usuario, string connectionString)
        {
            InitializeComponent();
            _usuario = usuario;
            _connectionString = connectionString;
            txtUsuario.Text = usuario;
            txtUsuario.ReadOnly = true;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CambiarContrasena_Load(object sender, EventArgs e)
        {

        }
       
        //CAMBIAR CONTRASEÑA
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string actual = txtActual.Text.Trim();
            string nueva = txtNueva.Text.Trim();
            string confirmar = txtConfirmar.Text.Trim();

            if (string.IsNullOrEmpty(actual) || string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Verifica la contraseña actual
                    string verificarQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @actual";
                    using (SqlCommand verificarCmd = new SqlCommand(verificarQuery, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@usuario", _usuario);
                        verificarCmd.Parameters.AddWithValue("@actual", actual);

                        int count = (int)verificarCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Actualiza la contraseña y la fecha de cambio
                    string updateQuery = "UPDATE Usuarios SET Contrasena = @nueva, FechaCambioPassword = @fecha WHERE Usuario = @usuario";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@nueva", nueva);
                        updateCmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                        updateCmd.Parameters.AddWithValue("@usuario", _usuario);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    
