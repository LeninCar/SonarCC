using backend_todo.Models;

namespace backend_todo.DTOs.Tarea
{
    public class ActualizarTareaDto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public EstadoTarea Estado { get; set; }
        public int CategoriaId { get; set; }
    }
}
