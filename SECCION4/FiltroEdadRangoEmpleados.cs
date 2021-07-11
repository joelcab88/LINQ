﻿using SECCION4.DTO;
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
    public partial class FiltroEdadRangoEmpleados : Form
    {
        public FiltroEdadRangoEmpleados()
        {
            InitializeComponent();
        }

        ConnectionDBDataContext db = new ConnectionDBDataContext();

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

        private void FiltroEdadRangoEmpleados_Load(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = getListaEmpleado();
            getListHeaderText();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = getListaEmpleado()
                .Where(xy => 
                int.Parse(xy.cEdad.Replace(" Años","")) >= NudRango1.Value && int.Parse(xy.cEdad.Replace(" Años", "")) <= NudRango2.Value)
                .ToList();
            getListHeaderText();
        }
    }
}
