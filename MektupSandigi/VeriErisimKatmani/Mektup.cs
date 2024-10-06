using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Mektup
    {
        public int MektupID { get; set; }
        public int KullaniciID { get; set; }

        public int KategoriID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string AliciMail { get; set; }

        public DateTime GonderimTarihi { get; set; }
        public DateTime AcilisTarihi { get; set; }

        public bool TeslimEdildiMi { get; set; }

        public DateTime OlusturmaTarihi { get; set; }

    }
}
