using AplicationLINQTest.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationLINQTest.DAO
{
    public class ListaEmpleados
    {
        public List<EmpleadoBO> empleados;

        public ListaEmpleados()
        {
            empleados = new List<EmpleadoBO>();
        }


        public List<EmpleadoBO> LoadEmpleados()
        {
            empleados.Add(new EmpleadoBO() { iIdEmpleado = 1, cNombre = "Felipe", cApellidos = "Contreras", iIdModalidad = 1 });
            empleados.Add(new EmpleadoBO() { iIdEmpleado = 2, cNombre = "Josue", cApellidos = "Lopez", iIdModalidad = 2 });
            empleados.Add(new EmpleadoBO() { iIdEmpleado = 3, cNombre = "Enrique", cApellidos = "Valle", iIdModalidad = 2 });
            empleados.Add(new EmpleadoBO() { iIdEmpleado = 4, cNombre = "Carmen", cApellidos = "Rojas", iIdModalidad = 1 });
            empleados.Add(new EmpleadoBO() { iIdEmpleado = 5, cNombre = "Ricardo", cApellidos = "Garma", iIdModalidad = 3 });
            empleados.Add(new EmpleadoBO() { iIdEmpleado = 6, cNombre = "Rolando", cApellidos = "Minchan", iIdModalidad = 3 });

            return empleados;
        }
    }
}
