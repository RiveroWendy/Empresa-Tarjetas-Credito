using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Compra
    {
		private Cliente _cliente;

		public Cliente Cliente
		{
			get { return _cliente; }
			set { _cliente = value; }
		}

		private string _moneda;

		public string Moneda
		{
			get { return _moneda; }
			set { _moneda = value; }
		}

		private decimal _monto;

		public decimal Monto
		{
			get { return _monto; }
			set { _monto = value; }
		}
		public Compra()
		{

		}

		public void RecibirCompra(decimal monto)
		{
            Monto += monto;
        }

		public void ConfirmarCompra(decimal monto, string tipoMoneda, Tarjeta tarjeta)
		{

			if(tipoMoneda == "Peso")
			{
                tarjeta.SaldoPesos -= monto;
			}
			else
			{
                tarjeta.SaldoDolares -= monto;
            }

		}
		

	}
}
