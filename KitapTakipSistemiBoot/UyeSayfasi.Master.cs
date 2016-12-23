using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitapTakipSistemiBoot
{
    public partial class UyeSayfasi : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Kategori kat = new Kategori();
            kat.KategoriGetir(Repeater1);
        }
    }
}