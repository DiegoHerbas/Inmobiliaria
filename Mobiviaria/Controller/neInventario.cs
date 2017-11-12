using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Inmodb;
namespace Mobiviaria
{
    public class neInventario : inventario
    {
        public string messageError = "";
        public neInventario()
        {

        }
        public ObservableCollection<inventario> listaInventario()
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            var consulta = PetaPoco.Sql.Builder
               .Select("*")
                .From("inventario")
                .Where("inventario.marca_baja = 0");
            var resultado = new ObservableCollection<inventario>(bd.Query<inventario>(consulta));
            return resultado;
        }
        public Boolean Guardar()
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            try
            {
                bd.BeginTransaction();
               

            }
            catch (Exception ex)
            {
                bd.AbortTransaction();
                messageError = ex.Message;
                return false;
            }
            bd.CompleteTransaction();
            return true;
        }
       
       
        public Boolean eliminar(int idUsuario, int idReserva)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            try
            {
                bd.BeginTransaction();
               // bd.Execute("UPDATE rereserva SET rereserva.marca_baja = @0, rereserva.usuario = @1, rereserva.fecha_proceso = @2 WHERE rereserva.idreserva = @3", 1, idUsuario, DateTime.Now, idReserva);
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                bd.AbortTransaction();
                return false;
            }
            bd.CompleteTransaction();
            return true;
        }
        private void hola() {

            // aqui tiene que ir el hola
            // hola de tapia sama

        }
      
    }

}
