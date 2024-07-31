using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class TipoTarjeta
    {

        private string _nombreTarjeta;

        public string NombreTarjeta
        {
            get { return _nombreTarjeta; }
            set { _nombreTarjeta = value; }
        }


        protected TipoTarjeta(string _nombreTarjeta)
        {
            NombreTarjeta = _nombreTarjeta;
        }



    }
}
