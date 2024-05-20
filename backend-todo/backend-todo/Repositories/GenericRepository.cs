using backend_todo.Context;
using backend_todo.Interface;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System;
using backend_todo.DTOs.Tarea;
using backend_todo.Exeptions;
using backend_todo.Models;

namespace backend_todo.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly TareasDbContext _aplicationDbContext;

        public GenericRepository(TareasDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
        }

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            try
            {
                TEntity entidad = await _aplicationDbContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                _aplicationDbContext.Set<TEntity>().Add(entidad);
                await _aplicationDbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                _aplicationDbContext.Update(entidad);
                await _aplicationDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                _aplicationDbContext.Remove(entidad);
                await _aplicationDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null)
        {
            IQueryable<TEntity> queryEntidad = filtro == null ? _aplicationDbContext.Set<TEntity>() : _aplicationDbContext.Set<TEntity>().Where(filtro);
            return queryEntidad;
        }

        public IQueryable<TEntity> ConsultarAsQueryable(Expression<Func<TEntity, bool>> filtro = null)
        {
            IQueryable<TEntity> queryEntidad = filtro == null ? _aplicationDbContext.Set<TEntity>() : _aplicationDbContext.Set<TEntity>().Where(filtro);
            return queryEntidad;
        }

    }
}
