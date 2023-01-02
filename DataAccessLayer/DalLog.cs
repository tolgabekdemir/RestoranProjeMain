using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalLog
    {
        public static int LogEkle(log p) //entiti layerdaki log classından parametre oluşturuldu
        {
            SqlCommand ekle = new SqlCommand("insert into Loglar(PersonelAdi,Tarih,Islem,IpAdresi) values (@PersonelAdi,GETDATE(),@Islem,@IpAdresi)", Baglanti.bgl);
            if (ekle.Connection.State != ConnectionState.Open)//Bağlantı açık değilse aç
            {
                ekle.Connection.Open();
            }
            //ekle parametresi aracılığı ile parametrelerimizi gödndereceğiz
            ekle.Parameters.AddWithValue("@PersonelAdi", p.PersonelAdi);
            ekle.Parameters.AddWithValue("@Islem", p.Islem);
            ekle.Parameters.AddWithValue("@IpAdresi", p.IpAdresi);

            return ekle.ExecuteNonQuery();
        }
    }
}
