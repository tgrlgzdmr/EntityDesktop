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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategoryO fr = new FrmCategoryO();
            fr.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmProductO fr = new FrmProductO();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmStatistics fr = new FrmStatistics();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSaleO fr = new FrmSaleO();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmCustomerO fr = new FrmCustomerO();
            fr.Show();
        }
    }
}
