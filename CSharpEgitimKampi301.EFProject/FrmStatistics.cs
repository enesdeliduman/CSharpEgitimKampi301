using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAverageCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
            lblAveragePrice.Text = db.Location.Sum(x => x.LocationPrice).ToString();
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(x => x.LocationCountry).FirstOrDefault();
            lblCapadociaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(x => x.LocationCapacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAverage.Text = db.Location.Where(x => x.LocationCountry == "Turkey").Average(x => x.LocationCapacity).ToString();
            
            var romeGuideId = db.Location.Where(x => x.LocationCity == "Rome").Select(x => x.GuideId).FirstOrDefault(); ;
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(x => x.GuideName).FirstOrDefault();
            
            var maxCapacity= db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacity.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(x => x.LocationCountry).FirstOrDefault();
            
            var maxPrice = db.Location.Max(x => x.LocationPrice);
            lblMaxPrice.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(x => x.LocationCountry).FirstOrDefault();

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocation.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
        }
    }
}
