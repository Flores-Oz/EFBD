using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication
{
    public partial class Agregar : System.Web.UI.Page
    {
        public void Mostrar()
        {
            string consulta = "Select * From VistaPerson";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, Conexion.conexion);
            DataTable Alum = new DataTable();
            adapter.Fill(Alum);
            GridView2.DataSource = Alum;
            GridView2.DataBind();
        }
        static string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=<>?";

            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(validChars[random.Next(validChars.Length)]);
            }

            return result.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar();
                //Departamento y Municipio
                string consulta = "Select id_departamento as Codigo, nombre_departamento as Departamento From departamento";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, Conexion.conexion);
                DataTable depa = new DataTable();
                adapter.Fill(depa);
                DropDownListDepa.DataSource = depa;
                DropDownListDepa.DataValueField = "Codigo";
                DropDownListDepa.DataTextField = "Departamento";
                DropDownListDepa.DataBind();
            }
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            Mostrar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" &&
               TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "")
            {
                string comando = "EXEC CRUDPerson @ID,@CampoDos,@CampoTres,@CampoCuatro,@CampoCinco,@CampoSeis,@CampoSiete,@municipio,@Fecha,@select";
                SqlConnection conect = new SqlConnection(Conexion.conexion);
                SqlCommand instruccion = new SqlCommand(comando, conect);
                instruccion.Parameters.AddWithValue("@ID", Convert.ToInt32(TextBox1.Text));
                instruccion.Parameters.AddWithValue("@CampoDos", TextBox2.Text);
                instruccion.Parameters.AddWithValue("@CampoTres", TextBox3.Text);
                instruccion.Parameters.AddWithValue("@CampoCuatro", TextBox4.Text);
                instruccion.Parameters.AddWithValue("@CampoCinco", TextBox5.Text);
                instruccion.Parameters.AddWithValue("@CampoSeis", TextBox6.Text);
                instruccion.Parameters.AddWithValue("@CampoSiete", TextBox7.Text);
                instruccion.Parameters.AddWithValue("@municipio", Convert.ToInt32(DropDownListMuni.SelectedIndex));
                instruccion.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(TextBoxFecga.Text));
                instruccion.Parameters.AddWithValue("@select", "insertar");
                try
                {
                    conect.Open();
                    instruccion.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conect.Close();
                    /////
                    string password = GenerateRandomPassword(10);
                    comando = "EXEC CreateUser @usuario, @password, @id_persona";
                    SqlConnection conecto = new SqlConnection(Conexion.conexion);
                    SqlCommand instru = new SqlCommand(comando, conecto);
                    instru.Parameters.AddWithValue("@usuario", TextBox2.Text);
                    instru.Parameters.AddWithValue("@password", password);
                    instru.Parameters.AddWithValue("@id_persona", Convert.ToInt32(TextBox1.Text));
                    try
                    {
                        conecto.Open();
                        instru.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {
                        conecto.Close();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registro Guardado con Éxito');", true);
                    Mostrar();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hay Campos Vacios');", true);

            }
        }


        protected void DropDownListDepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codDepa = Convert.ToInt32(DropDownListDepa.SelectedValue);
                string consulta2 = "SELECT id_municipio AS Codigo, nombre_municipio AS Municipio FROM municipio WHERE id_departamento = " + codDepa;
                SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, Conexion.conexion);
                DataTable muni = new DataTable();
                adapter2.Fill(muni);
                DropDownListMuni.DataSource = muni;
                DropDownListMuni.DataValueField = "Codigo";
                DropDownListMuni.DataTextField = "Municipio";
                DropDownListMuni.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}