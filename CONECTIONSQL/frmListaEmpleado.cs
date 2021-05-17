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
    public partial class frmListaEmpleado : Form
    {
        public frmListaEmpleado()
        {
            InitializeComponent();
        }

        ConnectionTestDataContext db = new ConnectionTestDataContext();

        private void frmListaEmpleado_Load(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = db.Empleado.Select(x => new {
                cCodigoEmpleado = x.cCodigoEmpleado,
                cNombreEmpleado = $"{x.cNombreEmpleado} {x.cApellidoPaterno} {x.cApellidoMaterno}",
                iEdad = x.iEdad.ToString() + " Años"
            }).ToList();
            getListHeaderText();
        }

        public void getListHeaderText()
        {
            dgvEmpleados.Columns[0].HeaderText = "Clave empleado";
            dgvEmpleados.Columns[1].HeaderText = "Nombre empleado";
            dgvEmpleados.Columns[2].HeaderText = "Edad";
        }
    }
}
