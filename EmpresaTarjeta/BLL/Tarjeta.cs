using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class Tarjeta
	{
		private decimal _limiteCompra;

		public decimal LimiteCompra
		{
			get { return _limiteCompra; }
			set { _limiteCompra = value; }
		}

		private decimal _limiteMaximo;

		public decimal LimiteMaximo
		{
			get { return _limiteMaximo; }
			set { _limiteMaximo = value; }
		}

		private long _numeroTarjeta;

		public long NumeroTarjeta
		{
			get { return _numeroTarjeta; }
			set { _numeroTarjeta = value; }
		}

		private decimal _saldoPesos;

		public decimal SaldoPesos
		{
			get { return _saldoPesos; }
			set { _saldoPesos = value; }
		}

		private decimal _saldoDolares;

		public decimal SaldoDolares
		{
			get { return _saldoDolares; }
			set { _saldoDolares = value; }
		}


		private TipoTarjeta _tipoDeTarjeta;

		public TipoTarjeta TipoDeTarjeta 
		{
            get { return _tipoDeTarjeta; }
            set { _tipoDeTarjeta = value; }
        }

        // Constructor para inicializar una tarjeta Platinum
        public Tarjeta(long numeroTarjeta, decimal limiteCompra, decimal limiteMaximo, decimal saldoPesos)
        {
            NumeroTarjeta = numeroTarjeta;
            LimiteCompra = limiteCompra;
            LimiteMaximo = limiteMaximo;
			SaldoPesos = saldoPesos;
            TipoDeTarjeta = new Platinum();
        }

        // Constructor para inicializar una tarjeta Black
        public Tarjeta(long numeroTarjeta, decimal limiteCompra, decimal limiteMaximo, decimal saldoPesos, decimal saldoDolares)
        {
            NumeroTarjeta = numeroTarjeta;
            LimiteCompra = limiteCompra;
            LimiteMaximo = limiteMaximo;
			SaldoDolares = saldoDolares;
			SaldoPesos = saldoPesos;
            TipoDeTarjeta = new Black();  
        }

        public bool VerificarLimiteCompra(decimal monto)
		{
            //Se verifica el Limite por compra
			if (monto > LimiteCompra)
			{
				throw new ExcepcionMensaje("El monto de la compra excede el límite permitido para esta tarjeta.");
			}
            return true;
		}

        public bool VerificarLimiteMaximo(decimal monto, string tipoMoneda)
        {

            decimal saldoDisponiblePorTipo;
            //Se verifica el Limite Maximo

            if (tipoMoneda == "Peso")
            {
                saldoDisponiblePorTipo = SaldoPesos;
            }
            else if (tipoMoneda == "Dolar")
            {
                saldoDisponiblePorTipo = SaldoDolares;
            }
            else
            {
                throw new ArgumentException("Tipo de moneda no válido.");
            }

     
            if (saldoDisponiblePorTipo - monto < LimiteMaximo)
            {
                throw new ExcepcionMensaje("Ya se ha alcanzado el límite máximo de esta tarjeta.");
            }

            return true;
        }

        public decimal CalcularGastosAdministrativos(decimal monto, TipoTarjeta tipoTarjeta)
		{
			//monto -> total de precio de venta
			decimal totalGastoAdministrativo;
			if(tipoTarjeta.NombreTarjeta == "Black")
			{
                //se descuenta 1% black
                totalGastoAdministrativo = monto * 0.01m;
            }
			else
			{
                if (SaldoPesos <= 0 || SaldoDolares - monto <=0)
                {
                    //se descuenta 20% platinum
                    totalGastoAdministrativo = monto * 0.20m;
                }
                else
                {
                    //se descuenta 10% platinum
                    totalGastoAdministrativo = monto * 0.10m;
                }
            }
			return totalGastoAdministrativo;
		}

        public decimal CalcularImpuestos(decimal monto)
        {
            //Se calcula el 5% de impuesto
            return monto * 0.05m;
        }

		public void DepositarDolaresTarjeta(decimal monto)
		{
			SaldoDolares += monto;
		}

        public void DepositarPesosTarjeta(decimal monto)
        {
            SaldoPesos += monto;
        }
    }
}
