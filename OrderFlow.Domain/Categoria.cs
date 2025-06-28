namespace OrderFlow.Domain
{
    public class Categoria
    {
        public string CodCategoria { get; set; }
        public string Descripcion { get; set; }

        public Categoria() { }

        public Categoria(string codCategoria, string descripcion)
        {
            CodCategoria = codCategoria;
            Descripcion = descripcion;
        }
    }
}