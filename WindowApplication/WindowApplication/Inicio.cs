using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowApplication
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.FormClosed += new FormClosedEventHandler(Inicio_FormClosed);
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Termina la aplicación cuando se cierra el formulario
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso a = new Ingreso();
            a.MdiParent = this;
            a.Show();
        }
    }
}
