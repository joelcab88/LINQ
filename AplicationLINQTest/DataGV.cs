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
    }
}
