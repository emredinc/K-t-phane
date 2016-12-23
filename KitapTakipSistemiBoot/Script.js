function Getir(gelen) {
    var kat = document.getElementById("kategoriResim")
    kat.innerHTML = "";
    $.ajax({
        url: "Default.aspx/Listele",
        type: "post",
        contentType: "application/json",
        dataType: "json",
        data: "{id:'" + gelen + "'}",
        success: function (result) {

            var data = JSON.parse(result.d);

            for (var i = 0; i < data.length; i++) {
                var urunDivtopla = "";
                urunDivtopla += "  <div class='col-lg-3 col-md-3 col-xs-6 col-sm-6'><div class='whitebox'><div class='content'> <a href='#'>  <img src='" + 'image/' + data[i].Resim + "' class='img-responsive' /></a></div> <div class='whitebox-footer'> <div class='row text-center'>  <div class='col-lg-12'>'" + data[i].ad + "' </div>   </div>  <div class='row text-center'>    <div class='col-lg-12'>'" + data[i].yazarAd + "'</div>  </div>  <div class='row text-center'>  <div class='col-lg-12'> ";

                if (window.sessionStorage.getItem("giris") != null) {

                    urunDivtopla += "<button type='button' class='btn btn-default inceleBtn'>Sepete Ekle</button>  </div>    </div>  </div>  </div>   </div>";
                }
                else {
                    urunDivtopla += "<button type='button' class='btn btn-default inceleBtn'>incele</button>  </div> </div></div>  </div>   </div>";
                }
                kat.innerHTML += urunDivtopla;
                urunDivtopla = "";

            }


        }
    })
}
function UyeGirisSayfasi() {
    window.location = "UyeGirisi.aspx";
}
function KayitOlSayfasi() {
    window.location = "KayitOl.aspx";
}
function KitapAra() {
    var kat = document.getElementById("kategoriResim")
    var kelime = document.getElementById("txtKitap").value
    if (kelime == "") {
        alert("Lütfen Bir Kelime Giriniz...");
    }
    else {


        kat.innerHTML = "";
        $.ajax({
            url: "Default.aspx/Arama",
            type: "post",
            contentType: "application/json",
            dataType: "json",
            data: "{kelime:'" + kelime + "'}",
            success: function (result) {
                var data = JSON.parse(result.d);
                var urunDivtopla = "";
                if (data.length == 0) {
                    alert("Aramak İstediğiniz Kitap Bulunamadı");
                }
                for (var i = 0; i < data.length; i++) {
                    urunDivtopla += "  <div class='col-lg-3 col-md-3 col-xs-6 col-sm-6'><div class='whitebox'><div class='content'> <a href='#'>  <img src='" + 'image/' + data[i].Resim + "' class='img-responsive' /></a></div> <div class='whitebox-footer'> <div class='row text-center'>  <div class='col-lg-12'>'" + data[i].ad + "' </div>   </div>  <div class='row text-center'>    <div class='col-lg-12'>'" + data[i].yazarAd + "'</div>  </div>  <div class='row text-center'>  <div class='col-lg-12'>  <button type='button' class='btn btn-default inceleBtn'>incele</button>  </div>    </div>  </div>  </div>   </div>";
                    kat.innerHTML += urunDivtopla;
                    urunDivtopla = "";
                }

            },
            error: function () {
                alert("Bağlantı Hatası");
            }
        })
    }
}
function Giris() {
    var ad1 = document.getElementById("txtad").value
    var sifre2 = document.getElementById("txtsifre").value
    $.ajax({
        url: "UyeGirisi.aspx/GirisYap",
        type: "post",
        contentType: "application/json",
        dataType: "json",
        data: "{ad:'" + ad1 + "', sifre:'" + sifre2 + "'}",
        success: function (result) {
            var data = JSON.parse(result.d);

            if (data.length > 0) {
                window.sessionStorage.setItem("giris", data[0].Mail);
                window.location = ("DefaultUye.aspx");
            }
            else {
                alert("Giriş Başarısız");
            }

        },
        error: function () {
            alert("Bağlantı Hatası");
        }
    })


}
function UyeBilgi() {
    $(document).ready(function () {

        var sessionBak = window.sessionStorage.getItem("giris");
        if (sessionBak != null) {
            $.ajax({
                url: "DefaultUye.aspx/UyeBilgi",
                type: "post",
                contentType: "application/json",
                dataType: "json",
                data: "{Kad:'" + sessionBak + "'}",
                success: function (result) {
                    var data = JSON.parse(result.d);

                    var isim = document.getElementById("name")
                    isim.innerHTML = data[0].Ad + " " + data[0].Soyad;

                },
                error: function () {
                    alert("Bağlantı Hatası");
                }
            })
        }
        else {
            alert("Giriş Yapılmadı.");
        }
    })


}
function Cikis() {
    window.sessionStorage.removeItem("giris");
    window.location = "Default.aspx";
}
function KayitOl() {
    if (KayitVarMi()==false) {
        var ad = document.getElementById("txtad").value
        var soyad = document.getElementById("txtSoyad").value
        var Kad = document.getElementById("txtKad").value
        var sifre = document.getElementById("txtSifre").value
        $.ajax({
            url: 'KayitOl.aspx/Kayit',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: "{ad:'" + ad + "',soyad:'" + soyad + "',Kad:'" + Kad + "',sifre:'" + sifre + "'}",
            success: function () {
                window.sessionStorage.setItem("giris", Kad);
                window.location = ("DefaultUye.aspx");
            },
            error: function () {
                alert("baglantı hatası");
            }

        })
    }
    else {
        alert("kayıt var");
        window.location = ("Default.aspx");

    }

  
 

}
function KayitVarMi() {
    var bool = false;
    var Kad = document.getElementById("txtKad").value
    var sifre = document.getElementById("txtSifre").value
    $.ajax({
        url: 'KayitOl.aspx/KayitVarMi',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: "{Kad:'" + Kad + "'}",
        success: function (result) {
            var data = JSON.parse(result.d);
            if (data > 0) {
                bool = true            
                return bool;           
              
            }
            else {
                return bool;
            }
        },
        error: function () {
            alert("baglantı hatası");
        }

    })
}

