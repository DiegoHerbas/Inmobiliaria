



















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `Inmodb`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=localhost;Initial Catalog=taller;Persist Security Info=True;User ID=emozione;Password=123456`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Inmodb
{

	public partial class InmodbDB : Database
	{
		public InmodbDB() 
			: base("Inmodb")
		{
			CommonConstruct();
		}

		public InmodbDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			InmodbDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static InmodbDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new InmodbDB();
        }

		[ThreadStatic] static InmodbDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static InmodbDB repo { get { return InmodbDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    

	[TableName("dbo.carretera")]



	[PrimaryKey("idcarretera")]




	[ExplicitColumns]

    public partial class carretera : InmodbDB.Record<carretera>  
    {



		[Column] public int idcarretera { get; set; }





		[Column] public string nombre_carretera { get; set; }





		[Column] public int id_departamento { get; set; }





		[Column] public int id_tipo_carretera { get; set; }





		[Column] public bool asignado { get; set; }





		[Column] public bool marca_baja { get; set; }





		[Column] public DateTime fecha_registro { get; set; }





		[Column] public DateTime fecha_proceso { get; set; }





		[Column] public int usuario { get; set; }



	}

    

	[TableName("dbo.concepto")]



	[PrimaryKey("idconcepto")]




	[ExplicitColumns]

    public partial class concepto : InmodbDB.Record<concepto>  
    {



		[Column] public int idconcepto { get; set; }





		[Column] public int prefijo { get; set; }





		[Column] public int correlativo { get; set; }





		[Column] public string descripcion { get; set; }





		[Column] public DateTime fecha_registro { get; set; }





		[Column] public DateTime fecha_ult_proceso { get; set; }





		[Column] public bool marca_baja { get; set; }





		[Column] public int usuario { get; set; }



	}

    

	[TableName("dbo.detalle_inventario")]



	[PrimaryKey("iddetalleinventario")]




	[ExplicitColumns]

    public partial class detalle_inventario : InmodbDB.Record<detalle_inventario>  
    {



		[Column] public int iddetalleinventario { get; set; }





		[Column] public int idinventario { get; set; }





		[Column] public int idfisura { get; set; }





		[Column] public int idnivelseveridad { get; set; }





		[Column] public string gps_latitud { get; set; }





		[Column] public string gps_longitud { get; set; }





		[Column] public string largo { get; set; }





		[Column] public string ancho { get; set; }





		[Column] public string medida_superficie { get; set; }





		[Column] public string longitud { get; set; }





		[Column] public string medida_longitud { get; set; }





		[Column] public decimal? profundidad { get; set; }





		[Column] public string descripcion { get; set; }





		[Column] public string photo_name { get; set; }





		[Column] public int? tramo { get; set; }





		[Column] public int? carretera { get; set; }





		[Column] public int cuadrilla { get; set; }





		[Column] public bool marca_baja { get; set; }





		[Column] public DateTime fecha_registro { get; set; }





		[Column] public DateTime fecha_proceso { get; set; }



	}

    

	[TableName("dbo.inventario")]



	[PrimaryKey("idinventario")]




	[ExplicitColumns]

    public partial class inventario : InmodbDB.Record<inventario>  
    {



		[Column] public int idinventario { get; set; }





		[Column] public int idcuadrilla { get; set; }





		[Column] public int idtramo { get; set; }





		[Column] public int idcarretera { get; set; }





		[Column] public bool marca_baja { get; set; }





		[Column] public DateTime fecha_registro { get; set; }





		[Column] public DateTime fecha_proceso { get; set; }



	}

    

	[TableName("dbo.sgformulario")]




	[ExplicitColumns]

    public partial class sgformulario : InmodbDB.Record<sgformulario>  
    {



		[Column] public string IdFormulario { get; set; }





		[Column] public string IdPadre { get; set; }





		[Column] public string Descripcion { get; set; }





		[Column] public int? Posicion { get; set; }





		[Column] public string url { get; set; }





		[Column] public string Icono { get; set; }





		[Column] public string Paginas { get; set; }





		[Column] public bool? Abm { get; set; }



	}

    

	[TableName("dbo.sgrupo_usuario_formulario")]




	[ExplicitColumns]

    public partial class sgrupo_usuario_formulario : InmodbDB.Record<sgrupo_usuario_formulario>  
    {



		[Column] public int IdGrupoUsuario { get; set; }





		[Column] public string IdFormulario { get; set; }





		[Column] public bool? Adicionar { get; set; }





		[Column] public bool? Editar { get; set; }





		[Column] public bool? Eliminar { get; set; }





		[Column] public bool? Ver { get; set; }



	}

    

	[TableName("dbo.tramo")]



	[PrimaryKey("idtramo")]




	[ExplicitColumns]

    public partial class tramo : InmodbDB.Record<tramo>  
    {



		[Column] public int idtramo { get; set; }





		[Column] public string nombre_tramo { get; set; }





		[Column] public string supervisor { get; set; }





		[Column] public bool marca_baja { get; set; }





		[Column] public DateTime fecha_registro { get; set; }





		[Column] public DateTime fecha_proceso { get; set; }





		[Column] public int usuario { get; set; }



	}

    

	[TableName("dbo.usuario")]



	[PrimaryKey("idusuario")]




	[ExplicitColumns]

    public partial class usuario : InmodbDB.Record<usuario>  
    {



		[Column] public int idusuario { get; set; }





		[Column] public int idGrupoUsuario { get; set; }





		[Column] public string nombreCompleto { get; set; }





		[Column] public string nombreUsuario { get; set; }





		[Column] public string clave { get; set; }





		[Column] public int genero { get; set; }





		[Column] public DateTime fecha_valides { get; set; }





		[Column] public DateTime fecha_registro { get; set; }





		[Column] public DateTime fecha_ult_proceso { get; set; }





		[Column] public string nombre_imagen { get; set; }





		[Column] public int? size { get; set; }





		[Column] public byte[] imagen { get; set; }





		[Column] public bool marca_baja { get; set; }



	}


}
