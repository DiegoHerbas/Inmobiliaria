using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobiviaria.Controller;
using Subgurim.Controles;

namespace Mobiviaria.View
{
    public partial class GestionarInventario : System.Web.UI.Page
    {
        private neInventario _neInventario = new neInventario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Convert.ToInt32(Request.Cookies.Get("idUsuarioLogin").Value) <= 0)
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("Default.aspx");
                }
                //hf_idEmpresa.Value = Convert.ToString(Util.obtenerIdEmpresa(Convert.ToInt32(Request.Cookies.Get("idUsuarioLoginGeal").Value)));
                cargarCombos();
                LoadTable();
                initialize();
            }

        }
        private void initialize()
        {
            GLatLng ubicacion = new GLatLng(40.381090863719436, -3.6222052574157715);
            GLatLng ubicacion2 = new GLatLng(42.381090863719436, -3.6222052574157715);
            

            //Establecemos alto y ancho en px
            GMap1.Height = 480;
            GMap1.Width = 575;

            //Adiciona el control de la parte izq superior (moverse, ampliar y reducir)
            GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

            //GControl.preBuilt.MapTypeControl: permite elegir un tipo de mapa y otro.
            GMap1.Add(new GControl(GControl.preBuilt.MapTypeControl));

            //Con esto podemos definir el icono que se mostrara en la ubicacion
            //#region Crear Icono
            //GIcon iconPropio = new GIcon();
            //iconPropio.image = "../images/iconBuilding.png";
            //iconPropio.shadow = "../images/iconBuildingS.png";
            //iconPropio.iconSize = new GSize(32, 32);
            //iconPropio.shadowSize = new GSize(29, 16);
            //iconPropio.iconAnchor = new GPoint(10, 18);
            //iconPropio.infoWindowAnchor = new GPoint(10, 9);
            //#endregion

            //Pone la marca de gota de agua con el nombre de la ubicacion
            GMarker marker = new GMarker(ubicacion);
            GMarker marker2 = new GMarker(ubicacion2);
            string strMarker = "<div style='width: 150px; height: 85'>" +
                                "<br>" + " C/ C/ Nombre de Calle, No X <br /> 28031 Madrid, España " + "<br />" +
                                "Tel: +34 902 00 00 00 <br />" + 
                                "Fax: +34 91 000 00 00<br />" +
                               "</div>";
            GInfoWindow window = new GInfoWindow(marker, strMarker, true);
            GInfoWindow window2 = new GInfoWindow(marker2, strMarker+"Hola Desu", true);
            GMap1.Add(window);
            GMap1.Add(window2);
            GMap1.setCenter(ubicacion2, 15);
            GMap1.enableHookMouseWheelToZoom = true;

            //Tipo de mapa a mostrar
            GMap1.mapType = GMapType.GTypes.Normal;

            //Moverse con el cursor del teclado
            GMap1.enableGKeyboardHandler = true;            
        }
        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("iuPrincipal.aspx");
        }
        private void LoadTable()
        {
            try
            {
                var listar = _neInventario.listaInventario();
                lbResultado.Text = "Total Registros:" + listar.Count;
                Session["listar"] = listar;
                dgDatos.DataSource = Session["listar"];
                dgDatos.DataBind();
            }
            catch (Exception ex)
            {
                dgDatos.CurrentPageIndex = 0;
                dgDatos.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Ocurrio un error " + ex.Message + "');", true);
            }

        }
        protected void dgDatos_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            try
            {
                dgDatos.CurrentPageIndex = e.NewPageIndex;
                LoadTable();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void dgDatos_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "VER":
                        //Session["idegreso"] = Int32.Parse(e.Item.Cells[1].Text);
                        /////Session["accion"] = "MODIFICAR";
                        //var r = (ObservableCollection<Models.mCaCartera>)(Session["egresos"]);
                        //var datos = r.FirstOrDefault(c => c.id == Convert.ToInt32(Session["idegreso"]));
                        //                  cboModalCatetoria.SelectedValue = Convert.ToString(datos.idcategoria);
                        //                  dtpModalFechaGasto.Text = Convert.ToString(datos.fecha);
                        //                  txtModalTotal.Text = Convert.ToString(datos.total);
                        //                  TxtNota.Text = datos.nota;
                        //Session["MODIFICAR"] = true;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "abrirModal();", true);
                        break;
                    case "FOTO":
                       // imgImagen.ImageUrl
                        imgImagen.ImageUrl = "~/images/image2.jpg";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "abrirModalFoto();", true);
                        break;
                    case "MAPA":
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "abrirModalMapa();", true);
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            cboTramo.SelectedValue = "0";
            cboCarretera.SelectedValue = "0";
            LoadTable();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LoadTable();
        }



        protected void btnModalCerrar_Click(object sender, EventArgs e)
        {           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "cerrarModalMapa();", true);
        }

        protected void btnModalAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToBoolean(Session["MODIFICAR"]))
                //{
                //	//reclamo.Atencion.idatencion = Convert.ToInt32(Session["idatencion"]);
                //                var prov = gastos.obtenerEgreso(Convert.ToInt32(Session["idegreso"]));
                //                gastos = prov;
                //            }
                //            gastos.idcategoria = Convert.ToInt32(cboTipoEgreso.SelectedValue);
                //            gastos.fecha_gasto = Convert.ToDateTime(dtpModalFechaGasto.Text);
                //            gastos.total = Math.Round(Convert.ToDecimal(txtModalTotal.Text),2);
                //            gastos.usuario = Convert.ToInt32(Request.Cookies.Get("idUsuarioLogin").Value);
                //            gastos.nota = TxtNota.Text;
                //if (gastos.Guardar())
                //{
                //	Session["MODIFICAR"] = false;
                //	LoadTable();
                //	cleanModal();
                //	string script = "alert('Se Registro correctamente');cerrarModal();";
                //	ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
                //}
                //else
                //{
                //	ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Ocurrio un error " + gastos.messageError + "');", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Ocurrio un error " + ex.Message + "');", true);
            }
        }


        private void cleanModal()
        {


        }
        private void cargarCombos()
        {

        }


        protected void btnModalNewGastoCerrar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "cerrarModalNewGasto();", true);
        }
        private void cleanModalNewConcepto()
        {
            
        }
        protected void btnModalNewGastoAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Inmodb.concepto _concepto = new Inmodb.concepto();
                //_concepto.descripcion = txtConceptoGasto.Text.Trim();
                //_concepto.usuario = Convert.ToInt32(Request.Cookies.Get("idUsuarioLogin").Value);

                //if (gastos.guardarConceptoIngreso(ref _concepto))
                //{
                //    cargarCombos();
                //    cleanModalNewConcepto();
                //    string script = "alert('Se Registro correctamente');cerrarModalNewGasto();";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Ocurrio un error " + gastos.messageError + "');", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Ocurrio un error " + ex.Message + "');", true);
            }
        }
    }
}