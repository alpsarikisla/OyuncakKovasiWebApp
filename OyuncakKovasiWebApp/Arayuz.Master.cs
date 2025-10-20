using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp
{
    public partial class Arayuz : System.Web.UI.MasterPage
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = vm.AktifKategoriListele();
            rp_kategoriler.DataBind();
            if (Session["uye"] == null)//Üye girişi yok ise
            {
                pnl_girisVar.Visible = false;
                pnl_girisyok.Visible = true;
            }
            else
            {
                pnl_girisVar.Visible = true;
                pnl_girisyok.Visible = false;
                Uye u = (Uye)Session["uye"];
                lbl_uye.Text = u.KullaniciAdi + "(" + u.Isim + " " + u.Soyisim + ")";
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}