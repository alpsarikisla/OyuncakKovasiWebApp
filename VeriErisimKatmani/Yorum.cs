using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Yorum
    {
        public int ID { get; set; }
        public int MakaleID { get; set; }
        public int UyeID { get; set; }
        public string Uye { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public string TarihStr { get; set; }
        public bool Yayinla { get; set; }
        public string YayinlaStr { get; set; }
    }
}
