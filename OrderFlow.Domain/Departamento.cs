using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    public class Departamento
    {
        private int deptoCod;
        private string nombreDepartament;

        public Departamento()
        {
            // Constructor vacío
        }

        public Departamento(int deptoCod, string nombreDepartament)
        {
            this.deptoCod = deptoCod;
            this.nombreDepartament = nombreDepartament;
        }

        public int DeptoCod { get => deptoCod; set => deptoCod = value; }
        public string NombreDepartament { get => nombreDepartament; set => nombreDepartament = value; }
    }
}
