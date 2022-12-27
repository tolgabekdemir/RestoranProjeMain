using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class urun
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public int KategoriID { get; set; }
        public decimal Fiyati { get; set; }
        public int Stok { get; set; }
        public DateTime SevkiyatTarihi { get; set; }
    }
}
