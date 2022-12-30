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
            //Kategorileri Çekme
         SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-D5V0N0E;Initial Catalog=RestoranTakip;Integrated Security=True");
        SqlCommand komut = new SqlCommand("select * from Kategoriler;", bgl);
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
            urun ent = new urun();
            ent.ID = int.Parse(txtID.Text);
            ent.Adi=txtAdi.Text;
            ent.KategoriID=((int)cmbKategori.SelectedValue);
            ent.Fiyati=int.Parse(txtFiyat.Text);
            ent.Stok=int.Parse(txtStok.Text);
            ent.SevkiyatTarihi=DateTime.Parse(dtpTarih.Text);
            BLUrun.BLUrunGuncelle(ent);
            UrunListele();
        } //Ürün güncelleme komutları
    }
}
