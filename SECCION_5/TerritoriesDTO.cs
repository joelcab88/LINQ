using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECCION_5
{
    /// <summary>
    /// DTO Para realizar la consulta de territorios Impresos en el datagridView
    /// </summary>
    public class TerritoriesDTO
    {
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public string RegionDescription { get; set; }
    }
}
