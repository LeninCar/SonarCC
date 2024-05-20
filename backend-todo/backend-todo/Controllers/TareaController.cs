using backend_todo.DTOs.Tarea;
using backend_todo.Exeptions;
using backend_todo.Interface;
using backend_todo.Models;
using backend_todo.Models.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDto>> GetTarea(int id)
        {
            var tarea = await _tareaService.GetTareaAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }

        [HttpGet]
        public async Task<ActionResult<List<TareaDto>>> GetAllTareas()
        {
            var tareas = await _tareaService.GetAllTareasAsync();
            return tareas;
        }

        [HttpPost]
        public async Task<ActionResult<TareaDto>> CreateTarea(CrearTareaDto tareaDto)
        {
            try
            {
                var createdTarea = await _tareaService.CreateTareaAsync(tareaDto);
                return CreatedAtAction(nameof(GetTarea), new { id = createdTarea.Id }, createdTarea);
            }
            catch (CustomException ex)
            {
                return BadRequest(new ErrorResponse(400, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarea(int id, ActualizarTareaDto tareaDto)
        {
            var updatedTarea = await _tareaService.UpdateTareaAsync(id, tareaDto);
            if (updatedTarea == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var result = await _tareaService.DeleteTareaAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}