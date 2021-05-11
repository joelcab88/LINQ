using AplicationLINQTest.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationLINQTest.DAO
{
    public class ListaCategoriasDAO
    {
        public List<CategoriasBO> categoriasBOs;
        public ListaCategoriasDAO()
        {
            categoriasBOs = new List<CategoriasBO>();
        }

        public List<CategoriasBO> LoadCategorias()
        {
            categoriasBOs = new List<CategoriasBO>();
            categoriasBOs.Add(new CategoriasBO { iIdCategoria = 1, cNombreCategoria = "Frutas" });
            categoriasBOs.Add(new CategoriasBO { iIdCategoria = 2, cNombreCategoria = "Verduras" });
            categoriasBOs.Add(new CategoriasBO { iIdCategoria = 3, cNombreCategoria = "Carnes frías" });
            categoriasBOs.Add(new CategoriasBO { iIdCategoria = 4, cNombreCategoria = "Limpieza" });
            categoriasBOs.Add(new CategoriasBO { iIdCategoria = 5, cNombreCategoria = "Higiene personal" });
            return categoriasBOs;
        }
    }
}
