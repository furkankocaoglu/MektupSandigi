using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Uyeler
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Durum { get; set; }
        public bool Silinmis { get; set; }
    }
}
