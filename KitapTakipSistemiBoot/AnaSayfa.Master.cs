using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitapTakipSistemiBoot
{
    public partial class AnaSayfa : System.Web.UI.MasterPage
    {
         Baglanti con = new Baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Kategori kat = new Kategori();
            kat.KategoriGetir(Repeater1);

            SqlDataAdapter adapt = new SqlDataAdapter("select * from Kitap", con.baglan());
       
            DataTable table = new DataTable();
            adapt.Fill(table);
            Repeater3.DataSource = table;
            Repeater2.DataSource = table;
            Repeater2.DataBind();
            Repeater3.DataBind();


        }
    }
}