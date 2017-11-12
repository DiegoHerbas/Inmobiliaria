using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using Inmodb;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Mobiviaria.Controller
{
    public class Util
    {
        public static string rowComb0 = "Seleccionar";
        public static string messageError = "";
        public class item
        {
            public int id { get; set; }
            public String descripcion { get; set; }
        }
        private static void load_Combobox(DropDownList combo, DataTable tabla, string text, string value, int selectRowValue)
        {
            combo.DataSource = tabla;
            combo.DataTextField = text;
            combo.DataValueField = value;
            combo.DataBind();
            if (selectRowValue > 0)
            {
                combo.SelectedValue = Convert.ToString(selectRowValue);
            }
        }
        public static ObservableCollection<item> model_radioButtonList(RadioButtonList radio, string sql, string text, string value)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            var c = new ObservableCollection<item>(bd.Query<item>(sql));
            radio.DataTextField = text;
            radio.DataValueField = value;
            return c;
        }
        private static DataTable model_combo(string sql, string column0 = "")
        {
            DataTable tabla = new DataTable();
            var bd = new Inmodb.InmodbDB("Inmodb");
            var consulta = new ObservableCollection<item>(bd.Query<item>(sql));
            tabla.Columns.Add("id");
            tabla.Columns.Add("descripcion");
            if (!String.IsNullOrEmpty(column0))
            {
                tabla.Rows.Add(new object[] { 0, column0 });
            }
            if (consulta.Count > 0)
            {
                foreach (item e in consulta)
                {
                    tabla.Rows.Add(new object[] { e.id, e.descripcion });
                }
            }
            return tabla;
        }
        public static DataTable years(int desde, int hasta, string row0 = null)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id");
            tabla.Columns.Add("descripcion");
            if (row0 != null)
            {
                tabla.Rows.Add(new object[] { 0, row0 });
            }

            if (desde <= hasta)
            {
                int indice = 0;
                int year = desde;
                for (int i = desde; i <= hasta; i++)
                {
                    indice = indice + 1;
                    tabla.Rows.Add(new object[] { indice, year });
                    year++;
                }

            }

            return tabla;
        }
        public static DataTable Monts(string row0 = null)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id");
            tabla.Columns.Add("descripcion");
            if (row0 != null)
            {
                tabla.Rows.Add(new object[] { 0, row0 });
            }
            tabla.Rows.Add(new object[] { 1, "Enero" });
            tabla.Rows.Add(new object[] { 2, "Febrero" });
            tabla.Rows.Add(new object[] { 3, "Marzo" });
            tabla.Rows.Add(new object[] { 4, "Abril" });
            tabla.Rows.Add(new object[] { 5, "Mayo" });
            tabla.Rows.Add(new object[] { 6, "Junio" });
            tabla.Rows.Add(new object[] { 7, "Julio" });
            tabla.Rows.Add(new object[] { 8, "Agosto" });
            tabla.Rows.Add(new object[] { 9, "Septiembre" });
            tabla.Rows.Add(new object[] { 10, "Octubre" });
            tabla.Rows.Add(new object[] { 11, "Noviembre" });
            tabla.Rows.Add(new object[] { 12, "Diciembre" });
            return tabla;
        }

        public static void obtenerCargos(DropDownList combo, int selectRowValue)
        {
            string sql = "SELECT correlativo as id, descripcion FROM concepto WHERE correlativo <> 0 AND marca_baja = 0 AND prefijo = 1";
            load_Combobox(combo, model_combo(sql, "Seleccionar"), "descripcion", "id", selectRowValue);
        }
        public static void obtenerGeneros(DropDownList combo, int selectRowValue)
        {
            string sql = "SELECT correlativo as id, descripcion FROM concepto WHERE correlativo <> 0 AND marca_baja = 0 AND prefijo = 2";
            load_Combobox(combo, model_combo(sql, "Seleccionar"), "descripcion", "id", selectRowValue);
        }
        public static void obtenerGastos(DropDownList combo, int selectRowValue)
        {
            string sql = "SELECT correlativo as id, descripcion FROM concepto WHERE correlativo <> 0 AND marca_baja = 0 AND prefijo = 3";
            load_Combobox(combo, model_combo(sql, "Seleccionar"), "descripcion", "id", selectRowValue);
        }
        public static void obtenerIngresos(DropDownList combo, int selectRowValue)
        {
            string sql = "SELECT correlativo as id, descripcion FROM concepto WHERE correlativo <> 0 AND marca_baja = 0 AND prefijo = 4";
            load_Combobox(combo, model_combo(sql, "Seleccionar"), "descripcion", "id", selectRowValue);
        }
        public static void ListYears(DropDownList combo, int selectRowValue)
        {
            DateTime fecha = DateTime.Now;
            int desde = Convert.ToInt32(fecha.Year) - 15;
            int hasta = fecha.Year + 15;
            load_Combobox(combo, years(desde, hasta, "Seleccionar"), "descripcion", "id", selectRowValue);
        }
        public static int ObtenerUltimoCorrelativo(int prefijo)
        {
            int x = 0;
            var db = new InmodbDB("Inmodb");
            var id = db.Fetch<int>("SELECT COUNT(*) FROM concaja WHERE concaja.prefijo = @0", prefijo);
            try
            {
                x = id.First();
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                x = 0;
            }
            return x;
        }
        public static string validarcomaFormulario(string cadena)
        {
            string aux = cadena;
            if (cadena.IndexOf('.') > -1)
            {
                aux = cadena.Replace('.', ',');
            }
            return aux;
        }
        public static string validarcomaModelo(string cadena)
        {
            string aux = cadena;
            if (cadena.IndexOf(',') > -1)
            {
                aux = cadena.Replace(',', '.');
            }
            return aux;
        }
        public static string fechaSinhora(DateTime fecha)
        {
            string fechaformato = fecha.ToShortDateString();
            return fechaformato;
        }
        public static bool existe(string texto, DataGrid tabla, int columna)
        {
            for (int i = 0; i < tabla.Items.Count; i++)
            {

                if (string.Compare(texto, tabla.Items[i].Cells[columna].Text) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static string listString(string[] lista)
        {
            string cadena = "";
            if (lista.Count()>0) {
                cadena = string.Join(",",lista);
            }
            return cadena;
        }

        public static bool IsNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }
        public static bool IsRealNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9.0-9]");
            return !isnumber.IsMatch(inputvalue);
        }

        public static int obtenerCantidadProducto(string nombre_producto)
        {
            int x = 0;
            var db = new InmodbDB("Inmodb");
            var id = db.Fetch<int>("SELECT COUNT(*) FROM producto WHERE producto.nombre_producto = @0", nombre_producto);
            try
            {
                x = id.First();
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                x = 0;
            }
            return x;
        }
        public static string obtenerUsuario(int idusuario)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            var r = bd.FirstOrDefault<usuario>("WHERE idusuario = @0", idusuario);
            bd.Dispose();
            bd = null;
            return r.idusuario + "-" + r.nombreCompleto;
        }
    }
}