using backend_todo.Models;

namespace backend_todo.DTOs.Tarea
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Estado { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
    }
}
