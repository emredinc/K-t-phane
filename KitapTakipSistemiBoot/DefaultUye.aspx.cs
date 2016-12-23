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
    public partial class DefaultUye : System.Web.UI.Page
    {
        static Baglanti con = new Baglanti();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        [WebMethod]
        public static string UyeBilgi(string Kad)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Uyeler where Mail=@Kad", con.baglan());
            adapt.SelectCommand.Parameters.AddWithValue("Kad", Kad);
            DataTable table = new DataTable();
            adapt.Fill(table);
            return JsonConvert.SerializeObject(table, Formatting.Indented);
        }
    }
}