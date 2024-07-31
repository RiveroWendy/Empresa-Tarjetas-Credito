using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExcepcionMensaje : Exception
    {
        public ExcepcionMensaje(string mensaje) : base(mensaje) { }

    }
}
