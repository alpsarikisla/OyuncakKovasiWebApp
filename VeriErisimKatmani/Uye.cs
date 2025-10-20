using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Uye
    {
      
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string sifre { get; set; }
        public bool AktifMi { get; set; }
        public string AktifMiStr { get; set; }
    }
}
