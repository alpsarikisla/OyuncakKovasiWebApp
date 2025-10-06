using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                if (!IsPostBack)
                {
                    Kategori kategori = vm.kategoriGetir(id);
                    if (kategori != null)
                    {
                        tb_isim.Text = kategori.Isim;
                        cb_durum.Checked = kategori.Durum;
                    }
                    else
                    {
                        Response.Redirect("KategoriListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void btn_kategoriDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (tb_isim.Text.Length <= 25)
                {
                    Kategori kat = new Kategori();
                    kat.ID = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    kat.Isim = tb_isim.Text;
                    kat.Durum = cb_durum.Checked;
                    if (vm.KategoriDuzenle(kat))
                    {
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_hataMesaj.Text = "Kategori güncellenirken bir hata oluştu";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_hataMesaj.Text = "Kategori adı en fazla 25 karakterden oluşmalıdır";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_hataMesaj.Text = "Kategori adı boş bırakılamaz";
            }
        }
    }
}