using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobiviaria
{
	public class Usuario
	{
        public int idusuario { get; set; }
		public int idGrupoUsuario { get; set; }
		public string tipoUsuario { get; set; }
		public string nombreCompleto { get; set; }
		public string nombreUsuario { get; set; }
		public DateTime fecha_valides { get; set; }
		//cOMENTARIO
	}
}