using AplicationLINQTest.BO;
using AplicationLINQTest.DAO;
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
    public partial class frmComboBox : Form
    {
        public frmComboBox()
        {
            InitializeComponent();
        }

        private void frmComboBox_Load(object sender, EventArgs e)
        {
            ListaCategoriasDAO lstCategorias = new ListaCategoriasDAO();
            ListaProductosDAO listaProductos = new ListaProductosDAO();
            var lst = lstCategorias.LoadCategorias();
            lst.Add(new CategoriasBO { iIdCategoria = -1, cNombreCategoria = "--SELECCIONE UN VALOR--" });
            cmbValor.DataSource = lst.OrderBy(x => x.iIdCategoria).ToList();
            cmbValor.DisplayMember = "cNombreCategoria";
            cmbValor.ValueMember = "iIdCategoria";

            dgvProductos.DataSource = listaProductos.LoadCategorias().ToList();
        }

        private void cmbValor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListaProductosDAO listaProductos = new ListaProductosDAO();
            ListaCategoriasDAO lstCategorias = new ListaCategoriasDAO();

            int iIdCategoria = int.Parse(cmbValor.SelectedValue.ToString());
            var lstProduct = listaProductos.LoadCategorias();
            if (iIdCategoria.Equals(-1))
                dgvProductos.DataSource = lstProduct;
            else
                dgvProductos.DataSource = lstProduct.Where(x => x.iIdCategoria.Equals(iIdCategoria)).ToList();

        }
    }
}
