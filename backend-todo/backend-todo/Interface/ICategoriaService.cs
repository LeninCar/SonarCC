using backend_todo.DTOs.Categoria;

namespace backend_todo.Interface
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> GetCategoriaAsync(int id);
        Task<List<CategoriaDto>> GetAllCategoriasAsync();
        Task<CategoriaDto> CreateCategoriaAsync(CrearCategoriaDto categoriaDto);
        Task<CategoriaDto> UpdateCategoriaAsync(int id, ActualizarCategoriaDto categoriaDto);
        Task<bool> DeleteCategoriaAsync(int id);
    }
}
