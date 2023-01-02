using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class DalPersonel
    {
        public static int PersonelEkle(personel p) //entiti layerdaki personel classından parametre oluşturuldu
        {
            SqlCommand ekle = new SqlCommand("insert into Personeller(Ad,Soyad,RolID,KullaniciAdi,Sifre) values (@Ad,@Soyad,@RolID,@KullaniciAdi,@Sifre)", Baglanti.bgl);
            if (ekle.Connection.State != ConnectionState.Open)//Bağlantı açık değilse aç
            {
                ekle.Connection.Open();
            }
            //ekle parametresi aracılığı ile parametrelerimizi gödndereceğiz
            ekle.Parameters.AddWithValue("@Ad", p.Ad);
            ekle.Parameters.AddWithValue("@Soyad", p.Soyad);
            ekle.Parameters.AddWithValue("@RolID", p.RolID);
            ekle.Parameters.AddWithValue("@KullaniciAdi", p.KullaniciAdi);
            ekle.Parameters.AddWithValue("@Sifre", p.Sifre);

            return ekle.ExecuteNonQuery();
        }
        public static List<personel> PersonelListesi()
        {
            List<personel> personeller = new List<personel>();
            SqlCommand komut = new SqlCommand("Select ID,Ad,Soyad,RolID,KullaniciAdi,Sifre FROM PERSONELLER where Durum=1", Baglanti.bgl);
            if (komut.Connection.State == ConnectionState.Closed)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                personel ent = new personel();
                ent.ID = int.Parse(dr[0].ToString());
                ent.Ad = dr[1].ToString();
                ent.Soyad = dr[2].ToString();
                ent.RolID = int.Parse(dr[3].ToString());
                ent.KullaniciAdi= dr[4].ToString();
                ent.Sifre= dr[5].ToString();
                personeller.Add(ent);
            }
            dr.Close();
            return personeller;
        }//Personell Listeleme
        public static int PersonelGuncelle(personel p)
        {
            
            SqlCommand guncelle = new SqlCommand("UPDATE Personeller SET Ad=@Ad,Soyad=@Soyad,RolID=@RolID,KullaniciAdi=@KullaniciAdi,Sifre=@Sifre WHERE ID=@ID;", Baglanti.bgl);
            if (guncelle.Connection.State != ConnectionState.Open)//Bağlantı açık değilse aç
            {
                guncelle.Connection.Open();
            }
            
            guncelle.Parameters.AddWithValue("@Ad", p.Ad);
            guncelle.Parameters.AddWithValue("@Soyad", p.Soyad);
            guncelle.Parameters.AddWithValue("@RolID", p.RolID);
            guncelle.Parameters.AddWithValue("@KullaniciAdi", p.KullaniciAdi);
            guncelle.Parameters.AddWithValue("@Sifre", p.Sifre);
            guncelle.Parameters.AddWithValue("@ID", p.ID);
            return guncelle.ExecuteNonQuery();
        } //Personel Guncelle

        public static int PersonelSil(personel p)
        {
            SqlCommand sil = new SqlCommand("UPDATE Personeller SET Durum='0' WHERE ID=@ID;", Baglanti.bgl);
            if (sil.Connection.State != ConnectionState.Open)//Bağlantı açık değilse aç
            {
                sil.Connection.Open();
            }
            sil.Parameters.AddWithValue("@ID", p.ID);
            

            return sil.ExecuteNonQuery();

        } //Personel Sİlme
    }
}
