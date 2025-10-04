using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class KategoriListeleGridView : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            gv_kategoriler.DataSource = vm.KategoriListele();
            gv_kategoriler.DataBind();
            gv_kategoriSinirliKolon.DataSource = vm.KategoriListele();
            gv_kategoriSinirliKolon.DataBind();
        }
    }
}