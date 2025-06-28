namespace OrderFlow.Domain
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string Puesto { get; set; }
        public string Extension { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string DeptoCod { get; set; }
        public int IdRol { get; set; }

        public Empleado() { }

        public Empleado(int idEmpleado, string nombreEmpleado, string apellidosEmpleado, string puesto, string extension,
            string telefonoTrabajo, string deptoCod, int idRol)
        {
            IdEmpleado = idEmpleado;
            NombreEmpleado = nombreEmpleado;
            ApellidosEmpleado = apellidosEmpleado;
            Puesto = puesto;
            Extension = extension;
            TelefonoTrabajo = telefonoTrabajo;
            DeptoCod = deptoCod;
            IdRol = idRol;
        }
    }
}