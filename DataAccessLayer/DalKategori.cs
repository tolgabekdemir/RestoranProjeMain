using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalKategori
    {//Crud metotları olştur oku güncelleme silme
        public static int KategoriEkle(kategori p)
        {
            SqlCommand ekle = new SqlCommand("INSERT Kategoriler (KategoriAdi) VALUES (@adi);", Baglanti.bgl);

            if (ekle.Connection.State !=ConnectionState.Open)
            {
                ekle.Connection.Open();
            }
            ekle.Parameters.AddWithValue("@adi",p.KategoriAdi);
            
            return ekle.ExecuteNonQuery();
        } //Kategori Ekleme
        public static List<kategori>KategoriListesi()
        {
            List<kategori> kategoriler = new List<kategori>();
            SqlCommand listele = new SqlCommand("Select * from Kategoriler",Baglanti.bgl);
            if(listele.Connection.State !=ConnectionState.Open)
            {
                listele.Connection.Open();
            }
            SqlDataReader dr= listele.ExecuteReader();
            while(dr.Read())
            {
                kategori ent = new kategori();
                ent.ID = int.Parse(dr["ID"].ToString());
                ent.KategoriAdi = dr["KategoriAdi"].ToString();
                kategoriler.Add(ent);
            }
            dr.Close();
            return kategoriler;
        } //Kategori Silme
        public static int KategoriGuncelle(kategori p)
        {
            SqlCommand guncelle = new SqlCommand("update Kategoriler set KategoriAdi=@p1 where ID=@p2", Baglanti.bgl);
            if (guncelle.Connection.State != ConnectionState.Open)
            {
                guncelle.Connection.Open();
            }
            guncelle.Parameters.AddWithValue("@p1", p.KategoriAdi);
            guncelle.Parameters.AddWithValue("@p2", p.ID);
            return guncelle.ExecuteNonQuery();
        } //Kategori Guncelle
    }
}
