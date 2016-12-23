<%@ Page Title="" Language="C#" MasterPageFile="~/UyeSayfasi.Master" AutoEventWireup="true" CodeBehind="Sepetim.aspx.cs" Inherits="KitapTakipSistemiBoot.Sepetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="kategoriResim">
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var sessionBak = window.sessionStorage.getItem("giris")

            var kat = document.getElementById("kategoriResim")
            kat.innerHTML = "";
            if (sessionBak != null) {
                $.ajax({
                    url: "Sepetim.aspx/Sepet",
                    type: "post",
                    contentType: "application/json",
                    dataType: "json",
                    data: "{id:'" + sessionBak + "'}",
                    success: function (result) {
                        var data = JSON.parse(result.d);
                        for (var i = 0; i < data.length; i++) {
                            var urunDivtopla = "";
                            urunDivtopla += "  <div class='col-lg-3 col-md-3 col-xs-6 col-sm-6'><div class='whitebox'><div class='content'> <a href='#'>  <img src='" + 'image/' + data[i].Resim + "' class='img-responsive' /></a></div> <div class='whitebox-footer'> <div class='row text-center'>  <div class='col-lg-12'>'" + data[i].ad + "' </div>   </div>  <div class='row text-center'>    <div class='col-lg-12'>'" + data[i].yazarAd + " " + data[i].yazarSoyad + "'</div>  </div>  <div class='row text-center'>  <div class='col-lg-12'> ";

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
        })



    </script>
</asp:Content>
