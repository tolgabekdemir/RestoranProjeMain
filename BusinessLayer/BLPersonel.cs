using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLPersonel
    {
        public static int BLPersonelEkle(personel p)
        {
            if (p.Ad != null && p.Ad.Length >= 2 && p.Ad.Length <= 30)
            {
                return DalPersonel.PersonelEkle(p);
            }
            return -1;
        } //Personel ekle
        public static List<personel> BLPersonelListesi()
        {
            return DalPersonel.PersonelListesi();
        } //Personel Listele
        public static int BLPersonelGuncelle(personel p)
        {
            if (p.Ad != null && p.Ad.Length >= 2 && p.Ad.Length <= 30)
            {
                return DalPersonel.PersonelGuncelle(p);
            }
            return -1;
        } //Personel Güncelle
        public static int BLPersonelSil(personel p)
        {
            //sadece 1 kayıt silmesi için şart eklenebilir
                return DalPersonel.PersonelSil(p); 
        } //Personel Sil
    }
}
