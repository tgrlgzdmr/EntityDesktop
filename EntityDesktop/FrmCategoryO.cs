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
    public partial class FrmCategoryO : Form
    {
        public FrmCategoryO()
        {
            InitializeComponent();
        }
        Dbo_EntityProductEntities db = new Dbo_EntityProductEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            var categories = db.Tbl_Category.ToList();
            dataGridView1.DataSource = categories;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Category t = new Tbl_Category();
            t.CategoryName =TxtName.Text;
            db.Tbl_Category.Add(t);
            db.SaveChanges();
            MessageBox.Show("Category is added");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var ctg = db.Tbl_Category.Find(x);
            db.Tbl_Category.Remove(ctg);
            db.SaveChanges();
            MessageBox.Show("Category is deleted");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var ctg = db.Tbl_Category.Find(x);
            ctg.CategoryName =TxtName.Text;
            db.SaveChanges();
            MessageBox.Show("Category is updated");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
        }
    }
}
