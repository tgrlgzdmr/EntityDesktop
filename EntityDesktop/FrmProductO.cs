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
    public partial class FrmProductO : Form
    {
        public FrmProductO()
        {
            InitializeComponent();
        }
        Dbo_EntityProductEntities db = new Dbo_EntityProductEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Product
                                        select new
                                        {
                                            x.ProductID,
                                            x.ProductName,
                                            x.Brand,
                                            x.Stock,
                                            x.Price,
                                            x.Tbl_Category.CategoryName,
                                            x.StockSituation
                                        }).ToList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            Tbl_Product t = new Tbl_Product();
            t.ProductName = TxtName.Text;
            t.Brand = TxtBrand.Text;
            t.Stock = short.Parse(TxtStock.Text);
            t.Price = decimal.Parse(TxtPrice.Text);
            t.StockSituation = true;
            t.Category = int.Parse(CmbCategory.SelectedValue.ToString());
            db.Tbl_Product.Add(t);
            db.SaveChanges();
            MessageBox.Show("Product is added");


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var prd = db.Tbl_Product.Find(x);
            db.Tbl_Product.Remove(prd);
            db.SaveChanges();
            MessageBox.Show("Product is deleted");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            TxtBrand.Text = dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            TxtStock.Text = dataGridView1.Rows[chosen].Cells[3].Value.ToString();
            TxtPrice.Text = dataGridView1.Rows[chosen].Cells[4].Value.ToString();
            //TxtSituation.Text = dataGridView1.Rows[chosen].Cells[5].Value.ToString();
            CmbCategory.SelectedValue = dataGridView1.Rows[chosen].Cells[6].Value.ToString();

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var prd = db.Tbl_Product.Find(x);
            prd.ProductName = TxtName.Text;
            prd.Brand = TxtBrand.Text;
            prd.Stock = short.Parse(TxtStock.Text);
            prd.Price = decimal.Parse(TxtPrice.Text);
            //prd.StockSituation
            prd.Category = int.Parse(CmbCategory.Text);
            db.SaveChanges();
            MessageBox.Show("Product is updated");

        }

        private void FrmProductO_Load(object sender, EventArgs e)
        {
            var catagories = (from x in db.Tbl_Category
                              select new
                              {
                                  x.CategoryID,
                                  x.CategoryName
                              }
                              ).ToList();
            CmbCategory.ValueMember = "CategoryID";
            CmbCategory.DisplayMember = "CategoryName";
            CmbCategory.DataSource = catagories;
        }


    }
}
