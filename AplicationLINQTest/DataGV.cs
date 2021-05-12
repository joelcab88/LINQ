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
            ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
            CategoriasBO cat = new CategoriasBO();
            cat.iIdCategoria = int.Parse(txtIdCategoria.Text);
            cat.cNombreCategoria = txtNombreCategoria.Text;
            var lst = listaCategorias.LoadCategorias();
            lst.Add(cat);
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = lst;
        }
    }
}
