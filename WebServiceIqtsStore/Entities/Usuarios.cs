namespace WebServiceIqtsStore.Entities
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nombreApellido { get; set; }
        public string correo { get; set; }
        public string? password { get; set; }
        public string? celular { get; set; }
        public string? uIdUsuario { get; set; }
        public bool estadoUsuario { get; set; }
        public int idTipoUsuario { get; set; }
    }

    public class domicilioUsuario
    {
        public int id { get; set; }
        public string nombreDireccion { get; set; }
        public string pisoDepartamentoDireccion { get; set; }
        public string referencia { get; set; }
        public string nombreDepartamento { get; set; }
        public string nombreProvincia { get; set; }
        public string nombreDistrito { get; set; }
        public int idUsuario { get; set; }
    }
}
