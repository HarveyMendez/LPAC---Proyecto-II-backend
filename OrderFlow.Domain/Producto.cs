using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFlow.Domain
{
    public class Producto
    {
        private int idProducto;
        private string nombreProducto;
        private decimal precio;
        private int codCategoria;
        private int cantidadExistencias;
        private int puntoReorden;

        public Producto()
        {
            // Constructor vacío
        }

        public Producto(int idProducto, string nombreProducto, decimal precio, int codCategoria, int cantidadExistencias, int puntoReorden)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.precio = precio;
            this.codCategoria = codCategoria;
            this.cantidadExistencias = cantidadExistencias;
            this.puntoReorden = puntoReorden;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int CodCategoria { get => codCategoria; set => codCategoria = value; }
        public int CantidadExistencias { get => cantidadExistencias; set => cantidadExistencias = value; }
        public int PuntoReorden { get => puntoReorden; set => puntoReorden = value; }
    }
}
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public float Precio { get; set; }
        public string CodCategoria { get; set; }
        public int CantidadExistencias { get; set; }
        public int PuntoReorden { get; set; }
        public bool AplicaImpuesto { get; set; }
        public string Talla { get; set; }
        public bool Eliminado { get; set; }

        public Producto() { }

        public Producto(int idProducto, string nombreProducto, float precio, string codCategoria, int cantidadExistencias,
            int puntoReorden, bool aplicaImpuesto, string talla, bool eliminado)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            Precio = precio;
            CodCategoria = codCategoria;
            CantidadExistencias = cantidadExistencias;
            PuntoReorden = puntoReorden;
            AplicaImpuesto = aplicaImpuesto;
            Talla = talla;
            Eliminado = eliminado;
        }
    }
}
