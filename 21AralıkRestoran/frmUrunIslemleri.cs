using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using BusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _21AralıkRestoran
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            urun ent = new urun();
            ent.Adi=txtAdi.Text;
            //ent.KategoriID
            ent.Fiyati = Convert.ToInt32(txtFiyati.Text);
            ent.Stok = (int)Convert.ToDecimal(txtStok.Text);
            //ent.SevkiyatTarihi
            //takvim ekle otomatik bugüm seçili olsun

            BLUrun.BLUrunEkle(ent);


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {

        }

        private void frmAna_Load(object sender, EventArgs e)
        {

        }
    }
}
