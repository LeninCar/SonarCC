using AutoMapper;
using backend_todo.DTOs.Categoria;
using backend_todo.Interface;
using backend_todo.Models;

namespace backend_todo.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> GetCategoriaAsync(int id)
        {
            var categoria = await _categoriaRepository.Obtener(c => c.Id == id);

            if (categoria == null)
            {
                return null;
            }

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);

            return categoriaDto;
        }

        public async Task<List<CategoriaDto>> GetAllCategoriasAsync()
        {
            var categoriasQuery = await _categoriaRepository.Consultar();
            var categorias = categoriasQuery.ToList();
            return _mapper.Map<List<CategoriaDto>>(categorias);
        }

        public async Task<CategoriaDto> CreateCategoriaAsync(CrearCategoriaDto categoriaDto)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDto.Nombre
            };

            await _categoriaRepository.Crear(categoria);
            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task<CategoriaDto> UpdateCategoriaAsync(int id, ActualizarCategoriaDto categoriaDto)
        {
            var categoria = await _categoriaRepository.Obtener(c => c.Id == id);
            if (categoria == null)
            {
                return null;
            }

            categoria.Nombre = categoriaDto.Nombre;

            await _categoriaRepository.Editar(categoria);
            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var categoria = await _categoriaRepository.Obtener(c => c.Id == id);
            if (categoria == null)
            {
                return false;
            }

            await _categoriaRepository.Eliminar(categoria);
            return true;
        }
    }
}
