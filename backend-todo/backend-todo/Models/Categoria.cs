using System.ComponentModel.DataAnnotations;

namespace backend_todo.Models
{
    public class Categoria : BaseDomainModel
    {
        [StringLength(100)]
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }

}
