namespace WebServiceIqtsStore.Entities
{
    public class Departamentos
    {
        public int id { get; set; }
        public string nombreDepartamento { get; set; }
    }

    public class Provincias
    {
        public int id { get; set; }
        public string nombreProvincia { get; set; }
        public int idDepartamento { get; set; }
    }

    public class Distritos
    {
        public int id { get; set; }
        public string nombreDistrito { get; set; }
        public int idProvincia { get; set; }
    }
}
