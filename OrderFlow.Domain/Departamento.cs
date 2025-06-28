namespace OrderFlow.Domain
{
    public class Departamento
    {
        public string DeptoCod { get; set; }
        public string NombreDepartament { get; set; }

        public Departamento() { }

        public Departamento(string deptoCod, string nombreDepartament)
        {
            DeptoCod = deptoCod;
            NombreDepartament = nombreDepartament;
        }
    }
}