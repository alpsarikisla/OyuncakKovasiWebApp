using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makaleler.DataSource = vm.MakaleListele(0);
            lv_makaleler.DataBind();
        }
    }
}