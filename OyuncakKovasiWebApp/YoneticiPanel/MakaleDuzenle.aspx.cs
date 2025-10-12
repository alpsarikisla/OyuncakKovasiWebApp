using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OyuncakKovasiWebApp.YoneticiPanel
{
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if(!IsPostBack)
                {
                    ddl_kategoriler.DataSource = vm.KategoriListele();
                    ddl_kategoriler.DataBind();
                    Getir();
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        

        protected void btn_makaleDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
                Makale mak = vm.MakaleGetir(id);
                mak.Baslik = tb_baslik.Text;
                mak.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                mak.Ozet = tb_ozet.Text;
                mak.Icerik = tb_icerik.Text;
                mak.AktifMi = cb_AktifMi.Checked;
                if (fu_resim.HasFile)
                {
                    FileInfo dosya = new FileInfo(fu_resim.FileName);
                    string isim = Guid.NewGuid().ToString();
                    string uzanti = dosya.Extension;
                    if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png")
                    {
                        string fullname = isim + uzanti;
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
                if (vm.MakaleDuzenle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    Getir();
                    
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_hataMesaj.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_hataMesaj.Text = "Başlık boş bırakılamaz";
            }
        }
        private void Getir()
        {
            int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
            Makale mak = vm.MakaleGetir(id);
            ddl_kategoriler.SelectedValue = Convert.ToString(mak.KategoriID);
            tb_baslik.Text = mak.Baslik;
            tb_icerik.Text = mak.Icerik;
            tb_ozet.Text = mak.Ozet;
            img_resim.ImageUrl = "../MakaleResimleri/" + mak.KapakResim;
            cb_AktifMi.Checked = mak.AktifMi;
        }
    }
}