using AutoMapper;
using backend_todo.DTOs.Categoria;
using backend_todo.DTOs.Tarea;
using backend_todo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backend_todo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region tarea
            CreateMap<Tarea, TareaDto>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enum.GetName(typeof(EstadoTarea), src.Estado)))
                .ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.Categoria.Nombre));

            CreateMap<CrearTareaDto, Tarea>();
            CreateMap<ActualizarTareaDto, Tarea>();
            #endregion

            #region categoria
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<CrearCategoriaDto, Categoria>();
            CreateMap<ActualizarCategoriaDto, Categoria>();
            #endregion
        }
    }
}
