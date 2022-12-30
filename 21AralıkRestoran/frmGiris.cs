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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        }//çıkış butonuna tıklandığında programı durdurma.
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
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//Şifreyi Göster gizle checkbox kodları.
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                txtSifre.UseSystemPasswordChar = true;
                checkBox1.Text = "Göster";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                txtSifre.UseSystemPasswordChar = false;
                checkBox1.Text = "Gizle";
            }

        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            string bilgisayarAdi = Dns.GetHostName();
            lblPcAdi.Text = "Bilgisayar Adı: " + bilgisayarAdi;
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            lblIPAdresi.Text = "IP Adresi :" + ipAdresi;

            txtSifre.UseSystemPasswordChar = true;//Uygulama açılır iken şifrenin gizli şekilde gelmesini sağlar
        }
    }
}

