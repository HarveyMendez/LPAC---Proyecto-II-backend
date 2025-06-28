using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFlow.Domain
{
    public class Pagos
    {
        private int idPago;
        private int idOrden;
        private decimal cantidadPago;
        private DateTime fechaPago;
        private string numTarjetaCredito;
        private int idMetodoPago;

        public Pagos()
        {
            // Constructor vacío
        }

        public Pagos(int idPago, int idOrden, decimal cantidadPago, DateTime fechaPago, string numTarjetaCredito, int idMetodoPago)
        {
            this.idPago = idPago;
            this.idOrden = idOrden;
            this.cantidadPago = cantidadPago;
            this.fechaPago = fechaPago;
            this.numTarjetaCredito = numTarjetaCredito;
            this.idMetodoPago = idMetodoPago;
        }

        public int IdPago { get => idPago; set => idPago = value; }
        public int IdOrden { get => idOrden; set => idOrden = value; }
        public decimal CantidadPago { get => cantidadPago; set => cantidadPago = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public string NumTarjetaCredito { get => numTarjetaCredito; set => numTarjetaCredito = value; }
        public int IdMetodoPago { get => idMetodoPago; set => idMetodoPago = value; }
    }
}

        public int IdPago { get; set; }
        public int IdOrden { get; set; }
        public double CantidadPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string NumTarjetaCredito { get; set; }
        public string NomUsuarioTarjeta { get; set; }
        public int IdMetodoPago { get; set; }

        public Pagos() { }

        public Pagos(int idPago, int idOrden, double cantidadPago, DateTime fechaPago, string numTarjetaCredito,
            string nomUsuarioTarjeta, int idMetodoPago)
        {
            IdPago = idPago;
            IdOrden = idOrden;
            CantidadPago = cantidadPago;
            FechaPago = fechaPago;
            NumTarjetaCredito = numTarjetaCredito;
            NomUsuarioTarjeta = nomUsuarioTarjeta;
            IdMetodoPago = idMetodoPago;
        }
    }
}
