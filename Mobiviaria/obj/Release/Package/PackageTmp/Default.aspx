<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="Mobiviaria.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"
        name="viewport" />
    <title>Emozione</title>

    <!-- Google Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700|Lato:400,100,300,700,900' rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="dist/css/animate.css" />
    <!-- Custom Stylesheet -->
    <link rel="stylesheet" href="dist/css/style.css" />
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-box animated fadeInUp">
                <div class="box-header" style="padding-bottom: 5px;">
                    <img class="image user-panel" src="iconos/logo.png" width="220" height="100" style="padding-top: 10px; padding-bottom: 0px;" />
                    <%--<font color='white' size='4'><center><b>EMOZIONE</b></center>--%>
                </div>

                <br />
                <div class="col-md-12">
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <asp:Label CssClass="control-label" runat="server" Text="Ingrese sus datos" ForeColor="#666666" Font-Italic="True" Font-Size="Larger"></asp:Label>
                        </div>

                        <div class="col-md-12">
                            <br />
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-user"></i>
                                </div>
                                
                                        <asp:TextBox CssClass="form-control" ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
                                   
                            </div>
                            <br />
                        </div>

                        <div class="col-md-12">
                            <br />
                            <div class="input-group">

                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                               
                                        <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control" runat="server" placeholder="Contraseña"></asp:TextBox>
                                   
                            </div>
                            <br />
                        </div>
                        <div class="col-md-12">
                            <br />
                            <asp:Button CssClass="btn btn-primary btn-block" ForeColor="White" Text="Aceptar" runat="server" OnClick="btnAceptar_Click" />
                            <br />
                        </div>
                    </div>

                    <br />
                </div>
                <a href="#">
                    <p class="small">Olvidaste tu contraseña?</p>
                </a>
            </div>
        </div>

    </form>
</body>
</html>
