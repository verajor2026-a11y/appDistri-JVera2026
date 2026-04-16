namespace app.JorgeVera.api.Entities
{
    public class Persona
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int Edad { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public bool Activo { get; set; }
    }
}
