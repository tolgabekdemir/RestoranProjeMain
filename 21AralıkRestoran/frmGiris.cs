using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21AralıkRestoran
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnGiris_Click(object sender, EventArgs e) {

            SqlConnection baglanti;
            SqlCommand komut;
            SqlDataReader veri;

            string sorgu = "SELECT Personeller.ID,Ad,Soyad,RolAdi,KullaniciAdi,Sifre FROM Personeller,Roller where Personeller.RolID=Roller.ID and  KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre";
            baglanti = new SqlConnection("Data Source=DESKTOP-D5V0N0E;Initial Catalog=RestoranTakip;Integrated Security=True");
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@Sifre", txtSifre.Text);
            baglanti.Open();
            veri = komut.ExecuteReader();
            if (veri.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız..." + " "+veri["AD"].ToString() + " Rolünüz: " + veri["RolAdi"]);
                frmAnaSayfa frm = new frmAnaSayfa();
                frm.Show();
                Hide();
            }

            else
            {MessageBox.Show("Kullanıcı Adınızı ve Şifrenizi Kontrol Ediniz.");
                txtKullaniciAdi.Clear();
                txtSifre.Clear();}
            baglanti.Close();
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            if(txtSifre.PasswordChar== '\0')
            {
                btnGizle.BringToFront();
                txtSifre.PasswordChar = '*';
            }
        }

        private void btnGizle_Click(object sender, EventArgs e)
        {
            if (txtSifre.PasswordChar == '*')
            {
                btnGoster.BringToFront();
                txtSifre.PasswordChar = '\0';
            }
        }
    }
}

