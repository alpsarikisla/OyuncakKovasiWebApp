using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModel
    {
        SqlConnection con; SqlCommand cmd;
        public VeriModel()
        {
            con = new SqlConnection(BaglantiYollari.BaglantiYolu);
            cmd = con.CreateCommand();
        }

        #region Yönetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi != 0)
                {
                    cmd.CommandText = "SELECT Y.ID, Y.YoneticiTurID, YT.Isim, Y.Isim, Y.Soyisim, Y.Mail, Y.Sifre, Y.KullaniciAdi, Y.AktifMi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTurID= YT.ID WHERE Y.Mail=@m AND Y.Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.YoneticiTur = reader.GetString(2);
                        y.Isim = reader.GetString(3);
                        y.Soyisim = reader.GetString(4);
                        y.Mail = reader.GetString(5);
                        y.Sifre = reader.GetString(6);
                        y.KullaniciAdi = reader.GetString(7);
                        y.AktifMi = reader.GetBoolean(8);

                    }
                    return y;
                }
                return null;
            }
            catch { return null; }
            finally { con.Close(); }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim,AktifMi) VALUES(@isim,@aktifMi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aktifMi", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, AktifMi FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                    if (kat.Durum)
                    {
                        kat.DurumStr = "Aktif";
                    }
                    else
                    {
                        kat.DurumStr = "Pasif";
                    }

                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch { return null; }
            finally { con.Close(); }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT AktifMi FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Kategoriler Set AktifMi = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim, AktifMi=@aktifmi WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aktifmi", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori kategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Isim,AktifMi FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori kat = null;
                while (reader.Read())
                {
                    kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(YazarID,KategoriID,Baslik,Icerik,Ozet,KapakResim,GoruntulemeSayi,EklemeTarihi,SilinMisMi,AktifMi) VALUES(@yazarID,@kategoriID,@baslik,@icerik,@ozet,@kapakResim,@goruntulemeSayi,@eklemeTarihi,@silinMisMi,@aktifMi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yazarID", mak.YazarID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                cmd.Parameters.AddWithValue("@silinMisMi", mak.SilinmisMi);
                cmd.Parameters.AddWithValue("@aktifMi", mak.AktifMi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Silinme Durumuna göre Makaleleri listeler
        /// </summary>
        /// <param name="silinmeDurum">
        /// 1 silinmiş olan makaleleri listeler
        /// 0 silinmemiş olan makaleleri listeler
        /// -1 tüm makaleleri listeler
        /// </param>
        /// <returns>Makale Koleksiyonu döndürür</returns>
        public List<Makale> MakaleListele(int silinmeDurum)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                string Query = "SELECT M.ID,M.YazarID, Y.KullaniciAdi,M.KategoriID, K.Isim, M.Baslik,M.Icerik,M.Ozet,M.KapakResim,M.GoruntulemeSayi,M.EklemeTarihi,M.SilinmisMi,M.AktifMi FROM Makaleler AS M JOIN Yoneticiler AS Y ON M.YazarID = Y.ID JOIN Kategoriler AS K ON M.KategoriID = K.ID";
                if (silinmeDurum == -1)
                {
                    cmd.CommandText = Query;
                }
                else if(silinmeDurum == 1)
                {
                    cmd.CommandText = Query + " WHERE M.SilinmisMi = 1";
                }
                else if (silinmeDurum == 0)
                {
                    cmd.CommandText = Query +" WHERE M.SilinmisMi = 0";
                }
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.YazarID = reader.GetInt32(1);
                    mak.Yazar = reader.GetString(2);
                    mak.KategoriID = reader.GetInt32(3);
                    mak.KategoriAdi = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    if (!reader.IsDBNull(6)) { mak.Icerik = reader.GetString(6); }
                    if (!reader.IsDBNull(7)) { mak.Ozet = reader.GetString(7); }
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.EklemeTarihi = reader.GetDateTime(10);
                    mak.SilinmisMi = reader.GetBoolean(11);
                    mak.AktifMi = reader.GetBoolean(12);
                    mak.AktifMiStr = reader.GetBoolean(12) ? "Aktif" : "Pasif";
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
               cmd.CommandText=  "SELECT M.ID,M.YazarID, Y.KullaniciAdi,M.KategoriID, K.Isim, M.Baslik,M.Icerik,M.Ozet,M.KapakResim,M.GoruntulemeSayi,M.EklemeTarihi,M.SilinmisMi,M.AktifMi FROM Makaleler AS M JOIN Yoneticiler AS Y ON M.YazarID = Y.ID JOIN Kategoriler AS K ON M.KategoriID = K.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale mak = null;
                while (reader.Read())
                {
                    mak= new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.YazarID = reader.GetInt32(1);
                    mak.Yazar = reader.GetString(2);
                    mak.KategoriID = reader.GetInt32(3);
                    mak.KategoriAdi = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    if (!reader.IsDBNull(6)) { mak.Icerik = reader.GetString(6); }
                    if (!reader.IsDBNull(7)) { mak.Ozet = reader.GetString(7); }
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.EklemeTarihi = reader.GetDateTime(10);
                    mak.SilinmisMi = reader.GetBoolean(11);
                    mak.AktifMi = reader.GetBoolean(12);
                    mak.AktifMiStr = reader.GetBoolean(12) ? "Aktif" : "Pasif";
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleDuzenle(Makale mak)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET Baslik = @baslik, KategoriID = @kategoriId, Ozet=@ozet,Icerik=@icerik, KapakResim=@kapakresim, AktifMi=@aktifmi WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@kategoriId", mak.KategoriID);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakresim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@aktifmi", mak.AktifMi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
