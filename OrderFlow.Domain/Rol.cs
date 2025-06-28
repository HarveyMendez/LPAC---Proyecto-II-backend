namespace OrderFlow.Domain
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public Rol() { }

        public Rol(int idRol, string nombreRol)
        {
            IdRol = idRol;
            NombreRol = nombreRol;
        }
    }
}