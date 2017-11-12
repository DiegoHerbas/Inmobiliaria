<%@ Page Title="" Language="C#" MasterPageFile="~/Siter.Master" AutoEventWireup="true" CodeBehind="sgUsuario.aspx.cs" Inherits="Mobiviaria.sgUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <script>
            var loadFile = function (event) {
                var reader = new FileReader();
                reader.onload = function () {
                    var output = document.getElementById('<%= output.ClientID %>');
                    output.src = reader.result;
                };
                reader.readAsDataURL(event.target.files[0]);
            };

            $(window).load(function () {
                $(document).ready(function () {
                    Seleccionartab();
                });
            });

            function Seleccionartab() {
                var idtab = $("#" + '<%= TabName.ClientID %>').val();
        $('.nav-tabs a[href="#' + idtab + '"]').tab('show');
    }
        </script>
        <asp:HiddenField ID="TabName" runat="server" Value="3" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="content-wrapper">
            <header class="content-header">
                <h1>Usuario
                </h1>
                <ol class="breadcrumb">
                    <li><i class="fa fa-dashboard"></i>Inicio</li>
                    <li>Autenticación</li>
                    <li>Usuarios</li>
                </ol>
            </header>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-solid">
                            <div class="box-body">
                                <div>
                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs" role="tablist">
                                        <li role="presentation" class="active"><a href="#1" aria-controls="home" role="tab" data-toggle="tab">USUARIO</a></li>
                                        <%--<li role="presentation"><a href="#2" aria-controls="profile" role="tab" data-toggle="tab">Profile</a></li>
                    <li role="presentation"><a href="#3" aria-controls="messages" role="tab" data-toggle="tab">Messages</a></li>
                    <li role="presentation"><a href="#4" aria-controls="settings" role="tab" data-toggle="tab">Settings</a></li>--%>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="1">
                                            <div class="box box-solid">
                                                <div class="box-header with-border">
                                                    <div class="col-md-6">
                                                        <i class="fa fa-edit"></i>
                                                        <h3 class="box-title">Datos personales</h3>
                                                    </div>
                                                    <div class="box-tools pull-right">
                                                        <button class="btn btn-box-tool" data-widget="collapse">
                                                            <i class="fa fa-minus"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                                <div class="box-body">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label>Id Usuario</label>
                                                                    <asp:TextBox ID="txtIdUsuario" CssClass="form-control input-sm" placeholder="Id usuario" runat="server" Enabled="False"></asp:TextBox>
                                                                    <asp:CustomValidator ID="v_txtIdUsuario" runat="server" CssClass="alert-text" SetFocusOnError="True" ControlToValidate="txtNombreCompleto"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <font color="red">&#x0204e;</font>
                                                                    <label>Nombre completo</label>
                                                                    <asp:TextBox ID="txtNombreCompleto" CssClass="form-control input-sm" placeholder="Nombre completo" runat="server"></asp:TextBox>
                                                                    <asp:CustomValidator ID="v_txtNombreCompleto" runat="server" CssClass="alert-text" SetFocusOnError="True" ControlToValidate="txtNombreCompleto"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <font color="red">&#x0204e;</font>
                                                                    <label>Genero</label>
                                                                    <asp:DropDownList ID="cboGenero" CssClass="form-control input-sm" Style="width: 100%;" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:CustomValidator ID="v_cboGenero" runat="server" ControlToValidate="cboGenero" SetFocusOnError="True" CssClass="alert-text"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="box box-solid">
                                                <div class="box-header with-border">
                                                    <div class="col-md-6">
                                                        <i class="fa fa-edit"></i>
                                                        <h3 class="box-title">Datos del usuario</h3>
                                                    </div>
                                                    <div class="box-tools pull-right">
                                                        <button class="btn btn-box-tool" data-widget="collapse">
                                                            <i class="fa fa-minus"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                                <div class="box-body">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <center>
                                  <Label>FOTO DE PERFIL</Label>
                            <div class="row">
                              <asp:Image ID="output" BorderWidth="1px" Height="205px" Width="205px" runat="server" />
                            </div>                            
                                <span class="btn btn-danger btn-file btn-sm">
                                  subir foto
                                <asp:FileUpload ID="FileUpload2" accept="image/*" runat="server" Width="100px" Style="color: transparent" onchange="loadFile(event)" BorderColor="#3366FF" Font-Size="Medium"></asp:FileUpload>
                                  </span>
															</center>
                                                            </div>
                                                            <div class="col-md-8">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <font color="red">&#x0204e;</font>
                                                                                    <label>Nombre de usuario</label>
                                                                                    <asp:TextBox ID="txtNombreUsuario" CssClass="form-control input-sm" placeholder="Nombre de usuario"
                                                                                        runat="server"></asp:TextBox>
                                                                                    <asp:CustomValidator ID="vtxtNombreUsuario" runat="server" CssClass="alert-text"
                                                                                        Display="Static" SetFocusOnError="True" ControlToValidate="txtNombreUsuario"></asp:CustomValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <font color="red">&#x0204e;</font>
                                                                                    <label>Contraseña</label>
                                                                                    <asp:TextBox ID="txtPasword" Visible="true" Class="form-control input-sm" placeholder="Password" runat="server"></asp:TextBox>
                                                                                    <asp:CustomValidator ID="vtxtPasword" runat="server" CssClass="alert-text"
                                                                                        Display="Static" SetFocusOnError="True" ControlToValidate="txtPasword"></asp:CustomValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <font color="red">&#x0204e;</font>
                                                                                    <label>Grupo de usuario</label>
                                                                                    <asp:DropDownList ID="cboGrupoUsuario" CssClass="form-control input-sm" Style="width: 100%;" runat="server"></asp:DropDownList>
                                                                                    <asp:CustomValidator ID="Validator_cboGrupoUsuario" runat="server" ControlToValidate="cboGrupoUsuario" SetFocusOnError="True" CssClass="alert-text"></asp:CustomValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <font color="red">&#x0204e;</font>
                                                                                    <label class="control-label">Fecha Expiracion de Cuenta</label>
                                                                                    <div class="input-group">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="DtpFechaValides" CssClass="form-control input-append date" ClientIDMode="Static" name="date" runat="server"></asp:TextBox>
                                                                                        <asp:CustomValidator ID="V_DtpFechaValides" runat="server" ControlToValidate="DtpFechaValides" SetFocusOnError="True" CssClass="alert-text"></asp:CustomValidator>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="box-footer">
                                                <asp:Button ID="btnSalir" CssClass="btn btn-danger btn-flat btn-sm pull-left" runat="server" Text="Volver" OnClick="btnSalir_Click" />
                                                <asp:Button ID="btnAceptar" CssClass="btn btn-danger btn-flat btn-sm pull-right" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                                            </div>
                                        </div>
                                        <%--                                        <div role="tabpanel" class="tab-pane fade" id="2">
                                            <div class="box-footer">
                                                <a class="btn btn-primary btn-lg" id="btnReview">Second</a>
                                                <asp:Button ID="Button2" CssClass="btn btn-danger btn-flat btn-sm pull-right" runat="server" Text="Aceptar" OnClick="Button2_Click" />
                                            </div>
                                        </div>--%>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <asp:HiddenField ID="hf_idusuario" Value="0" runat="server" />
        <asp:HiddenField ID="hf_accion" Value="ADICIONAR" runat="server" />
        <asp:HiddenField ID="hf_formulario" Value="0" runat="server" />
    </form>
</asp:Content>
