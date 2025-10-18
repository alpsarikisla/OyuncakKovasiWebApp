using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_makaleler.DataSource = vm.MakaleListele(0);
            rp_makaleler.DataBind();
        }
    }
}