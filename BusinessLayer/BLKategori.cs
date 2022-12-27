using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLKategori
    {
        public static int BLKategoriEkle (kategori p)
        {
            if(p.KategoriAdi!=null && p.KategoriAdi.Length>=2 && p.KategoriAdi.Length<=30) //Kategori adı boş olmamalı 2 den kısa ve 30 dan uzun olmamalı
            {
                return DalKategori.KategoriEkle(p); //şartlar sağlanıyor ise Data accses layer da urun ekle metotu döndür
            }
            return -1; //şartlar sağlanmıyor ise hiçbir şey yapma döndürme bişi

        }
    }
}
