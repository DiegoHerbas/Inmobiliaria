<%@ Page Title="" Language="C#" MasterPageFile="~/Siter.Master" AutoEventWireup="true" CodeBehind="sgGestionarUsuario.aspx.cs" Inherits="Mobiviaria.sgGestionarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePageMethods="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="content-wrapper">
            <header class="content-header">
                <h1>Gestionar Usuarios</h1>
                <ol class="breadcrumb">
                    <li><i class="fa fa-dashboard"></i>Inicio</li>
                     <li>Seguridad</li>
                    <li>Gestionar Usuarios</li>
                   
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
                                                <label class="control-label">Grupo Usuario</label>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="cboGrupoUsuario" CssClass="form-control select2 input-sm"
                                                            Style="width: 100%;" AutoPostBack="true" placeholder="Grupo de usuario" runat="server">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-md-3">
<%--                                            <div class="form-group">
                                                <label class="control-label">Nombre Completo</label>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtNombreCompleto" CssClass="form-control input-sm" Style="width: 100%;"
                                                            placeholder="Nombre Completo" runat="server" AutoPostBack="false"
                                                            autocomplete="off" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>--%>
                                        </div>
                                        <div class="col-xs-12 col-md-3">
                                           <%-- <div class="form-group">
                                                <label class="control-label">Nombre de Usuario</label>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control input-sm"
                                                            Style="width: 100%;" AutoPostBack="true" placeholder="Nombre de usuario"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>--%>
                                        </div>
                                        <div class="col-xs-12 col-md-3">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label>&nbsp</label><br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnAdd" runat="server" Text="Adicionar" CssClass="btn btn-primary btn-block btn-sm" OnClick="btnAdd_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>&nbsp</label><br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block btn-sm" OnClick="btnSearch_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>&nbsp</label><br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="btn btn-primary btn-block btn-sm" OnClick="BtnReset_Click" />
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
                                                                <asp:DataGrid ID="dgDatos" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" Width="100%" 
                                                                    class="table table-bordered table-hover dataTable" role="grid" AllowPaging="True" 
                                                                    OnPageIndexChanged="dgDatos_PageIndexChanged" OnItemCommand="dgDatos_ItemCommand" OnItemDataBound="dgDatos_ItemDataBound">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" Position="Top" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn HeaderText="Acciones">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" CommandName="MODIFICAR" ImageUrl="~/iconos/compose.png" Height="16px" ToolTip="Modificar" />
                                                                                <asp:ImageButton runat="server" CommandName="ELIMINAR" ImageUrl="~/iconos/android-trash.png" Height="16px" ToolTip="Eliminar" OnClientClick="return confirm('Está Seguro que desea eliminar el registro?');" />
                                                                            </ItemTemplate>
                                                                            <FooterStyle Font-Bold="False" />
                                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateColumn>
                                                                        <asp:BoundColumn DataField="idusuario" HeaderText="Id Usuario" Visible="false"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="idGrupoUsuario" HeaderText="id_grupousuario" Visible="false"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="tipoUsuario" HeaderText="Tipo Usuario"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="nombreCompleto" HeaderText="Nombre completo"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="nombreUsuario" HeaderText="Usuario"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="fecha_valides" HeaderText="fecha_valides" DataFormatString="{0:d}"></asp:BoundColumn>
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
            </section>
        </div>
    </form>
</asp:Content>
