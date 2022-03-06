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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dbo_EntityProductEntities db = new Dbo_EntityProductEntities();
            var quest = from x in db.Tbl_Admin where x.AdminUser == textBox1.Text && x.Password == textBox2.Text
                        select x;
            if (quest.Any())
            {
                FrmMain fr = new FrmMain();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
    }
}
