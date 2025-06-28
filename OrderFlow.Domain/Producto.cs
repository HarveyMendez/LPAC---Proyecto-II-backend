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
