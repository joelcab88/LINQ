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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConnectionDataContext db = new ConnectionDataContext();

        private void Form1_Load(object sender, EventArgs e)
        {
            var Territories = db.Territories.Select(x => new
            {
                TerritoryID =  x.TerritoryID,
                TerritoryDescription = x.TerritoryDescription,
                RegionID =  x.RegionID
            }).ToList();

            var Regions = db.Region.Select(r => new
            {
                RegionID = r.RegionID,
                RegionDescription = r.RegionDescription
            }).ToList();

            var TRJoin = Territories.Join(Regions,
            t => t.RegionID,
            r => r.RegionID,
            (t, r) => new
            {
                TerritoryID = t.TerritoryID,
                TerritoryDescription = t.TerritoryDescription,
                RegionDescription = r.RegionDescription
            });
            dgvTerritories.DataSource = TRJoin.ToList();
        }
    }
}
