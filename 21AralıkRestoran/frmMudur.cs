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
    public partial class frmMudur : Form
    {
        public frmMudur()
        {
            InitializeComponent();
        }
        private void btnKategori_Click(object sender, EventArgs e)
        {
            frmKategori frm =new frmKategori();
            frm.Show();
        }
    }
}
