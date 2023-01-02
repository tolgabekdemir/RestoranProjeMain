using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
        private void ButonlarıGizle()
        { 
            #region
            if (frmGiris.SiparislerButonuGizle)
                btnSiparisler.Enabled = false;
            if (frmGiris.MasalarButonuGizle)
                btnMasalar.Enabled = false;
            if (frmGiris.UrunlerButonuGizle)
                btnUrunler.Enabled = false;
            if (frmGiris.KategorilerButonuGizle)
                btnKategoriler.Enabled = false;
            if (frmGiris.RaporlarButonuGizle)
                btnRaporlar.Enabled = false;
            if (frmGiris.AdminButonuGizle)
                btnAdmin.Enabled = false;
            #endregion//Ana sayfadaki butonları gizleme(Giriş formunda veri tabanındaki yetkiye göre butonların gizlenmesi)
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
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            ButonlarıGizle();
            lblPersonelAdiSoyadi.Text = frmGiris.AdSoyad;//Giriş formundaki değişkenden aldığımız ad soyad bilgisinin labele ataması.
        }
        private void btnSiparisler_Click(object sender, EventArgs e)
        {

        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            frm.ShowDialog();
        }
    }
}
