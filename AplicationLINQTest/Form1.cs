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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<CategoriasBO> lstCategotia;

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgCategorias.DataSource = LoadCategorias();
        }


        private List<CategoriasBO> LoadCategorias()
        {
            lstCategotia = new List<CategoriasBO>();
            lstCategotia.Add(new CategoriasBO { iIdCategoria = 1, cNombreCategoria = "Frutas" });
            lstCategotia.Add(new CategoriasBO { iIdCategoria = 2, cNombreCategoria = "Verduras" });
            lstCategotia.Add(new CategoriasBO { iIdCategoria = 3, cNombreCategoria = "Carnes frías" });
            lstCategotia.Add(new CategoriasBO { iIdCategoria = 4, cNombreCategoria = "Limpieza" });
            lstCategotia.Add(new CategoriasBO { iIdCategoria = 5, cNombreCategoria = "Higiene personal" });
            return lstCategotia;
        }
    }
}
