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
using System.Windows.Input;

namespace WindowApplication
{
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
        }

        public void MostrarPerson()
        {
            string consulta = "Select * From VistaPerson";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, Conexion.conexion);
            DataTable persona = new DataTable();
            adapter.Fill(persona);
            dataGridView1.DataSource = persona;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Ingreso_Load(object sender, EventArgs e)
        {
            //Departamento y Municipio
            string consulta = "Select id_departamento as Codigo, nombre_departamento as Departamento From departamento";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, Conexion.conexion);
            DataTable depa = new DataTable();
            adapter.Fill(depa);
            comboBoxDepa.DataSource = depa;
            comboBoxDepa.DisplayMember = "Departamento";
            comboBoxDepa.ValueMember = "Codigo";
            //Persona
            consulta = "Select * From VistaPerson";
            adapter = new SqlDataAdapter(consulta, Conexion.conexion);
            DataTable persona = new DataTable();
            adapter.Fill(persona);
            dataGridView1.DataSource = persona;
        }

        private void comboBoxDepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codDepa = Convert.ToInt32(comboBoxDepa.SelectedValue);
                string consulta2 = "SELECT id_municipio AS Codigo, nombre_municipio AS Municipio FROM municipio WHERE id_departamento = " + codDepa;
                SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, Conexion.conexion);
                DataTable muni = new DataTable();
                adapter2.Fill(muni);
                comboBoxMuni.DataSource = muni;
                comboBoxMuni.DisplayMember = "Municipio";
                comboBoxMuni.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                string comando = "EXEC CRUDPerson @ID,@CampoDos,@CampoTres,@CampoCuatro,@CampoCinco,@CampoSeis,@CampoSiete,@municipio,@Fecha,@select";
                SqlConnection conect = new SqlConnection(Conexion.conexion);
                SqlCommand instruccion = new SqlCommand(comando,conect);
                instruccion.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                instruccion.Parameters.AddWithValue("@CampoDos", textBox2.Text);
                instruccion.Parameters.AddWithValue("@CampoTres", textBox3.Text);
                instruccion.Parameters.AddWithValue("@CampoCuatro", textBox4.Text);
                instruccion.Parameters.AddWithValue("@CampoCinco", textBox5.Text);
                instruccion.Parameters.AddWithValue("@CampoSeis", textBox6.Text);
                instruccion.Parameters.AddWithValue("@CampoSiete", textBox7.Text);
                instruccion.Parameters.AddWithValue("@municipio", Convert.ToInt32(comboBoxMuni.SelectedIndex));
                instruccion.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                instruccion.Parameters.AddWithValue("@select", "insertar");
                try
                {
                    conect.Open();
                    instruccion.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 50000) // El código de error personalizado de RAISERROR
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    else
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
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
                    instru.Parameters.AddWithValue("@usuario", textBox2.Text);
                    instru.Parameters.AddWithValue("@password", password);
                    instru.Parameters.AddWithValue("@id_persona", Convert.ToInt32(textBox1.Text));
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
                    MessageBox.Show("Registro Guardado con Exito");
                }
                MostrarPerson();
            }
            else
            {
                MessageBox.Show("Hay Campos Vacios");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string comando = "EXEC CRUDPerson @ID,@CampoDos,@CampoTres,@CampoCuatro,@CampoCinco,@CampoSeis,@CampoSiete,@municipio,@Fecha,@select";
            SqlConnection conect = new SqlConnection(Conexion.conexion);
            SqlCommand instruccion = new SqlCommand(comando, conect);
            instruccion.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
            instruccion.Parameters.AddWithValue("@CampoDos", textBox2.Text);
            instruccion.Parameters.AddWithValue("@CampoTres", textBox3.Text);
            instruccion.Parameters.AddWithValue("@CampoCuatro", textBox4.Text);
            instruccion.Parameters.AddWithValue("@CampoCinco", textBox5.Text);
            instruccion.Parameters.AddWithValue("@CampoSeis", textBox6.Text);
            instruccion.Parameters.AddWithValue("@CampoSiete", textBox7.Text);
            instruccion.Parameters.AddWithValue("@municipio", Convert.ToInt32(comboBoxMuni.SelectedIndex));
            instruccion.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            instruccion.Parameters.AddWithValue("@select", "actualizar");
            try
            {
                conect.Open();
                instruccion.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // El código de error personalizado de RAISERROR
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                else
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conect.Close(); 
            }
            MessageBox.Show("Registro Actualizado con Exito");
            MostrarPerson();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string consulta = "EXEC VistaID " + textBox1.Text;
            SqlDataAdapter adapter2 = new SqlDataAdapter(consulta, Conexion.conexion);
            DataTable mon = new DataTable();
            adapter2.Fill(mon);
            foreach (DataRow fila in mon.Rows)
            {
                textBox2.Text = fila[1].ToString();
                textBox3.Text = fila[2].ToString();
                textBox4.Text = fila[3].ToString();
                textBox5.Text = fila[4].ToString();
                textBox6.Text = fila[5].ToString();
                textBox7.Text = fila[6].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fila[7]);
                comboBoxMuni.SelectedValue = Convert.ToInt32(fila[8]);
                comboBoxDepa.SelectedValue = Convert.ToInt32(fila[9]);
            }
        }
    }
}
