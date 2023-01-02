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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _21AralıkRestoran
{
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }
        public void KategoriListele()
        {
            List<kategori> list = BLKategori.BLKategoriListesi();
            dgvKategori.DataSource= list;
        }//Kategori listeleme metodu
        private void frmKategori_Load(object sender, EventArgs e)
        {
            KategoriListele();
        } //Form açılırken listeleme metodunun çalışması

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                kategori ent = new kategori();
                ent.KategoriAdi = txtKategoriAdi.Text;
                BLKategori.BLKategoriEkle(ent);
                KategoriListele();
            }
            catch
            {
                MessageBox.Show("Kategori ID veya adı geçersiz.", "HATA");
            }
        }//Ekle Komutları
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                kategori ent = new kategori();
                ent.KategoriAdi = txtKategoriAdi.Text;
                ent.ID = int.Parse(txtID.Text);
                BLKategori.KategoriGuncelle(ent);
                KategoriListele();
            }
            catch 
            {
                MessageBox.Show("Geçerli bir ID değeri için satır seçiniz.", "HATA");
            }
        }//Guncelle Komutları
        private void dgvKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvKategori.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAdi.Text = dgvKategori.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtKategoriAdi.Clear();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            kategori ent = new kategori();
            ent.ID = int.Parse(txtID.Text);
           BLKategori.KategoriSil (ent);
            KategoriListele();
        }
    }
}
