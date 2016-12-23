using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KitapTakipSistemiBoot
{
    public class Baglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection con = new SqlConnection("Server=.;Database=kutuphaneTakip;Trusted_Connection=True;");
            con.Open();
            SqlConnection.ClearPool(con);
            SqlConnection.ClearAllPools();
            return (con);
        }
    }
}