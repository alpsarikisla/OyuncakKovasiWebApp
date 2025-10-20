using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp
{
    public partial class GirisYap : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            string mail = tb_mail.Text;
            string sifre = tb_sifre.Text;
            Uye u = vm.GirisYap(mail, sifre);
            if (u != null)
            {
                Session["uye"] = u;
                Response.Redirect("Default.aspx");
            }
        }
    }
}