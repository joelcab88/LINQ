using AplicationLINQTest.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationLINQTest.DAO
{
    public class ListaProductosDAO
    {
        public List<ProductosBO> LstProductos;

        public ListaProductosDAO()
        {
            LstProductos = new List<ProductosBO>();
        }

        public List<ProductosBO> LoadCategorias()
        {
            LstProductos.Add(new ProductosBO { iIdProducto = 1, cNombreProducto="Manzana", iIdCategoria=1 });
            LstProductos.Add(new ProductosBO { iIdProducto = 2, cNombreProducto = "Zanahoria", iIdCategoria = 2 });
            LstProductos.Add(new ProductosBO { iIdProducto = 3, cNombreProducto = "Jamón", iIdCategoria =3 });
            LstProductos.Add(new ProductosBO { iIdProducto = 4, cNombreProducto = "Detergente liquido", iIdCategoria = 4 });
            LstProductos.Add(new ProductosBO { iIdProducto = 5, cNombreProducto = "Gel Antibacterial", iIdCategoria = 5 });
            LstProductos.Add(new ProductosBO { iIdProducto = 6, cNombreProducto = "Pera", iIdCategoria = 1 });
            LstProductos.Add(new ProductosBO { iIdProducto = 7, cNombreProducto = "Platano", iIdCategoria = 1 });
            LstProductos.Add(new ProductosBO { iIdProducto = 8, cNombreProducto = "Calabaza", iIdCategoria = 2 });
            return LstProductos;
        }
    }
}
