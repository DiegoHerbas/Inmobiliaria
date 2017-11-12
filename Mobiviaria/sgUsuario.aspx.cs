using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobiviaria.Controller;
namespace Mobiviaria
{
    public partial class sgUsuario : System.Web.UI.Page
    {
        private neUsuario user = new neUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //try
                //{
                //    if (Convert.ToInt32(Request.Cookies.Get("idUsuarioLogin").Value) <= 0)
                //    {
                //        Response.Redirect("Default.aspx");
                //    }
                //}
                //catch
                //{
                //    Response.Redirect("Default.aspx");
                //}

                hf_formulario.Value = Convert.ToString(Session["formulario"]);
                if (!hf_formulario.Value.Equals("sgGestionarUsuario.aspx"))
                {
                    Response.Redirect("iuPrincipal.aspx");
                }
                hf_idusuario.Value = Convert.ToString(Session["idusuario"]);
                hf_accion.Value = Convert.ToString(Session["accion"]);
                cargarCombos();
                switch (hf_accion.Value)
                {
                    case "MODIFICAR":
                        ModelToView(hf_idusuario.Value);
                        break;
                }
            }
        }

        private void cargarCombos()
        {
            Util.obtenerCargos(cboGrupoUsuario, 0);
            Util.obtenerGeneros(cboGenero, 0);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("sgGestionarUsuario.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ViewToModel();
            if (user.Guardar())
            {
                string script = "alert('Se Registro correctamente');window.location.href='sgGestionarUsuario.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
            }
        }

        private void ViewToModel()
        {
            if (hf_accion.Value == "MODIFICAR")
            {
                user = (neUsuario)Session["usuario"];
            }
            user.nombreCompleto = txtNombreCompleto.Text;
            user.genero = Int32.Parse(cboGenero.SelectedValue);
            user.nombreUsuario = txtNombreUsuario.Text;
            user.clave = txtPasword.Text;
            user.fecha_valides = Convert.ToDateTime(DtpFechaValides.Text);
            user.idGrupoUsuario = Int32.Parse(cboGrupoUsuario.SelectedValue);
            /* imagen*/
            HttpPostedFile Postedfile = FileUpload2.PostedFile;
            string filename = System.IO.Path.GetFileName(Postedfile.FileName);
            string fileExtension = System.IO.Path.GetExtension(Postedfile.FileName);
            int fileSize = Postedfile.ContentLength;
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".jpge")
            {
                System.IO.Stream stream = Postedfile.InputStream;
                System.IO.BinaryReader bynariReader = new System.IO.BinaryReader(stream);
                byte[] bytes = bytes = bynariReader.ReadBytes(Convert.ToInt32(stream.Length));
                user.nombre_imagen = filename;
                user.size = fileSize;
                user.imagen = bytes;
            }
        }
        private void ModelToView(string idUsuario)
        {
            var usuario = user.ObtnerUsuario(idUsuario);
            Session["usuario"] = usuario;
            txtIdUsuario.Text = Convert.ToString(usuario.idusuario);
            txtNombreCompleto.Text = usuario.nombreCompleto;
            txtNombreUsuario.Text = usuario.nombreUsuario;
            txtPasword.Text = Convert.ToString(usuario.clave);
            cboGenero.SelectedValue = Convert.ToString(usuario.genero);
            cboGrupoUsuario.SelectedValue = Convert.ToString(usuario.idGrupoUsuario);
            DateTime fecha = usuario.fecha_valides;
            DtpFechaValides.Text = fecha.ToString("d");

            /*imagen*/
            if (usuario.imagen != null)
            {
                byte[] bytes = usuario.imagen;
                string strBase64 = Convert.ToBase64String(bytes);
                output.ImageUrl = "data:Image/png;base64," + strBase64;
            }
            else
            {
                output.ImageUrl = "~/iconos/not.png";
            }
        }
    }
}