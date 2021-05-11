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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<CategoriasBO> lstCategotia;

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
            dtgCategorias.DataSource = listaCategorias.LoadCategorias();
        }


        
    }
}
