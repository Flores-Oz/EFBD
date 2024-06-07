using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(1) FROM usuario WHERE usuario=@usuario AND password=@password";

            using (SqlConnection connection = new SqlConnection(Conexion.conexion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", textBoxUser.Text);
                command.Parameters.AddWithValue("@password", textBoxPass.Text);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        // Usuario y contraseña correctos
                        MessageBox.Show("Login exitoso!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        // Aquí puedes abrir el siguiente formulario o realizar otras acciones
                    }
                    else
                    {
                        // Usuario o contraseña incorrectos
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }
    }
}
