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
        public static int BLUrunEkle (urun p)
        {
            if (p.Adi != null && p.Adi.Length >= 2 && p.Adi.Length <= 30 )
            {
                return DalUrun.UrunEkle(p);
            }
            return -1;

        }
    }
}
