using backend_todo.DTOs.Tarea;
using backend_todo.Models;

namespace backend_todo.Interface
{
    public interface ITareaService
    {
        Task<TareaDto> GetTareaAsync(int id);
        Task<List<TareaDto>> GetAllTareasAsync();
        Task<TareaDto> CreateTareaAsync(CrearTareaDto tareaDto);
        Task<TareaDto> UpdateTareaAsync(int id, ActualizarTareaDto tareaDto);
        Task<bool> DeleteTareaAsync(int id);
    }
}
