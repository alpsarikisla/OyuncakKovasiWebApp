using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_kategoriEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori kat = new Kategori();
                kat.Isim = tb_isim.Text;
                kat.Durum = cb_durum.Checked;
                if (vm.KategoriEkle(kat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_hataMesaj.Text = "Kategori Adı Boş Bırakılamaz";
            }
        }
    }
}