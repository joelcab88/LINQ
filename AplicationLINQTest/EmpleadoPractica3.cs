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
    public partial class EmpleadoPractica3 : Form
    {
        public EmpleadoPractica3()
        {
            InitializeComponent();
        }

        private void EmpleadoPractica3_Load(object sender, EventArgs e)
        {
            ListaEmpleados listaEmpleados = new ListaEmpleados();
            ListaModalidadDAO listaModalidad = new ListaModalidadDAO();
            var lstMod = listaModalidad.LoadModalidad();
            lstMod.Add(new ModalidadBO { iIdModalidad = -1, cNombreModalidad = "--SELECCIONE UN VALOR--" });
            cmbMod.DataSource = lstMod.OrderBy(x => x.iIdModalidad).ToList();
            cmbMod.DisplayMember = "cNombreModalidad";
            cmbMod.ValueMember = "iIdModalidad";

            var lstEmp = listaEmpleados.LoadEmpleados();
            var lstSelect = lstEmp.Join(lstMod,
                emp => emp.iIdModalidad,
                mod => mod.iIdModalidad,
                (emp, mod) => new
                {
                    iIdEmpleado = emp.iIdEmpleado,
                    cNombre = emp.cNombre,
                    cApellidos = emp.cApellidos,
                    cNombreModalidad = mod.cNombreModalidad
                }).ToList();
            dgvEmpleados.DataSource = lstSelect;
        }

        private void cmbMod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListaEmpleados listaEmpleados = new ListaEmpleados();
            ListaModalidadDAO listaModalidad = new ListaModalidadDAO();
            int iIdModalidad = int.Parse(cmbMod.SelectedValue.ToString());

            var lstMod = listaModalidad.LoadModalidad();
            var lstEmp = listaEmpleados.LoadEmpleados();
            
            if (iIdModalidad.Equals(-1))
            {
                dgvEmpleados.DataSource = lstEmp.Join(lstMod,
                emp => emp.iIdModalidad,
                mod => mod.iIdModalidad,
                (emp, mod) => new
                {
                    iIdEmpleado = emp.iIdEmpleado,
                    cNombre = emp.cNombre,
                    cApellidos = emp.cApellidos,
                    cNombreModalidad = mod.cNombreModalidad
                }).ToList();
            }
            else
            {
                dgvEmpleados.DataSource = 
                lstEmp
                .Join(lstMod,
                emp => emp.iIdModalidad,
                mod => mod.iIdModalidad,
                (emp, mod) => new
                {
                    emp = emp,
                    mod = mod
                })
                .Where(c => c.mod.iIdModalidad.Equals(iIdModalidad))
                .Select(c => new
                {
                    iIdEmpleado = c.emp.iIdEmpleado,
                    cNombre = c.emp.cNombre,
                    cApellidos = c.emp.cApellidos,
                    cNombreModalidad = c.mod.cNombreModalidad
                })
                .ToList();
            }
        }
    }
}
