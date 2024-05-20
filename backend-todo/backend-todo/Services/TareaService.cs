using AutoMapper;
using backend_todo.Context;
using backend_todo.DTOs.Tarea;
using backend_todo.Exeptions;
using backend_todo.Interface;
using backend_todo.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_todo.Services
{
    public class TareaService : ITareaService
    {
        private readonly IGenericRepository<Tarea> _tareaRepository;
        private readonly IGenericRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapper;

        public TareaService(IGenericRepository<Tarea> tareaRepository, IGenericRepository<Categoria> categoriaRepository, IMapper mapper)
        {
            _tareaRepository = tareaRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<TareaDto> GetTareaAsync(int id)
        {
            IQueryable<Tarea> query = await _tareaRepository.Consultar(t => t.Id == id);

            var tareaObtenida = await query
                .Include(t => t.Categoria) // Incluir la categoria relacionada
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (tareaObtenida == null)
            {
                return null;
            }

            var tareaDTO = _mapper.Map<TareaDto>(tareaObtenida);

            return tareaDTO;
        }

        public async Task<List<TareaDto>> GetAllTareasAsync()
        {
            var tareasQuery = await _tareaRepository.Consultar();
            var tareas = tareasQuery.Include(t => t.Categoria).ToList();
            return _mapper.Map<List<TareaDto>>(tareas);
        }

        public async Task<TareaDto> CreateTareaAsync(CrearTareaDto tareaDto)
        {
            var categoriaExistente = await _categoriaRepository.Obtener(c => c.Id == tareaDto.CategoriaId);
            if (categoriaExistente == null)
            {
                throw new CustomException("La categoría especificada no existe.");
            }

            if (!Enum.IsDefined(typeof(EstadoTarea), tareaDto.Estado))
            {
                throw new CustomException("El estado especificado no es válido.");
            }

            var tarea = _mapper.Map<Tarea>(tareaDto);

            await _tareaRepository.Crear(tarea);
            return _mapper.Map<TareaDto>(tarea);
        }

        public async Task<TareaDto> UpdateTareaAsync(int id, ActualizarTareaDto tareaDto)
        {
            var tarea = await _tareaRepository.Obtener(t => t.Id == id);
            if (tarea == null)
            {
                return null;
            }

            var categoriaExistente = await _categoriaRepository.Obtener(c => c.Id == tareaDto.CategoriaId);
            if (categoriaExistente == null)
            {
                throw new CustomException("La categoría especificada no existe.");
            }

            if (!Enum.IsDefined(typeof(EstadoTarea), tareaDto.Estado))
            {
                throw new CustomException("El estado especificado no es válido.");
            }

            _mapper.Map(tareaDto, tarea);

            await _tareaRepository.Editar(tarea);
            return _mapper.Map<TareaDto>(tarea);
        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            var tarea = await _tareaRepository.Obtener(t => t.Id == id);
            if (tarea == null)
            {
                return false;
            }

            await _tareaRepository.Eliminar(tarea);
            return true;
        }
    }
}