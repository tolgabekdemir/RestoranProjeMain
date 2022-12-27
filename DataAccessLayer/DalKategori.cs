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
        }

    }
}
