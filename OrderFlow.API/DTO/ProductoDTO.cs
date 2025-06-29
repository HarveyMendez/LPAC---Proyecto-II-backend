namespace OrderFlow.API.DTO
{
    public class ProductoDTO
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int codCategoria { get; set; }
        public int cantidadExistencias { get; set; }
        public int puntoReorden { get; set; }
    }
}
