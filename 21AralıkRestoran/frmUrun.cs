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
using System.Data.SqlClient;

namespace _21AralıkRestoran
{
    public partial class frmUrun : Form
    {
        public frmUrun()
        {
            InitializeComponent();
        }
        public void UrunListele()
        {
            List<urun> urunler = BLUrun.BLUrunListesi();
            dgvUrunler.DataSource= urunler;
        } //Ürün Listele metodu
        public void KategorileriCekme()
        {
            SqlCommand komut = new SqlCommand("select * from Kategoriler where Durum=1", Baglanti.bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.DataSource = dt;
        } //Combobox a kategorilerin value değeri id , display değeri adi gösterme metodu

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                urun ent = new urun();
                ent.Adi = txtAdi.Text;
                ent.KategoriID = ((int)cmbKategori.SelectedValue);
                ent.Fiyati = int.Parse(txtFiyat.Text);
                ent.Stok = int.Parse(txtStok.Text);
                ent.SevkiyatTarihi = DateTime.Parse(dtpTarih.Text);
                BLUrun.BLUrunEkle(ent);
                UrunListele();
            }
            catch
            {
                MessageBox.Show("Ürün bilgilerini boş bırakmayınız.");
            }
        } //Ekle komutları
        private void frmUrun_Load(object sender, EventArgs e)
        {
            KategorileriCekme();
            UrunListele();
        } //Comboboxa ve data gride verilerin çekilmesi metodlarının Form açılırken çalışması
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                urun ent = new urun();
                ent.ID = int.Parse(txtID.Text);
                ent.Adi = txtAdi.Text;
                ent.KategoriID = ((int)cmbKategori.SelectedValue);
                ent.Fiyati = decimal.Parse(txtFiyat.Text);
                ent.Stok = int.Parse(txtStok.Text);
                ent.SevkiyatTarihi = DateTime.Parse(dtpTarih.Text);
                BLUrun.BLUrunGuncelle(ent);
                UrunListele();
            }
            catch
            {
                MessageBox.Show("Geçerli bir ID değeri için satır seçiniz.", "HATA");
            }

            } //Ürün güncelleme komutları

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvUrunler.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAdi.Text = dgvUrunler.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbKategori.SelectedValue = dgvUrunler.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtFiyat.Text = dgvUrunler.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtStok.Text = dgvUrunler.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpTarih.Text = dgvUrunler.Rows[e.RowIndex].Cells[5].Value.ToString();
        } // data gridde seçilen verileri textboxa aktarma

        private void txtUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAra.Text == "")
            {
                dgvUrunler.ClearSelection();
                dgvUrunler.FirstDisplayedScrollingRowIndex = dgvUrunler.Rows[1].Index;
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dgvUrunler.Rows)
                    {
                        if (row.Cells[1].Value.ToString().ToLower().StartsWith(txtUrunAra.Text.ToString().Trim().ToLower()))
                        {
                            row.Selected = true; dgvUrunler.FirstDisplayedScrollingRowIndex = row.Index; break;
                        }
                    }
                }
                catch (Exception) { }
            }
        } // ürün arama

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtAdi.Clear();
            txtFiyat.Clear();
            txtStok.Clear();
        } // textboxları temizleme

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                urun ent = new urun();
                ent.ID = int.Parse(txtID.Text);
                BLUrun.BLUrunSil(ent);
                UrunListele();
            }
            catch
            {
                MessageBox.Show("Geçerli bir ID değeri için satır seçiniz.", "HATA");
            }
        } // Silme butonu
    } 
}
