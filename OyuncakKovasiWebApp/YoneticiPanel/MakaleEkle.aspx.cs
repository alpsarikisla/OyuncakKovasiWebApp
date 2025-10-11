using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;
using System.IO;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = vm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void btn_makaleEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text))
            {
                Makale mak = new Makale();
                mak.Baslik = tb_baslik.Text;
                mak.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                //Yonetici y = (Yonetici)Session["yonetici"];
                //mak.YazarID = y.ID;
                mak.YazarID = ((Yonetici)Session["yonetici"]).ID;
                mak.EklemeTarihi = DateTime.Now;
                mak.GoruntulemeSayi = 0;
                mak.SilinmisMi = false;
                mak.AktifMi = cb_AktifMi.Checked;
                mak.Ozet = tb_ozet.Text;
                mak.Icerik = tb_icerik.Text;
                if (fu_resim.HasFile)//fu_resim kontrolünde dosya seçilmiş ise
                {
                    FileInfo dosya = new FileInfo(fu_resim.FileName);
                    string uzanti = dosya.Extension;//.jpg
                    if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png")
                    {
                        string name = Convert.ToString(Guid.NewGuid());
                        string fullname = name + uzanti;
                        mak.KapakResim = fullname;
                        fu_resim.SaveAs(Server.MapPath("../MakaleResimleri/" + fullname));
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_hataMesaj.Text = "Dosya Formatı Geçersiz. jpg, jpeg, png dosyası yükleyiniz";
                    }
                }
                else
                {
                    mak.KapakResim = "resimyok.png";
                }
                if (vm.MakaleEkle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_hataMesaj.Text = "Makale eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_hataMesaj.Text = "Başlık boş bırakılamaz";
            }
        }
    }
}