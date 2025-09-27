using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["yonetici"];
                lbl_kullanici.Text = y.KullaniciAdi;
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }
    }
}