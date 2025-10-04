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

        #endregion
    }
}
