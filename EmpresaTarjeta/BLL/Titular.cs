using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Titular
    {
		private string _nombre = "";

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}


		private string _apellido = "";

		public string Apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}

		private long _documento;

		public long Documento
		{
			get { return _documento; }
			set { _documento = value; }
		}


	}
}
