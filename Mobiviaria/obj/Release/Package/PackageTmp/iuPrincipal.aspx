<%@ Page Title="" Language="C#" MasterPageFile="~/Siter.Master" AutoEventWireup="true" CodeBehind="iuPrincipal.aspx.cs" Inherits="Mobiviaria.iuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:ScriptManager EnablePageMethods="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="content-wrapper">
      <header class="content-header">
        <asp:Label ID="lbTitle" CssClass="text text-uppercase" runat="server" Text="" Font-Size="X-Large"></asp:Label>
      </header>
      <section class="content">
        <div class="row">
          <div class="col-md-12">
            <div class="box box-solid">
              <div class="box-header with-border">
                <i class="fa fa-edit"></i>
                <asp:Label ID="Label1" runat="server" Text="Bienvenido " Font-Size="X-Large"></asp:Label>
                <div class="box-tools pull-right">
                  <button class="btn btn-box-tool" data-widget="collapse">
                    <i class="fa fa-minus"></i>
                  </button>
                </div>
              </div>
              <div class="box-body">
              <div class="row" id="divAdvertencia" runat="server">
                <div class="col-md-12">
                   <asp:Label id="advertencia" runat="server" Text="" Font-Size="Large" Font-Bold="true" Style="padding-left:27px;" CssClass="text-red"></asp:Label>
                </div>
              </div>                 
              </div>
            </div>
          </div>
          </div>
      </section>
      <footer>
      </footer>
    </div>
  </form>
</asp:Content>
