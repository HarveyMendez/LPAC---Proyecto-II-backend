namespace OrderFlow.API.DTO
{
    public class ProductoDTO
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; } = string.Empty;
        public float precio { get; set; }
        public CategoriaDTO categoria { get; set; } = new CategoriaDTO();
        public int cantidadExistencias { get; set; }
        public int puntoReorden { get; set; }
        public bool aplicaImpuesto { get; set; } = false;
        public string talla { get; set; } = string.Empty;
    }
}
