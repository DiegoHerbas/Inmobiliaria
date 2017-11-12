using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobiviaria
{
    public partial class Siter : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string antiXsrfTokenValue = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = this.Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                this.antiXsrfTokenValue = requestCookie.Value;
                this.Page.ViewStateUserKey = this.antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                this.antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                this.Page.ViewStateUserKey = this.antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = this.antiXsrfTokenValue
                };

                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }

                this.Response.Cookies.Set(responseCookie);
            }

            this.Page.PreLoad += this.MasterPagePreLoad;
        }

        private void MasterPagePreLoad(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Set Anti-XSRF token
                this.ViewState[AntiXsrfTokenKey] = this.Page.ViewStateUserKey;
                this.ViewState[AntiXsrfUserNameKey] = this.Context.User.Identity.Name ?? string.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)this.ViewState[AntiXsrfTokenKey] != this.antiXsrfTokenValue
                    || (string)this.ViewState[AntiXsrfUserNameKey] != (this.Context.User.Identity.Name ?? string.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    Literal1.Text = @"<ul class=""sidebar-menu"">
                    <li class=""header"">MENU PRINCIPAL</li>";
                    var pagina_actual = Page.AppRelativeVirtualPath.Substring(Page.AppRelativeVirtualPath.LastIndexOf("/"),
                    Page.AppRelativeVirtualPath.Length - Page.AppRelativeVirtualPath.LastIndexOf("/"));
                    var str_menu = string.Empty;
                    var str_menu2 = string.Empty;
                    var bandera = false;

                    var ne_usuario = new neUsuario();
                    var idusuario = Request.Cookies.Get("idUsuarioLogin").Value;
                    var idgrupo_usuario = Request.Cookies.Get("idGrpUserLogin").Value;
                    var usuario = ne_usuario.ObtnerUsuario(idusuario);
                    lblUsuario.Text = usuario.nombreCompleto;
                    lblUsuario1.Text = lblUsuario.Text;
                    byte[] bytes = null;
                    string strBase64 = null;
                    if (usuario.imagen != null)
                    {
                        bytes = usuario.imagen;
                        strBase64 = Convert.ToBase64String(bytes);
                        output.ImageUrl = "data:Image/png;base64," + strBase64;
                        output1.ImageUrl = "data:Image/png;base64," + strBase64;
                    }
                    else
                    {
                        output.ImageUrl = "~/iconos/not.png" + strBase64;
                        output1.ImageUrl = "~/iconos/not.png" + strBase64;
                    }
                    var formulario = ne_usuario.ObtenerPermisoFormulario(idgrupo_usuario, idusuario, "");
                    foreach (var padre in formulario)
                    {
                        bandera = false;
                        str_menu = "<a href=" + "#" + ">" +
                        "<i class=" + "fa " + padre.Icono + "" + "></i><span>" + padre.Descripcion + "</span>" +
                        "<i class=" + "fa fa-angle-left pull-right" + "></i>" +
                        "</a>" +
                        "<ul class=" + "treeview-menu" + ">";
                        foreach (var hijo in ne_usuario.ObtenerPermisoFormulario(idgrupo_usuario, idusuario, padre.IdFormulario))
                        {
                            if (string.IsNullOrWhiteSpace(hijo.Url))
                            {
                                str_menu2 = "<a href=" + "#" + "><i class=" + "fa fa-tablet" + "></i>" + hijo.Descripcion + "<i class=" + "fa fa-angle-left pull-right" + "></i></a>" +
                                "<ul class=" + "treeview-menu" + ">";
                                foreach (var subhijo in ne_usuario.ObtenerPermisoFormulario(idgrupo_usuario, idusuario, hijo.IdFormulario))
                                {
                                    if (subhijo.Paginas.ToUpper().Contains(pagina_actual.ToUpper()))
                                    {
                                        bandera = true;
                                        str_menu2 += "<li class=" + "active" + "><a href=" + "" + subhijo.Url + "" + "><i class=" + "fa fa-play-circle" + "></i>" + subhijo.Descripcion + "</a></li>";
                                    }
                                    else
                                        str_menu2 += "<li><a href=" + "" + subhijo.Url + "" + "><i class=" + "fa fa-play-circle" + "></i>" + subhijo.Descripcion + "</a></li>";
                                }
                                str_menu2 += "</ul>";
                                str_menu2 += "</li>";
                                str_menu += "<li>" + str_menu2;
                            }
                            else
                            {
                                str_menu += "<li><a href=" + "" + hijo.Url + "" + "><i class=" + "fa fa-play-circle" + "></i>" + hijo.Descripcion + "</a></li>";
                                if (hijo.Paginas.ToUpper().Contains(pagina_actual.ToUpper()))
                                {
                                    bandera = true;
                                    //str_menu += "<li class=" + "active" + "><a href=" + "" + hijo.Url + "" + "><i class=" + "fa fa-play-circle" + "></i>" + hijo.Descripcion + "</a></li>";
                                }
                            }
                        }
                        Literal1.Text += bandera ? "<li class=" + "treeview active" + ">" : "<li class=" + "treeview" + ">";
                        Literal1.Text += str_menu;
                        Literal1.Text += "</ul> </li>";
                    }
                    //Literal1.Text += "<li class=" + "header" + ">NOVEDADES</li>";
                    //Literal1.Text += "<li><a href=" + "#" + "><i class=" + "fa fa-circle-o text-red" + "></i><span>Actualizaciones</span></a></li>";
                    //Literal1.Text += "<li><a href=" + "#" + "><i class=" + "fa fa-circle-o text-yellow" + "></i><span>Documentación</span></a></li>";
                    Literal1.Text += "</ul>";

                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSingOut_Click(object sender, EventArgs e)
        {

        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {

        }
    }
}