<%@ Page Title="" Language="C#" MasterPageFile="~/Siter.Master" AutoEventWireup="true"
    CodeBehind="caGastos.aspx.cs" Inherits="Mobiviaria.View.GestionarInventario" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function DoPostBack(_name) {
            __doPostBack(_name, 'My Argument');
        }
        function abrirModalMapa() {
            $('#ModalMapa').modal('show');
        }
        function cerrarModalMapa() {
            $('#ModalMapa').modal('hide');
        }
        function abrirModalFoto() {
            $('#ModalFoto').modal('show');
        }
        function cerrarModalFoto() {
            $('#ModalFoto').modal('hide');
        }
    </script>
    <style>
        .textbutton {
            margin-left: 0;
            padding-left: 0;
            padding-right: 0;
            margin-top: 12px;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePageMethods="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="content-wrapper">
            <header class="content-header">
                <h1>Gestionar Inventario</h1>
                <ol class="breadcrumb">
                    <li><i class="fa fa-dashboard"></i>Inicio</li>
                    <li>Gestionar Inventario</li>
                </ol>
            </header>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-solid">
                            <div class="box-header with-border">
                                <i class="fa fa-filter"></i>
                                <h3 class="box-title">Filtros</h3>
                                <div class="box-tools pull-right">
                                    <button class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-xs-12 col-md-3">
                                            <div class="form-group">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <label>Tramo</label>
                                                        <asp:DropDownList ID="cboTramo" CssClass="form-control input-sm" Style="width: 100%;" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ID="vcboTramo" runat="server"
                                                            ControlToValidate="cboTramo" SetFocusOnError="True"
                                                            CssClass="alert-text"></asp:CustomValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-md-3">
                                            <div class="form-group">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <label>Carretera</label>
                                                        <asp:DropDownList ID="cboCarretera" CssClass="form-control input-sm" Style="width: 100%;" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ID="vcboCarretera" runat="server"
                                                            ControlToValidate="cboCarretera" SetFocusOnError="True"
                                                            CssClass="alert-text"></asp:CustomValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-md-3">
                                        </div>
                                        <div class="col-xs-12 col-md-3">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <%-- <label>&nbsp</label><br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btn btn-primary btn-block btn-sm"
                                                                OnClick="btnAdicionar_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>&nbsp</label><br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block btn-sm"
                                                                OnClick="btnBuscar_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>&nbsp</label><br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-block btn-sm"
                                                                OnClick="BtnReset_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-solid input-group-sm">
                            <div class="box-header with-border">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <i class="fa fa-database"></i>
                                        <asp:Label ID="lbResultado" runat="server" CssClass="box-title" Text="Resultados"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="box-tools pull-right">
                                    <button class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>

                                </div>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box-body">
                                            <div id="example1_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                                <div class="row">
                                                    <div class="col-sm-12" style="overflow: auto;">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DataGrid ID="dgDatos" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    Width="100%" class="table table-bordered table-hover dataTable" role="grid" AllowPaging="True"
                                                                    OnPageIndexChanged="dgDatos_PageIndexChanged" OnItemCommand="dgDatos_ItemCommand">
                                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                                        Font-Strikeout="False" Font-Underline="False" />
                                                                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" Position="Top" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn HeaderText="Acciones">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" CommandName="VER" ImageUrl="~/iconos/see.png"
                                                                                    Height="16px" ToolTip="Ver" />
                                                                                <asp:ImageButton runat="server" CommandName="FOTO" ImageUrl="~/iconos/photo.png"
                                                                                    Height="16px" ToolTip="Foto" />
                                                                                <asp:ImageButton runat="server" CommandName="MAPA" ImageUrl="~/iconos/maps.png"
                                                                                    Height="16px" ToolTip="Mapa" />
                                                                                <asp:ImageButton runat="server" CommandName="ELIMINAR" ImageUrl="~/iconos/android-trash.png"
                                                                                    Height="16px" ToolTip="Eliminar" OnClientClick="return confirm('Está Seguro que desea eliminar el registro?');" />
                                                                            </ItemTemplate>
                                                                            <FooterStyle Font-Bold="False" />
                                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateColumn>
                                                                        <asp:BoundColumn DataField="idinventario" HeaderText="idinventario" Visible="False"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="idcuadrilla" HeaderText="idcuadrilla"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="idtramo" HeaderText="idtramo"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="idcarretera" HeaderText="idcarretera"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="fecha_proceso" HeaderText="Fecha Proceso" DataFormatString="{0:d}"></asp:BoundColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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
                <div id="ModalMapa" class="modal" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="modal-header">
                                        <asp:Label class="control-label" runat="server">Registrar Gastos</asp:Label>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-lg-12 col-xs-12">
                                                <div class="form-group">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <cc:GMap ID="GMap1" runat="server" />

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-xs-12">
                                            </div>
                                            <div class="col-lg-6 col-xs-12">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-xs-12">
                                                <div class="form-group">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnModalCerrar" runat="server" Text="Cerrar" CssClass="btn btn-primary  btn-sm pull-left"
                                            OnClick="btnModalCerrar_Click" />
                                        <%--<asp:Button ID="btnModalAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary  btn-sm pull-right"
                                            OnClick="btnModalAceptar_Click" />--%>
                                    </div>
                                    </div>																
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
                <div id="ModalFoto" class="modal" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="modal-header">
                                        <asp:Label class="control-label" runat="server">Fotografia de la Fisura</asp:Label>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">

                                            <div class="col-lg-12 col-xs-12">
                                                <div class="form-group">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Image ID="imgImagen" ImageUrl="~/images/image2.jpg" runat="server">

                                                            </asp:Image>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnModalNewGastoCerrar" runat="server" Text="Cerrar" CssClass="btn btn-primary  btn-sm pull-left"
                                            OnClick="btnModalNewGastoCerrar_Click" />
                                        <asp:Button ID="btnModalNewGastoAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary  btn-sm pull-right"
                                            OnClick="btnModalNewGastoAceptar_Click" />
                                    </div>
                                    </div>																
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hf_idEmpresa" Value="0" runat="server" />
            </section>
        </div>
    </form>
</asp:Content>
