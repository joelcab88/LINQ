using SECCION4.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECCION4
{
    public partial class FiltroEmpleadosBTN : Form
    {
        public FiltroEmpleadosBTN()
        {
            InitializeComponent();
        }
        ConnectionDBDataContext db = new ConnectionDBDataContext();

        //public void LoadData()
        //{
        //    dgvEmpleados.DataSource = db.Empleado.Select(x => new {
        //        cCodigoEmpleado = x.cCodigoEmpleado,
        //        cNombreEmpleado = $"{x.cNombreEmpleado} {x.cApellidoPaterno} {x.cApellidoMaterno}",
        //        iEdad = x.iEdad.ToString() + " Años"
        //    }).ToList();
        //    getListHeaderText();
        //}
        public List<EmpleadoDTO> getListaEmpleado()
        {
            var lstEmp = db.Empleado.Select(x => new EmpleadoDTO
            {
                cCodigoEmpleado = x.cCodigoEmpleado,
                cNombreEmpleado = $"{x.cNombreEmpleado} {x.cApellidoPaterno} {x.cApellidoMaterno}",
                cEdad = x.iEdad.ToString() + " Años"
            }).ToList();
            return lstEmp;
        }
        public void getListHeaderText()
        {
            dgvEmpleados.Columns[0].HeaderText = "Clave empleado";
            dgvEmpleados.Columns[1].HeaderText = "Nombre empleado";
            dgvEmpleados.Columns[2].HeaderText = "Edad";
        }
        private void FiltroEmpleadosBTN_Load(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = getListaEmpleado();
            getListHeaderText();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //dgvEmpleados.DataSource = db.Empleado.Where(xy => xy.cNombreEmpleado.Equals(txtNombreEmpleado.Text.ToString())).Select(x => new {
            //    cCodigoEmpleado = x.cCodigoEmpleado,
            //    cNombreEmpleado = $"{x.cNombreEmpleado} {x.cApellidoPaterno} {x.cApellidoMaterno}",
            //    iEdad = x.iEdad.ToString() + " Años"
            //}).ToList();
            dgvEmpleados.DataSource = getListaEmpleado().Where(xy => xy.cNombreEmpleado.Contains(txtNombreEmpleado.Text.ToString())).ToList();
            getListHeaderText();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreEmpleado.Text = "";
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = getListaEmpleado();
        }
    }
}
