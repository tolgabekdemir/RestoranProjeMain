using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21AralıkRestoran
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        public void LogEkle()
        {
            log ent = new log();
            ent.PersonelAdi = txtKullaniciAdi.Text;
            ent.Islem = "Kullanıcısını silme İşlemi.";
            ent.IpAdresi = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            BLLog.BLLogEkle(ent);
        }
        public void PersonelListele()
        {
            List<personel> personeller = BLPersonel.BLPersonelListesi();
            dgvPersoneller.DataSource = personeller;
        } //Ürün Listele metodu
        public void RolleriCekme()
        {
            SqlCommand komut = new SqlCommand("select * from Roller", Baglanti.bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbRol.ValueMember = "ID";
            cmbRol.DisplayMember = "RolAdi";
            cmbRol.DataSource = dt;
        } //Combobox a rollerin value değeri id , display değeri adi gösterme metodu
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            RolleriCekme();
            PersonelListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                personel ent = new personel();
                ent.Ad = txtAd.Text;
                ent.Soyad = txtSoyad.Text;
                ent.RolID = ((int)cmbRol.SelectedValue);
                ent.KullaniciAdi = txtKullaniciAdi.Text;
                ent.Sifre = txtSifre.Text;
                BLPersonel.BLPersonelEkle(ent);
                PersonelListele();
            }
            catch
            {
                MessageBox.Show("Personel bilgilerini boş bırakmayınız.");
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            personel ent = new personel();
            ent.ID = int.Parse(txtID.Text);
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.RolID = ((int)cmbRol.SelectedValue);
            ent.KullaniciAdi = txtKullaniciAdi.Text;
            ent.Sifre = txtSifre.Text;
            BLPersonel.BLPersonelGuncelle(ent);
            PersonelListele();
        }

        private void dgvPersoneller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvPersoneller.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dgvPersoneller.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgvPersoneller.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbRol.SelectedValue = dgvPersoneller.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtKullaniciAdi.Text = dgvPersoneller.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSifre.Text = dgvPersoneller.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtAra.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            LogEkle();
            personel ent = new personel();
            ent.ID = int.Parse(txtID.Text);
            BLPersonel.BLPersonelSil(ent);
            PersonelListele();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
            {
                dgvPersoneller.ClearSelection();
                dgvPersoneller.FirstDisplayedScrollingRowIndex = dgvPersoneller.Rows[1].Index;
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dgvPersoneller.Rows)
                    {
                        if (row.Cells[1].Value.ToString().ToLower().StartsWith(txtAra.Text.ToString().Trim().ToLower()))
                        {
                            row.Selected = true; dgvPersoneller.FirstDisplayedScrollingRowIndex = row.Index; break;
                        }
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
