namespace Api_Gestion_Clientes.Data
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Sexo { get; set; } = string.Empty;
    }
}
