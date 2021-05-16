using AplicationLINQTest.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationLINQTest.DAO
{
    public class ListaModalidadDAO
    {
        List<ModalidadBO> modalidades;

        public ListaModalidadDAO()
        {
            modalidades = new List<ModalidadBO>();
        }


        public List<ModalidadBO> LoadModalidad()
        {
            modalidades.Add(new ModalidadBO() { iIdModalidad = 1, cNombreModalidad = "CAS" });
            modalidades.Add(new ModalidadBO() { iIdModalidad = 2, cNombreModalidad = "Temporal" });
            modalidades.Add(new ModalidadBO() { iIdModalidad = 3, cNombreModalidad = "Plazo Indeterminado" });
            return modalidades;
        }
    }
}
