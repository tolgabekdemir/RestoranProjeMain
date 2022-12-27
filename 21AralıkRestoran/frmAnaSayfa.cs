using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21AralıkRestoran
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnMudurPaneli(object sender, EventArgs e)
        {
            frmMudur frm = new frmMudur();
            frm.MdiParent= this;
            frm.FormBorderStyle= FormBorderStyle.None; 
            frm.Show();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {

        }
    }
}
