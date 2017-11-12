using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using Inmodb;
using System.IO;
using System.Drawing.Imaging;

namespace Mobiviaria
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://demo.taller.android.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService()]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        //[WebMethod()]

        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] ObtClientes(string prefixText, int count, string contextKey)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<pagenda>("SELECT TOP(10) * FROM pagenda WHERE pagenda.marca_baja = 0 AND pagenda.idempresa = @0 AND pagenda.tipo_persona = 2 AND (pagenda.idagenda LIKE @1 OR pagenda.descripcion LIKE @1)", contextKey, "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idagenda, c.descripcion));
        //          }
        //          return customers.ToArray();
        //      }
        //      [WebMethod()]

        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] ObtPropietarios(string prefixText, int count)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<mPaPropiedad>("select papropietario .idpropietario,pagenda.descripcion as nombre_propietario from pagenda join papropietario on papropietario.idagenda = pagenda.idagenda where pagenda.descripcion LIKE @0", "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idpropietario, c.nombre_propietario));
        //          }
        //          return customers.ToArray();
        //      }
        //      [WebMethod()]

        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] ObtDirecciones(string prefixText, int count)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<papropiedad>("select papropiedad .idpropiedad,papropiedad .direccion from papropiedad where papropiedad.direccion LIKE @0", "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idpropiedad, c.direccion));
        //          }
        //          return customers.ToArray();
        //      }

        //[WebMethod()]

        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] ObtUsuarios(string prefixText, int count)
        //{
        //	InmodbDB cxn = new InmodbDB("inmodb");
        //	List<string> customers = new List<string>();
        //	var usuarios = cxn.Query<sgusuario>("SELECT TOP(10) * FROM sgusuario WHERE sgusuario.Estado = 0 AND (sgusuario.IdUsuario LIKE @0 OR sgusuario.NombreCompleto LIKE @0)","%" + prefixText + "%");
        //	foreach (var c in usuarios)
        //	{
        //		customers.Add(string.Format("{0}-{1}", c.IdUsuario, c.NombreCompleto));
        //	}
        //	return customers.ToArray();
        //}
        //[WebMethod()]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] ObtTipoCxc(string prefixText, int count)
        //{
        //	InmodbDB cxn = new InmodbDB("inmodb");
        //	List<string> customers = new List<string>();
        //	var tipos = cxn.Query<cptipo>(
        //		@"SELECT TOP(10) * 
        //              FROM cptipo 
        //              WHERE marca_baja = 0 AND clase = 2 AND (idcptipo LIKE @0 OR descripcion LIKE @0)", "%" + prefixText + "%");

        //	foreach (var c in tipos)
        //		customers.Add(string.Format("{0}-{1}", c.idcptipo, c.descripcion));
        //	return customers.ToArray();
        //}
        //[WebMethod()]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] ObtAplicaciones(string prefixText, int count, string contextKey)
        //{
        //	InmodbDB cxn = new InmodbDB("inmodb");
        //	List<string> customers = new List<string>();
        //	if (string.IsNullOrWhiteSpace(contextKey))
        //		return customers.ToArray();
        //	var tipo = contextKey.Split('-')[0];			
        //	var app = cxn.Query<cpapl>(
        //		@"SELECT TOP(10) * FROM cpapl 
        //              WHERE cpapl.marca_baja = 0 
        //              AND tipo = @1 AND (cpapl.idaplicacion LIKE @0 OR cpapl.descripcion LIKE @0)", "%" + prefixText + "%", tipo);
        //	foreach (var c in app)
        //		customers.Add(string.Format("{0}-{1}", c.idaplicacion, c.descripcion));
        //	return customers.ToArray();
        //}


        //[WebMethod()]
        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] obtInquilinos(string prefixText, int count, string contextKey)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<pagenda>("SELECT TOP(10) * FROM painquilino JOIN pagenda on pagenda.idagenda = painquilino.idagenda WHERE painquilino.marca_baja = 0 AND painquilino.idempresa = @0  AND pagenda.idagenda LIKE @1 OR pagenda.descripcion LIKE @1", contextKey, "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idagenda, c.descripcion));
        //          }
        //          return customers.ToArray();
        //      }

        //      [WebMethod()]
        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] obtArrendadores(string prefixText, int count, string contextKey)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<pagenda>("SELECT TOP(10) * FROM parrendador JOIN pagenda on parrendador.idagenda=pagenda.idagenda WHERE parrendador.marca_baja = 0 AND parrendador.idempresa = @0  AND pagenda.idagenda LIKE @1 OR pagenda.descripcion LIKE @1", contextKey, "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idagenda, c.descripcion));
        //          }
        //          return customers.ToArray();
        //      }

        //      [WebMethod()]
        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] obtAdministradores(string prefixText, int count, string contextKey)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<pagenda>("SELECT TOP(10) paadministrador.idadministrador as idagenda,pagenda.descripcion FROM paadministrador JOIN pagenda on paadministrador.idagenda=pagenda.idagenda WHERE paadministrador.marca_baja = 0 AND paadministrador.idempresa = @0  AND pagenda.idagenda LIKE @1 OR pagenda.descripcion LIKE @1", contextKey, "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idagenda, c.descripcion));
        //          }
        //          return customers.ToArray();
        //      }
        //      [WebMethod()]
        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] obtRazonSocial(string prefixText, int count, string contextKey)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<pagenda>("SELECT TOP(10) * FROM pagenda WHERE pagenda.marca_baja = 0 AND pagenda.idempresa = @0 AND (pagenda.idagenda LIKE @1 OR pagenda.razon_social LIKE @1)", contextKey, "%" + prefixText + "%");
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idagenda, c.razon_social));
        //          }
        //          return customers.ToArray();
        //      }

        //      [WebMethod()]
        //      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //      public string[] ObtPropietarios2(string prefixText, int count, string contextKey)
        //      {
        //          InmodbDB cxn = new InmodbDB("inmodb");
        //          List<string> customers = new List<string>();
        //          var clientes = cxn.Query<mPaPropiedad>("select papropietario .idpropietario,pagenda.descripcion as nombre_propietario from pagenda join papropietario on papropietario.idagenda = pagenda.idagenda where pagenda.descripcion LIKE @0 and pagenda.idempresa=@1", "%" + prefixText + "%",contextKey);
        //          foreach (var c in clientes)
        //          {
        //              customers.Add(string.Format("{0}-{1}", c.idpropietario, c.nombre_propietario));
        //          }
        //          return customers.ToArray();
        //      }
        //[WebMethod()]

        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] obtenerProductos(string prefixText, int count)
        //{
        //    InmodbDB cxn = new InmodbDB("inmodb");
        //    List<string> customers = new List<string>();
        //    var produc = cxn.Query<producto>("SELECT TOP(10) * FROM producto WHERE producto.marca_baja = 0 AND (producto.idproducto LIKE @0 OR producto.nombre_producto LIKE @0)", "%" + prefixText + "%");
        //    foreach (var c in produc)
        //    {
        //        customers.Add(string.Format("{0}-{1}", c.idproducto, c.nombre_producto));
        //    }
        //    return customers.ToArray();
        //}
        //[WebMethod()]

        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] obtenerProveedor(string prefixText, int count)
        //{
        //    InmodbDB cxn = new InmodbDB("inmodb");
        //    List<string> customers = new List<string>();
        //    var produc = cxn.Query<proveedor>("SELECT TOP(10) * FROM proveedor WHERE proveedor.marca_baja = 0 AND (proveedor.idproveedor LIKE @0 OR proveedor.nombre_proveedor LIKE @0)", "%" + prefixText + "%");
        //    foreach (var c in produc)
        //    {
        //        customers.Add(string.Format("{0}-{1}", c.idproveedor, c.nombre_proveedor));
        //    }
        //    return customers.ToArray();
        //}
        //[WebMethod()]

        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] obtenerClientes(string prefixText, int count)
        //{
        //    InmodbDB cxn = new InmodbDB("inmodb");
        //    List<string> customers = new List<string>();
        //    var produc = cxn.Query<cliente>("SELECT TOP(10) * FROM cliente WHERE cliente.marca_baja = 0 AND (cliente.idcliente LIKE @0 OR cliente.nombre LIKE @0 OR cliente.apellido LIKE @0 OR cliente.alias LIKE @0)", "%" + prefixText + "%");
        //    foreach (var c in produc)
        //    {
        //        customers.Add(string.Format("{0}-{1}", c.idcliente, c.nombre + " " + c.apellido));
        //    }
        //    return customers.ToArray();
        //}

        [WebMethod()]
        public Boolean saveData(int idinventario,
                                int fisura,
                                int nivel_severidad,
                                String ancho,
                                String largo,
                                String medida_superficie,
                                String longitud,
                                String medida_longitud,
                                String profundidad,
                                String gps_latitud,
                                String gps_longitud,
                                String descripcion,
                                String photo_name,
                                String tramo,
                                String carretera,
                                String cod_cuadrilla)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            try
            {
                bd.BeginTransaction();
                Inmodb.detalle_inventario det = new Inmodb.detalle_inventario();
                det.idinventario = idinventario;
                det.idfisura = fisura;
                det.idnivelseveridad = nivel_severidad;
                try
                {
                    det.ancho = ancho;
                }
                catch
                {
                    det.ancho = "0";
                }
                try
                {
                    det.largo = largo;
                }
                catch
                {
                    det.largo = "0";
                }
                try
                {
                    det.medida_superficie = medida_superficie;
                }
                catch
                {
                    det.medida_superficie = "0";
                }
                try
                {
                    det.longitud = longitud;
                }
                catch
                {
                    det.longitud = "0";
                }
                try
                {
                    det.medida_longitud = medida_longitud;
                }
                catch
                {
                    det.medida_longitud = "0";
                }
                try
                {
                    det.profundidad = Convert.ToDecimal(profundidad);
                }
                catch
                {
                    det.profundidad = 0;
                }
                try
                {
                    det.gps_latitud = gps_latitud;
                }
                catch
                {
                    det.gps_latitud = "0";
                }
                try
                {
                    det.gps_longitud = gps_longitud;
                }
                catch
                {
                    det.gps_longitud = "0";
                }
                try
                {
                    det.descripcion = descripcion;
                }
                catch
                {
                    det.descripcion = string.Empty;
                }
                try
                {
                    det.photo_name = photo_name;
                }
                catch
                {
                    det.photo_name = string.Empty;
                }
                try
                {
                    det.tramo = Convert.ToInt32(tramo);
                }
                catch
                {
                    det.tramo = 0;
                }
                try
                {
                    det.carretera = Convert.ToInt32(carretera);
                }
                catch
                {
                    det.carretera = 0;
                }
                try
                {
                    det.cuadrilla = Convert.ToInt32(cod_cuadrilla);
                }
                catch
                {
                    det.cuadrilla = 0;
                }
                det.fecha_proceso = DateTime.Now;
                det.fecha_registro = DateTime.Now;
                det.marca_baja = false;
                det.Insert();
            }
            catch
            {
                bd.AbortTransaction();
                return false;
            }
            bd.CompleteTransaction();
            return true;
        }
        [WebMethod()]
        public int saveInventario(int idcuadrilla, int idtramo, int idcarretera)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            int result = -1;
            try
            {
                bd.BeginTransaction();
                Inmodb.inventario inv = new Inmodb.inventario();
                inv.idcuadrilla = idcuadrilla;
                inv.idtramo = idtramo;
                inv.idcarretera = idcarretera;
                inv.marca_baja = false;
                inv.fecha_proceso = DateTime.Now;
                inv.fecha_registro = DateTime.Now;
                inv.Insert();
                result = inv.idinventario;
            }
            catch
            {
                bd.AbortTransaction();
                return result;
            }
            bd.CompleteTransaction();
            return result;
        }
        [WebMethod()]
        public Boolean saveImage(String base64String,String photo_name)
        {          
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }

                image.Save("~/images/"+photo_name,ImageFormat.Png);
            }
            catch(Exception e)
            {
                String s = e.Message;
                
                return false;
            }       
            return true;
        }
    }

}
