using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class DestekTalep
    {
        public int DestekID { get; set; }
        public int KullaniciID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
    }
}
