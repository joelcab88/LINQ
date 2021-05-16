using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicationLINQTest.BO;
using AplicationLINQTest.DAO;

namespace AplicationLINQTest
{
    public partial class EmpleadoPractica : Form
    {
        public EmpleadoPractica()
        {
            InitializeComponent();
        }

        private void EmpleadoPractica_Load(object sender, EventArgs e)
        {
            ListaEmpleados listaEmpleados = new ListaEmpleados();
            var lstEmp = listaEmpleados.LoadEmpleados();
            var lstSelect = lstEmp.Select(emp => new 
            {
                iIdEmpleado = emp.iIdEmpleado,
                cNombre = emp.cNombre,
                cApellidos = emp.cApellidos
            }).ToList();
            dgvEmpleados.DataSource = lstSelect;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ListaEmpleados listaEmpleados = new ListaEmpleados();
            var lstEmp = listaEmpleados.LoadEmpleados();
            int iIdEmpleado = 0;
            bool lEsValido = true;

            lEsValido = int.TryParse(txtIdEmpleado.Text,out iIdEmpleado);

            if (!lEsValido)
            {
                errorCampos.SetError(txtIdEmpleado, "El valor proporcionado en el campo no es valido");
                return;
            }
            else if (txtNombreEmpleado.Text.Equals(""))
            {
                errorCampos.SetError(txtNombreEmpleado, "Por favor, proporcione un nombre valido de empleado.");
                return;
            }
            else if (txtApellidoEmpleado.Text.Equals(""))
            {
                errorCampos.SetError(txtApellidoEmpleado, "Por favor, proporcione un apellido valido de empleado.");
                return;
            }

            EmpleadoBO empleado = new EmpleadoBO()
            {
                iIdEmpleado = iIdEmpleado,
                cNombre =  txtNombreEmpleado.Text,
                cApellidos =  txtApellidoEmpleado.Text
            };
            lstEmp.Add(empleado);
            var lstSelect = lstEmp.Select(emp => new
            {
                iIdEmpleado = emp.iIdEmpleado,
                cNombre = emp.cNombre,
                cApellidos = emp.cApellidos
            }).ToList();
            dgvEmpleados.DataSource = lstSelect;



        }
    }
}
