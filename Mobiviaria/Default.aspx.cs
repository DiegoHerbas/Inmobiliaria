using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobiviaria.Controller;
namespace Mobiviaria
{
	public partial class Default : System.Web.UI.Page
	{
		neUsuario ne_usuario = new neUsuario();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//divRecovery.Visible = false;
				//divRecoveryPassword.Visible = false;
			}
		}

		protected void BtnCancelRenew_Click(object sender, EventArgs e)
		{

		}

		protected void BtnRenewPassword_Click(object sender, EventArgs e)
		{

		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			try
			{
				var u = ne_usuario.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
				if (u != null)
				{
					//var business = Util.obtenerIdEmpresa(usuario.idusuario);
					HttpCookie myHttpCookie = new HttpCookie("idUsuarioLogin", Convert.ToString(u.idusuario));
					Response.Cookies.Add(myHttpCookie);
                    HttpCookie cookie_IdGrupoUsuario = new HttpCookie("idGrpUserLogin", Convert.ToString(u.idGrupoUsuario));
                    Response.Cookies.Add(cookie_IdGrupoUsuario);
                    //               HttpCookie empresa = new HttpCookie("idEmpresa", Convert.ToString(business));
                    //Response.Cookies.Add(empresa);
                    Response.Redirect("iuPrincipal.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Usuario no Valido');", true);
                    txtUsuario.Text = string.Empty;
                    txtClave.Text = string.Empty;
                }
			}
			catch (Exception ex)
			{
				new Exception(ex.Message);
			}
		}
	}
}