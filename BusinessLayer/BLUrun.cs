using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLUrun
    {
        public static int BLUrunEkle(urun p)
        {
            if (p.Adi != null && p.Adi.Length >= 2 && p.Adi.Length <= 30)
            {
                return DalUrun.UrunEkle(p);
            }
            return -1;
        } //Urun ekle
        public static List<urun> BLUrunListesi()
        {
            return DalUrun.UrunListesi();
        } //Urun Listele
        public static int BLUrunGuncelle(urun p)
        {
            if (p.Adi != null && p.Adi.Length >= 2 && p.Adi.Length <= 30)
            {
                return DalUrun.UrunGuncelle(p);
            }
            return -1;
        } //Ürün Güncelle
        public static int BLUrunSil(urun p)
        {
            //sadece 1 kayıt silmesi için şart eklenebilir
            return DalUrun.UrunSil(p);
        } //Urun Sil
    }
}
