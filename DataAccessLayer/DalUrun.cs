using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DalUrun
    {
        public static int UrunEkle(urun p) //entiti layerdaki urun classından parametre oluşturuldu
        {
            SqlCommand ekle = new SqlCommand("insert into (Adi,KategoriID,Fiyati,Stok,SevkiyatTarihi) values (@Adi,@KategoriID,@Fiyati,@Stok,@SevkiyatTarihi)",Baglanti.bgl);
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
    }
}
