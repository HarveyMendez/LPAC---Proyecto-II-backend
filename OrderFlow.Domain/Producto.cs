namespace OrderFlow.Domain
{
    public class Producto
    {
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