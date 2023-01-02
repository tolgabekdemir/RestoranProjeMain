using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLog
    {
        public static int BLLogEkle(log p)
        {
            if ( p.IpAdresi != null && p.Islem != null)
            {
                return DalLog.LogEkle(p);
            }
            return -1;
        } //Log ekle
    }
}
