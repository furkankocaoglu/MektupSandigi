using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Yorumlar
    {
        public int YorumID { get; set; }
        public int MektupID { get; set; }
        public int KullaniciID { get; set; }
        public string YorumIcerik { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Onay { get; set; }
        public bool Durum { get; set; }

    }
}
