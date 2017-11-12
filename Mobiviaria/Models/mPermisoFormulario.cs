using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobiviaria
{
	public class PermisoFormulario
	{
		public string IdFormulario { get; set; }
		public string IdPadre { get; set; }
		public string Descripcion { get; set; }
		public int Posicion { get; set; }
		public string Url { get; set; }
		public string Icono { get; set; }
		public string Paginas { get; set; }
		public bool Adicionar { get; set; }
		public bool Editar { get; set; }
		public bool Eliminar { get; set; }
		public bool Ver { get; set; }
	}
}