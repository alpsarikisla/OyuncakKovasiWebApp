using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        VeriModel model = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_mail.Text.Trim()))
            {
                if(!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Yonetici y = model.YoneticiGiris(tb_mail.Text.Trim(), tb_sifre.Text);
                    if(y != null)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_mesaj.Visible = true;
                        lbl_mesaj.Text = "Kullanıcı bulunamadı";
                    }
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_mesaj.Text = "Şifre Boş Bırakılamaz";
                }
            }
            else
            {
                pnl_mesaj.Visible = true;
                lbl_mesaj.Text = "Mail Boş Bırakılamaz";
            }
        }
    }
}