using System;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        protected void lv_kategoriler_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            //Response.Write("<script>alert('Tıklandı')</script>");
            int id = Convert.ToInt32(e.CommandArgument);
            vm.KategoriDurumDegistir(id);
            Doldur();
        }
        private void Doldur()
        {
            lv_kategoriler.DataSource = vm.KategoriListele();
            lv_kategoriler.DataBind();
        }
    }
}