<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="KitapTakipSistemiBoot.KayitOl" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap 101 Template</title>
    <script src="Script.js"></script>
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="style.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>


    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>


    <header class="navbar navbar-inverse">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand pad" href="Default.aspx">
                    <img src="image/14062014095619-sefiller.jpg" alt="EMRE DİNÇ" class="img-circle" width="50" height="50" />

                </a>
            </div>
            <span class="text-info logo hidden-xs"><strong>KÜTÜPHANE SİSTEMİ</strong></span>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <%--   <li class="active"><a href="#">Link <span class="sr-only">(current)</span></a></li>
                    <li><a href="#">Link</a></li>--%>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Kategoriler <span class="caret"></span></a>
                        <ul class="dropdown-menu navbar-inverse">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li><a href="#" onclick="Getir(<%#Eval("katId") %>)"><%#Eval("katAd") %></a></li>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>

                    </li>
                </ul>
                <form class="navbar-form navbar-left">
                    <div class="form-group">
                        <input type="text" class="form-control" placeholder="Aramak İstediğiniz Kitabı Giriniz">
                    </div>
                    <button type="submit" class="btn btn-default">Ara</button>
                </form>
                <ul class="nav navbar-nav navbar-right pad10">
                    <%--     <li><a href="#">Üye Girişi</a></li>
                    <li><a href="#">Kayıt Ol</a></li>--%>
                    <li>
                        <button type="button" class="btn btn-default" onclick="UyeGirisSayfasi()">
                            <span class="glyphicon glyphicon-log-in"></span>Üye Girişi</button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-primary"  onclick="KayitOlSayfasi()">
                            <span class="glyphicon glyphicon-user"></span>Kayıt Ol</button>
                    </li>

                </ul>

            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </header>
    <div class="container" style="background-color: black; color: white; text-align: center;">

        <form>
            <div class="form-group"><strong>ÜYE GİRİŞİ</strong></div>
        </form>
    </div>
    <div class="container" style="background-color: darkgrey;">
        <form style="text-align: center;">
              <div class="form-group">
                <label for="exampleInputEmail1">--Adı--</label>
                <input type="email" class="form-control text-center" id="txtad" placeholder="Adı" style="width: 70%; margin-left: 15%;">
            </div>
              <div class="form-group">
                <label for="exampleInputEmail1">--Soyadı--</label>
                <input type="email" class="form-control text-center" id="txtSoyad" placeholder="Soyadı" style="width: 70%; margin-left: 15%;">
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">--Kullanıcı Adı--</label>
                <input type="email" class="form-control text-center" id="txtKad" placeholder="Kullanıcı Adı" style="width: 70%; margin-left: 15%;">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">--Şifre--</label>
                <input type="password" class="form-control text-center" id="txtSifre" placeholder="Şifre" style="width: 70%; margin-left: 15%;">
            </div>

            <div class="checkbox">
                <label>
                    <input type="checkbox">
                    Beni Hatırla
   
                </label>
            </div>
            <button type="button" onclick="KayitOl()" class="btn btn-default" style="width: 70%; background-color: aliceblue;">Giriş</button>
        </form>
    </div>


</body>
</html>
