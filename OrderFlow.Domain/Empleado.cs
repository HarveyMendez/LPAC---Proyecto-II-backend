using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFlow.Domain
{
    public class Empleado
    {
        private int idEmpleado;
        private string nombreEmpleado;
        private string apellidosEmpleado;
        private string puesto;
        private string extension;
        private string telefonoTrabajo;
        private int deptoCod;
        private int idRol;

        public Empleado()
        {
            // Constructor vacío
        }

        public Empleado(int idEmpleado, string nombreEmpleado, string apellidosEmpleado, string puesto, string extension, string telefonoTrabajo, int deptoCod, int idRol)
        {
            this.idEmpleado = idEmpleado;
            this.nombreEmpleado = nombreEmpleado;
            this.apellidosEmpleado = apellidosEmpleado;
            this.puesto = puesto;
            this.extension = extension;
            this.telefonoTrabajo = telefonoTrabajo;
            this.deptoCod = deptoCod;
            this.idRol = idRol;
        }

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public string ApellidosEmpleado { get => apellidosEmpleado; set => apellidosEmpleado = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public string Extension { get => extension; set => extension = value; }
        public string TelefonoTrabajo { get => telefonoTrabajo; set => telefonoTrabajo = value; }
        public int DeptoCod { get => deptoCod; set => deptoCod = value; }
        public int IdRol { get => idRol; set => idRol = value; }
    }
}

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
