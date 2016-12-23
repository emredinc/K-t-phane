using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace KitapTakipSistemiBoot
{
    public partial class Default : System.Web.UI.Page
    {
        static Baglanti con = new Baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string Listele(int id)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("select k.id,k.ad,k.Resim,y.yazarAd,y.yazarSoyad from Kitap k join Kategori g on k.kategoriId=g.katId join Yazar y on y.yazarId=k.yazarId where g.katId=@id ", con.baglan());
            adapt.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable table = new DataTable();
            adapt.Fill(table);
            return JsonConvert.SerializeObject(table, Formatting.Indented);
        }

        [WebMethod]
        public static string Arama(string kelime)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("select k.id,k.ad,k.Resim,y.yazarAd,y.yazarSoyad from Kitap k join Kategori g on k.kategoriId=g.katId join Yazar y on y.yazarId=k.yazarId where k.ad like '%" + kelime + "%'", con.baglan());
            DataTable table = new DataTable();
            adapt.Fill(table);
            return JsonConvert.SerializeObject(table, Formatting.Indented);
        }
    }
}