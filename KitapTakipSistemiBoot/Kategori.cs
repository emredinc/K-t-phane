using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KitapTakipSistemiBoot
{
    public class Kategori
    {
        Baglanti con = new Baglanti();
        public void KategoriGetir(Repeater baglayici) {
            SqlDataAdapter adapt1 = new SqlDataAdapter("select * from Kategori ", con.baglan());
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            baglayici.DataSource = table1;
            baglayici.DataBind();
        }
    }
}