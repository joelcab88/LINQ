using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONECTIONSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ConnectionTestDataContext db = new ConnectionTestDataContext();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgvEmpleados.DataSource = db.Empleado;
            getListHeaderText();
            
        }

        public void getListHeaderText()
        {
            dgvEmpleados.Columns[0].HeaderText = "Id empleado";
            dgvEmpleados.Columns[1].HeaderText = "Clave empleado";
            dgvEmpleados.Columns[2].HeaderText = "Nombre empleado";
            dgvEmpleados.Columns[3].HeaderText = "Apellido paterno";
            dgvEmpleados.Columns[4].HeaderText = "Apellido materno";
            dgvEmpleados.Columns[5].HeaderText = "Edad";
        }
    }
}
