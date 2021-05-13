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
    public partial class FiltroLINQSensitivo : Form
    {
        public FiltroLINQSensitivo()
        {
            InitializeComponent();
        }

        private void FiltroLINQ_Load(object sender, EventArgs e)
        {
            ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
            dgvCategorias.DataSource = listaCategorias.LoadCategorias();
        }

        //private void btnConsultar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtNombreCategoria.Text.Equals(""))
        //        {
        //            errorFormulario.SetError(txtNombreCategoria,"Por favor, introduzca un valor en el campo para realizar la busqueda.");
        //            return;
        //        }
        //        ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
        //        string cNombreCategoria = txtNombreCategoria.Text;
        //        var lstCategorias = listaCategorias.LoadCategorias();
        //        var queryCategorias = (from qcat in lstCategorias
        //                              where qcat.cNombreCategoria == cNombreCategoria
        //                              select qcat).ToList();
        //        if (queryCategorias.Count() == 0)
        //        {
        //            MessageBox.Show($"Lo sentimos, No se han encontrado categorías con el nombre: '{cNombreCategoria}'.");
        //            LimpiaCampos();
        //            return;
        //        }
        //        else
        //        {
        //            dgvCategorias.DataSource = queryCategorias;
        //            LimpiaCampos();
        //        }
        //    }catch(Exception ex)
        //    {
        //        MessageBox.Show("Ha ocurrido un error: " + ex.Message);
        //    }
            
        //}

        private void LimpiaCampos()
        {
            txtNombreCategoria.Text = "";
        }

        private void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ListaCategoriasDAO listaCategorias = new ListaCategoriasDAO();
                string cNombreCategoria = txtNombreCategoria.Text;
                var lstCategorias = listaCategorias.LoadCategorias();
                if (cNombreCategoria.Equals(""))
                {
                    dgvCategorias.DataSource = lstCategorias;
                }
                else
                {
                    var queryCategorias = (from qcat in lstCategorias
                                       where qcat.cNombreCategoria.Contains(cNombreCategoria)
                                       select qcat).ToList();
                    dgvCategorias.DataSource = queryCategorias;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }
    }
}
