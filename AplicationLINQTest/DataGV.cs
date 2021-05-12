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
    public partial class DataGV : Form
    {
        public DataGV()
        {
            InitializeComponent();
        }

        private void DataGV_Load(object sender, EventArgs e)
        {
            ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
            dgvCategorias.DataSource = listaCategorias.LoadCategorias();
        }

        private void btningresa_Click(object sender, EventArgs e)
        {
            try
            {
                int iIdCategoria;
                bool lFormatoValido = true;
                lFormatoValido = int.TryParse(txtIdCategoria.Text, out iIdCategoria);
                if (!lFormatoValido)
                {
                    errorFormulario.SetError(txtIdCategoria,"El valor ingresado en el campo no tiene el formato correcto, favor de validar.");
                    return;
                }
                else if (txtNombreCategoria.Text.Equals(""))
                {
                    errorFormulario.SetError(txtNombreCategoria, "El valor ingresado en el campo no tiene el formato correcto, favor de validar.");
                    return;
                }
                ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
                CategoriasBO cat = new CategoriasBO();
                cat.iIdCategoria = iIdCategoria;
                cat.cNombreCategoria = txtNombreCategoria.Text;
                var lst = listaCategorias.LoadCategorias();
                lst.Add(cat);
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = lst;
                LimpiaCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
            
        }

        private void LimpiaCampos()
        {
            txtIdCategoria.Text = "";
            txtNombreCategoria.Text = "";
        }
    }
}
