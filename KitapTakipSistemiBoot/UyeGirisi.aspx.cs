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
    public partial class UyeGirisi : System.Web.UI.Page
    {
       static Baglanti con = new Baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod]
        public static string GirisYap(string ad,string sifre)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Uyeler where Mail=@mail and Sifre=@Sifre", con.baglan());
            adapt.SelectCommand.Parameters.AddWithValue("mail", ad);
            adapt.SelectCommand.Parameters.AddWithValue("Sifre", sifre);
            DataTable table = new DataTable();
            adapt.Fill(table);
            return JsonConvert.SerializeObject(table, Formatting.Indented);
        }

    
    }
}