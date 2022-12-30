using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DalUrun
    {
        public static int UrunEkle(urun p) //entiti layerdaki urun classından parametre oluşturuldu
        {
            SqlCommand ekle = new SqlCommand("insert into urunler(Adi,KategoriID,Fiyati,Stok,SevkiyatTarihi) values (@Adi,@KategoriID,@Fiyati,@Stok,@SevkiyatTarihi)",Baglanti.bgl);
            if (ekle.Connection.State != ConnectionState.Open)//Bağlantı açık değilse aç
            {
                ekle.Connection.Open();
            }
            //ekle parametresi aracılığı ile parametrelerimizi gödndereceğiz
            ekle.Parameters.AddWithValue("@Adi", p.Adi);
            ekle.Parameters.AddWithValue("@KategoriID", p.KategoriID);
            ekle.Parameters.AddWithValue("@Fiyati", p.Fiyati);
            ekle.Parameters.AddWithValue("@Stok", p.Stok  );
            ekle.Parameters.AddWithValue("@SevkiyatTarihi", p.SevkiyatTarihi);
            
            return ekle.ExecuteNonQuery();
        }
        public static List<urun>UrunListesi()
        {
            List<urun> urunler = new List<urun>();
            SqlCommand komut = new SqlCommand("SELECT * FROM Urunler ORDER BY ID DESC;", Baglanti.bgl);
            if(komut.Connection.State== ConnectionState.Closed)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                urun ent = new urun();
                ent.ID = int.Parse(dr[0].ToString());
                ent.Adi = dr[1].ToString();
                ent.KategoriID = int.Parse(dr[2].ToString());
                ent.Fiyati = decimal.Parse(dr[3].ToString());
                ent.Stok = int.Parse(dr[4].ToString());
                ent.SevkiyatTarihi = DateTime.Parse(dr[5].ToString());
                urunler.Add(ent);
            }
            dr.Close();
            return urunler;
        }//Urun Listeleme
        public static int UrunGuncelle(urun p)
        {
            SqlCommand guncelle = new SqlCommand("UPDATE Urunler SET Adi=@Adi,KategoriID=@KategoriID,Fiyati=@Fiyati,Stok=@Stok,SevkiyatTarihi=@SevkiyatTarihi WHERE ID=@ID;", Baglanti.bgl);
            if (guncelle.Connection.State != ConnectionState.Open)//Bağlantı açık değilse aç
            {
                guncelle.Connection.Open();
            }
            guncelle.Parameters.AddWithValue("@Adi", p.Adi);
            guncelle.Parameters.AddWithValue("@KategoriID", p.KategoriID);
            guncelle.Parameters.AddWithValue("@Fiyati", p.Fiyati);
            guncelle.Parameters.AddWithValue("@Stok", p.Stok);
            guncelle.Parameters.AddWithValue("@SevkiyatTarihi", p.SevkiyatTarihi);
            guncelle.Parameters.AddWithValue("@ID", p.ID);

            return guncelle.ExecuteNonQuery();

        } //Urun Guncelle

    }
}
