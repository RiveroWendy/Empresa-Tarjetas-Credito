using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
		private long _documento;

		public long Documento
		{
			get { return _documento; }
			set { _documento = value; }
		}

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

        private List<Titular> _titulares = new List<Titular>();
        public List<Titular> Titulares
        {
            get { return _titulares; }
            set { _titulares = value; }
        }

        private List<Tarjeta> _tarjetas = new List<Tarjeta>();
        public List<Tarjeta> Tarjetas
        {
            get { return _tarjetas; }
            set { _tarjetas = value; }
        }

        public Cliente()
		{

		}
        public void AgregarTarjeta(Tarjeta nuevaTarjeta)
        {
            Tarjetas.Add(nuevaTarjeta);
        }

        public void AgregarTitular(Titular nuevoTitular)
        {
            Titulares.Add(nuevoTitular);
        }
        
    }
}
