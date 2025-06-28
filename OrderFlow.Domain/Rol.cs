using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFlow.Domain
{
    public class Rol
    {
        private int idRol;
        private string nombreRol;

        public Rol()
        {
            // Constructor vacío
        }

        public Rol(int idRol, string nombreRol)
        {
            this.idRol = idRol;
            this.nombreRol = nombreRol;
        }

        public int IdRol { get => idRol; set => idRol = value; }
        public string NombreRol { get => nombreRol; set => nombreRol = value; }
    }
}

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
