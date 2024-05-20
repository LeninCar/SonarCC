using backend_todo.DTOs.Categoria;
using backend_todo.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoria(int id)
        {
            var categoria = await _categoriaService.GetCategoriaAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaDto>>> GetCategorias()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();
            return categorias;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> PostCategoria(CrearCategoriaDto categoriaDto)
        {
            try
            {
                var categoria = await _categoriaService.CreateCategoriaAsync(categoriaDto);
                return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, ActualizarCategoriaDto categoriaDto)
        {
            try
            {
                await _categoriaService.UpdateCategoriaAsync(id, categoriaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                var result = await _categoriaService.DeleteCategoriaAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}