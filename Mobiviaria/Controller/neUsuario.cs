using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Inmodb;

namespace Mobiviaria
{
	public class neUsuario : usuario
	{
        public string messageError = "";
		public neUsuario()
		{

		}
		public usuario ObtenerUsuario(string login, string clave)
		{
			var bd = new Inmodb.InmodbDB("Inmodb");
			var u = bd.FirstOrDefault<usuario>("WHERE marca_baja = 0 AND nombreUsuario = @0 AND clave = @1", login, clave);
            return u;
		}
        public ObservableCollection<Usuario> ListarUsuario(int? idusuario = null, int? grupoUsuario = null, string nombreCompleto = null, string nombreUsuario = null)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            var consulta = PetaPoco.Sql.Builder
                .Select("usuario.idusuario",
                "usuario.idGrupoUsuario",
                "concepto.descripcion AS tipoUsuario",
                "usuario.nombreCompleto",
                "usuario.nombreUsuario",
                "usuario.fecha_valides")
                .From("usuario")
                .LeftJoin("concepto").On("concepto.correlativo = usuario.idGrupoUsuario AND concepto.prefijo = 1")
                .Where("usuario.marca_baja = 0");
            if (idusuario > 0)
                consulta.Where("sgUsuario.idUsuario=@0", idusuario);
            if (grupoUsuario != null)
                consulta.Where("concepto.correlativo = @0", grupoUsuario);
            if (!string.IsNullOrWhiteSpace(nombreCompleto))
                consulta.Where("sgUsuario.nombreCompleto LIKE @0", "%" + nombreCompleto + "%");
            if (!string.IsNullOrWhiteSpace(nombreUsuario))
                consulta.Where("sgUsuario.nombreUsuario LIKE @0", "%" + nombreUsuario + "%");

            return new ObservableCollection<Usuario>(bd.Query<Usuario>(consulta));
        }
        public neUsuario ObtnerUsuario(string idusuario)
		{
			var bd = new Inmodb.InmodbDB("Inmodb");
            var res= bd.FirstOrDefault<neUsuario>("WHERE idusuario = @0", idusuario);            
            return res;
		}
		public Boolean Guardar()
		{
            var bd = new Inmodb.InmodbDB("Inmodb");
            try
			{
                bd.BeginTransaction();
                if (idusuario == 0)
                {
                    fecha_registro = DateTime.Now;
                    fecha_ult_proceso = DateTime.Now;
                    marca_baja = false;
                    Insert();
                    
                }
                else {
                    fecha_ult_proceso = DateTime.Now;
                    Update();
                    
                }
                bd.CompleteTransaction();
                return true;
			}
			catch(Exception ex)
			{
                bd.AbortTransaction();
                messageError = ex.Message;
                return false;
			}
            
		}
        public Boolean Eliminar()
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            try
            {
                bd.BeginTransaction();
                if (idusuario > 0)
                {
                    bd.Execute("UPDATE usuario SET usuario.marca_baja = @0,usuario.fecha_ult_proceso=@1 WHERE usuario.idusuario = @2", 1, DateTime.Now, idusuario);
                }                    
                bd.CompleteTransaction();
                return true;
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
                bd.AbortTransaction();
                return false;
            }
        }
        public ObservableCollection<PermisoFormulario> ObtenerPermisoFormulario(string idGrupoUsuario, string idusuario, string idFormulario = null)
        {
            var bd = new Inmodb.InmodbDB("Inmodb");
            var sql = PetaPoco.Sql.Builder
                .Append("Select Distinct F.IdFormulario,")
                .Append("F.IdPadre,")
                .Append("F.Descripcion,")
                .Append("F.Posicion,")
                .Append("F.url,")
                .Append("F.Icono,")
                .Append("F.Paginas,")
                .Append("GF.Adicionar,")
                .Append("GF.Editar,")
                .Append("GF.Eliminar,")
                .Append("GF.Ver")
                .From("sgrupo_usuario_formulario GF")
                .InnerJoin("usuario U").On("U.IdGrupoUsuario = GF.IdGrupoUsuario")
                .LeftJoin("sgformulario F").On("GF.IdFormulario = F.IdFormulario")
                .Where(@"((F.Abm = 1 AND GF.Adicionar = 1) OR 
					(F.Abm = 0 AND ( GF.Adicionar = 1 OR gF.Editar = 1 OR GF.Eliminar = 1 OR GF.Ver = 1))) 
					AND U.idusuario = " + idusuario + " AND GF.idGrupoUsuario = " + idGrupoUsuario);
            if (idFormulario != null)
                sql.Where(" F.IdPadre = '" + idFormulario+"'");
            sql.OrderBy("F.IdPadre ASC, F.Posicion ASC");
            return new ObservableCollection<PermisoFormulario>(bd.Query<PermisoFormulario>(sql));
        }
    }
}