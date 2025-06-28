using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFlow.Domain
{
    public class MetodoPago
    {
        private int idMetodoPago;
        private string metodoPagoNombre;

        public MetodoPago()
        {
            // Constructor vacío
        }

        public MetodoPago(int idMetodoPago, string metodoPagoNombre)
        {
            this.idMetodoPago = idMetodoPago;
            this.metodoPagoNombre = metodoPagoNombre;
        }

        public int IdMetodoPago { get => idMetodoPago; set => idMetodoPago = value; }
        public string MetodoPagoNombre { get => metodoPagoNombre; set => metodoPagoNombre = value; }
    }
}

        public int IdMetodoPago { get; set; }
        public string MedotoPago { get; set; }
        public bool TarjetaCredito { get; set; }

        public MetodoPago() { }

        public MetodoPago(int idMetodoPago, string medotoPago, bool tarjetaCredito)
        {
            IdMetodoPago = idMetodoPago;
            MedotoPago = medotoPago;
            TarjetaCredito = tarjetaCredito;
        }
    }
}

