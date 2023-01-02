using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class log
    {
        public int ID { get; set; }
        public int PersonelID { get; set; }
        public DateTime Tarih { get; set; }
        public string Islem { get; set; }
        public string IpAdresi { get; set; }
        public string PersonelAdi { get; set; }
    }
}
