namespace backend_todo.Models
{
    public class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? ActualizadoPor { get; set; }
    }
}
