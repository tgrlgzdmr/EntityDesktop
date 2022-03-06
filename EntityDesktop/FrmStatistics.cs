using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDesktop
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        Dbo_EntityProductEntities db = new Dbo_EntityProductEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_Category.Count().ToString();
            label3.Text = db.Tbl_Product.Count().ToString();
            label5.Text = db.Tbl_Customer.Count(x => x.CustomerSituation == true).ToString();
            label7.Text = db.Tbl_Customer.Count(x => x.CustomerSituation == false).ToString();
            label13.Text=db.Tbl_Product.Sum(x => x.Stock).ToString();
            //label11.Text= db.Tbl_Product.Max(x => x.Price).ToString() + "TL";
            label11.Text=(from x in db.Tbl_Product orderby x.Price descending select x.ProductName).FirstOrDefault();
            //label9.Text=db.Tbl_Product.Min(x => x.Price).ToString() + "TL";
            label9.Text = (from x in db.Tbl_Product orderby x.Price ascending select x.ProductName).FirstOrDefault();
            //label23.Text=db.Tbl_Customer.Count(x => x.Cıty).ToString();
            label23.Text = (from x in db.Tbl_Customer select x.Cıty).Distinct().Count().ToString();
            label25.Text=db.Tbl_Sale.Sum(x=>x.Price).ToString() + "TL";
            label15.Text=db.Tbl_Product.Count(x => x.Category==1).ToString();
            label17.Text=db.Tbl_Product.Count(X=> X.ProductName=="Fridge").ToString();
            label19.Text = db.PullBrand().FirstOrDefault();
            
        }
    }
}
