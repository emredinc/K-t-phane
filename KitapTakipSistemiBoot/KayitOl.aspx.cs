using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitapTakipSistemiBoot
{
    public partial class KayitOl : System.Web.UI.Page
    {
        static Baglanti con = new Baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void Kayit(string ad, string soyad, string Kad, string sifre)
        {

           
            SqlCommand komut = new SqlCommand("insert into Uyeler values(@ad,@soyad,@durum,@mail,@sifre)", con.baglan());
            komut.Parameters.AddWithValue("ad", ad);
            komut.Parameters.AddWithValue("soyad", soyad);
            komut.Parameters.AddWithValue("durum", 1);
            komut.Parameters.AddWithValue("mail", Kad);
            komut.Parameters.AddWithValue("sifre", sifre);
            komut.ExecuteNonQuery();

        }
        [WebMethod]
        public static string KayitVarMi(string Kad)
        {

            SqlDataAdapter adapt = new SqlDataAdapter("select * from Uyeler where mail=@Kad", con.baglan());
            adapt.SelectCommand.Parameters.AddWithValue("Kad", Kad);
            DataTable table = new DataTable();
            adapt.Fill(table);
            return JsonConvert.SerializeObject(table, Formatting.Indented);


        }
    }
}