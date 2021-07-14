using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECCION_5
{
    public partial class FrmTerritorios : Form
    {
        public FrmTerritorios()
        {
            InitializeComponent();
        }
        ConnectionDataContext db = new ConnectionDataContext();
        private void FrmTerritorios_Load(object sender, EventArgs e)
        {
            int iRegion = 0;
            var region = db.Region.Select(r => new { RegionID = r.RegionID, RegionDescription = r.RegionDescription }).ToList();
            region.Add(new { RegionID = -1, RegionDescription = "---SELECCIONA UNA OPCIÓN---"});
            cmbRegion.DataSource = region.OrderBy(s => s.RegionID).ToList();
            cmbRegion.DisplayMember = "RegionDescription";
            cmbRegion.ValueMember = "RegionID";
            iRegion = int.Parse(cmbRegion.SelectedValue.ToString());
            dgvTerritories.DataSource = getTerritories(iRegion);
        }


        public List<TerritoriesDTO> getTerritories(int _RegionID)
        {
            var lstTerritories = (_RegionID == -1)
                ? //En caso de que _RegionID == -1 entonces hara la consulta de todo los territorios.
                    (db.Territories.Select(x => new
                    {
                        TerritoryID = x.TerritoryID,
                        TerritoryDescription = x.TerritoryDescription,
                        RegionID = x.RegionID
                    }).Join(db.Region.Select(r => new
                    {
                        RegionID = r.RegionID,
                        RegionDescription = r.RegionDescription
                    }),
                    t => t.RegionID,
                    r => r.RegionID,
                    (t, r) => new TerritoriesDTO
                    {
                        TerritoryID = t.TerritoryID,
                        TerritoryDescription = t.TerritoryDescription,
                        RegionDescription = r.RegionDescription
                    }))
                : //En caso de que _RegionID <> -1 entonces hara la consulta de los territorio asociados a la región seleccionados en el combobox.
                    (
                    (db.Territories.Where(y => y.RegionID == _RegionID).Select(x => new
                    {
                        TerritoryID = x.TerritoryID,
                        TerritoryDescription = x.TerritoryDescription,
                        RegionID = x.RegionID
                    }).Join(db.Region.Select(r => new
                    {
                        RegionID = r.RegionID,
                        RegionDescription = r.RegionDescription
                    }),
                    t => t.RegionID,
                    r => r.RegionID,
                    (t, r) => new TerritoriesDTO
                    {
                        TerritoryID = t.TerritoryID,
                        TerritoryDescription = t.TerritoryDescription,
                        RegionDescription = r.RegionDescription
                    }))
                    );
            return lstTerritories.ToList();
        }

        private void cmbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int iRegion = 0;
            iRegion = int.Parse(cmbRegion.SelectedValue.ToString());
            dgvTerritories.DataSource = getTerritories(iRegion);
        }
    }
}
