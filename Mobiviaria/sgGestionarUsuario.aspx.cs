using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobiviaria.Controller;
namespace Mobiviaria
{
    public partial class sgGestionarUsuario : System.Web.UI.Page
    {
        private neUsuario user = new neUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.obtenerCargos(cboGrupoUsuario, 0);
                LoadTable();
            }
        }

        private void LoadTable()
        {
            int? idgrupo = null;
            if (!string.IsNullOrWhiteSpace(cboGrupoUsuario.SelectedValue))
            {
                if (Convert.ToInt32(cboGrupoUsuario.SelectedValue) > 0)
                    idgrupo = Convert.ToInt32(cboGrupoUsuario.SelectedValue);
            }
            string nombre_completo = null;
            //if (!string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            //    nombre_completo = txtNombreCompleto.Text;
            string nombre_usuario = null;
            //if (!string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            //    nombre_usuario = txtNombreUsuario.Text;

            try
            {
                var listar = user.ListarUsuario(grupoUsuario: idgrupo, nombreCompleto: nombre_completo, nombreUsuario: nombre_usuario);
                lbResultado.Text = "Total Registros:" + listar.Count;
                dgDatos.DataSource = listar;
                dgDatos.DataBind();
            }
            catch (Exception)
            {
                dgDatos.CurrentPageIndex = 0;
                dgDatos.DataBind();
                throw;
            }

        }

        protected void dgDatos_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgDatos.CurrentPageIndex = e.NewPageIndex;
            LoadTable();
        }

        protected void dgDatos_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                int idusuario = Convert.ToInt32(e.Item.Cells[1].Text);
                switch (e.CommandName)
                {
                    case "MODIFICAR":
                        Session["idusuario"] = idusuario;
                        Session["formulario"] = "sgGestionarUsuario.aspx";
                        Session["accion"] = "MODIFICAR";
                        Response.Redirect("sgUsuario.aspx");
                        break;
                    case "ELIMINAR":
                        user.idusuario = idusuario;
                        if (user.Eliminar())
                        {
                            LoadTable();
                            string script = "alert('Usuario Eliminado Satisfactoriamente');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
                        }
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["formulario"] = "sgGestionarUsuario.aspx";
            Session["idusuario"] = null;
            Session["accion"] = "NUEVO";
            Response.Redirect("sgUsuario.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            //txtNombreCompleto.Text = "";
            //txtNombreUsuario.Text = "";
            cboGrupoUsuario.SelectedValue = "0";
            LoadTable();
        }
        protected void dgDatos_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string s = e.Item.Cells[2].Text;
                if (s.Equals("0"))
                {                   
                    e.Item.Cells[3].Text = string.Empty;
                }

            }
        }
    }
}