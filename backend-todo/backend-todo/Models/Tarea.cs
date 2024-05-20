using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_todo.Models
{
    public class Tarea : BaseDomainModel
    {
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [MaxLength]
        public string Descripcion { get; set; }

        public DateTime FechaFinalizacion { get; set; }

        [Required]
        public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;

        // categoria
        [Required]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
