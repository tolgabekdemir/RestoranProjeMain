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
using DataAccessLayer;
using BusinessLayer;
using EntityLayer;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace _21AralıkRestoran
{
    public partial class frmGiris : Form
    {
        public static string AdSoyad;
        public frmGiris()
        {
            InitializeComponent();
        }
        public void LogEkle()
        {
            log ent = new log();
            ent.PersonelAdi = txtKullaniciAdi.Text;
            ent.Islem = "Giriş İşlemi.";
            ent.IpAdresi = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            BLLog.BLLogEkle(ent);
        }
        #region  
        public static bool SiparislerButonuGizle = false;
        public static bool MasalarButonuGizle = false;
        public static bool UrunlerButonuGizle = false;
        public static bool KategorilerButonuGizle = false;
        public static bool RaporlarButonuGizle = false;
        public static bool AdminButonuGizle = false;
        #endregion //Buton gizlemelere false değeri atanması
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//çıkış butonuna tıklandığında programı durdurma.
        public  void btnGiris_Click(object sender, EventArgs e) 
        {
            LogEkle();
            SqlCommand komut;
            SqlDataReader veri;
            string sorgu = "SELECT Personeller.ID,Ad,Soyad,RolAdi,KullaniciAdi,Sifre FROM Personeller,Roller where Personeller.RolID=Roller.ID and  KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre";
            komut = new SqlCommand(sorgu,Baglanti.bgl);
            komut.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@Sifre", txtSifre.Text);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            veri = komut.ExecuteReader();
            if (veri.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız..." + " Rolünüz: " + veri["RolAdi"], "HOŞGELDİNİZ "+veri["AD"].ToString()+" "+ veri["Soyad"].ToString());
                AdSoyad = veri["Ad"].ToString() + " " + veri["Soyad"].ToString();//Grişi yapan kullanıcının ad soyadını değişkene atadı ki diğer formda kullanabileyim.
                #region
                if (veri["RolAdi"].ToString() == "Garson")
                {
                    UrunlerButonuGizle = true;
                    KategorilerButonuGizle = true;
                    RaporlarButonuGizle = true;
                    AdminButonuGizle = true;
                }
                else if (veri["RolAdi"].ToString() == "Müdür")
                {
                    AdminButonuGizle = true;
                }
                #endregion //Veri tabanındaki yetkiye göre butonların gizlenmesi
                frmAnaSayfa frm = new frmAnaSayfa();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınızı ve Şifrenizi Kontrol Ediniz.");
                txtKullaniciAdi.Clear();
                txtSifre.Clear();}
                Baglanti.bgl.Close();
        }  //Veri tabanındaki kullanıcı bilgileri ile giriş yapılan bilgilerin karşılaştırlması
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
        public void frmGiris_Load(object sender, EventArgs e)
        {
            string bilgisayarAdi = Dns.GetHostName();
            lblPcAdi.Text = "Bilgisayar Adı: " + bilgisayarAdi;
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            lblIPAdresi.Text = "IP Adresi :" + ipAdresi;

            txtSifre.UseSystemPasswordChar = true;//Uygulama açılır iken şifrenin gizli şekilde gelmesini sağlar
        }
    }
}

