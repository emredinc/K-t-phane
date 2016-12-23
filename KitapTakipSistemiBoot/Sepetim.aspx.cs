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

    public partial class Sepetim : System.Web.UI.Page
    {
        static Baglanti con = new Baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string Sepet(string id)
        {
            SqlDataAdapter adtr = new SqlDataAdapter(" select k.id as KitapId ,uyeId,s.id,isbn,k.ad,sayfaSayisi,Resim,y.yazarAd,y.yazarSoyad from Sepet s join Kitap k on k.id=s.kitapId  join Uyeler u on u.id=s.uyeId join Yazar y on  y.yazarId = k.yazarId Where u.Mail = @mail ", con.baglan());
            adtr.SelectCommand.Parameters.AddWithValue("mail", id);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            return JsonConvert.SerializeObject(dt, Formatting.Indented);



        }
    }
}