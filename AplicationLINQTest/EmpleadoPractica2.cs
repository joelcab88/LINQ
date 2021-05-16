using AplicationLINQTest.DAO;
using AplicationLINQTest.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicationLINQTest
{
    public partial class EmpleadoPractica2 : Form
    {
        public EmpleadoPractica2()
        {
            InitializeComponent();
        }

        private void EmpleadoPractica2_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListaEmpleados listaEmpleados = new ListaEmpleados();
            var lstEmp = listaEmpleados.LoadEmpleados();
            string cApellido = textBox1.Text;
            var lstSelect = lstEmp.Select(emp => new
            {
                iIdEmpleado = emp.iIdEmpleado,
                cNombre = emp.cNombre,
                cApellidos = emp.cApellidos
            }).ToList();
            if (cApellido.Equals(""))
            {
                dgvEmpleados.DataSource = lstSelect;
            }
            else
            {
                dgvEmpleados.DataSource = lstSelect.Where(x => x.cApellidos.Contains(cApellido)).ToList();
            }
            
        }
    }
}
