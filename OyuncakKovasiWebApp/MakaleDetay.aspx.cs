using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int makaleid = Convert.ToInt32(Request.QueryString["makaleID"]);
                Makale m = vm.MakaleGetir(makaleid);
                img_resim.ImageUrl = "MakaleResimleri/" + m.KapakResim;
                lbl_baslik.Text = m.Baslik;
                lbl_icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.KategoriAdi;
                ltrl_eklemeTarihi.Text = m.EklemeTarihiStr;
                ltrl_yazar.Text = m.Yazar;
                ltrl_gorntulemeSayi.Text = m.GoruntulemeSayi.ToString();

                pnl_girisVar.Visible = false;
                pnl_GirisYok.Visible = true;

                if (Session["uye"] != null)
                {
                    pnl_girisVar.Visible = true;
                    pnl_GirisYok.Visible = false;
                }
                List<Yorum> onaylilar = vm.OnayliMakaleYorumlari(makaleid);
                pnl_yorumYok.Visible = onaylilar == null ? true : false;
                rp_yorumlar.DataSource = onaylilar;
                rp_yorumlar.DataBind();
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btn_yorumyap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_yorum.Text))
            {
                int makaleid = Convert.ToInt32(Request.QueryString["makaleID"]);

                Uye u = (Uye)Session["uye"];

                Yorum y = new Yorum();
                y.Icerik = tb_yorum.Text;
                y.MakaleID = makaleid;
                y.UyeID = u.ID;
                y.Tarih = DateTime.Now;
                y.Yayinla = false;

                if (vm.YorumYap(y))
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Yorum gönderilirken bir hata ile karşılaşıldı. Lütfen daha sonra tekrar denemeyiniz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Sistem boş yorumlara izin vermemektedir.";
            }
        }
    }
}