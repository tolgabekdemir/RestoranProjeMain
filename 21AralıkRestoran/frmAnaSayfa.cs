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
        private void btnUrunler_Click(object sender, EventArgs e)
        {
            frmUrun frm = new frmUrun();
            frm.ShowDialog();   

        }

        private void btnKategoriler_Click(object sender, EventArgs e)
        {
            frmKategori frm = new frmKategori();
            frm.ShowDialog();
        }
    }
}
