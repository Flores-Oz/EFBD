using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(1) FROM usuario WHERE usuario=@usuario AND password=@password";

            using (SqlConnection connection = new SqlConnection(Conexion.conexion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", TextBoxUser.Text);
                command.Parameters.AddWithValue("@password", TextBoxPassword.Text);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        // Usuario y contraseña correctos
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bienvenido');", true);
                        Session.Add("Nombre: ", TextBoxUser.Text);
                        Response.Redirect("Agregar.aspx");
                        // Aquí puedes abrir el siguiente formulario o realizar otras acciones
                    }
                    else
                    {
                        // Usuario o contraseña incorrectos
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Credenciales Incorrectas');", true);

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}