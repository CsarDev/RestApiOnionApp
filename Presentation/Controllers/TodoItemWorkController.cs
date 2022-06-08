using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemWorkController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TodoItemWorkController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetTodoItemsWork(CancellationToken cancellationToken)
        {
            var todoItemsWorkDto = await _serviceManager.TodoItemWorkService.GetAllAsync(cancellationToken);

            return Ok(todoItemsWorkDto);
        }

        [HttpGet("{todoItemWorkId:guid}")]
        public async Task<IActionResult> GetTodoItemWorkById(Guid todoItemWork, CancellationToken cancellationToken)
        {
            var todoItemWorkDto = await _serviceManager.TodoItemWorkService.GetByIdAsync(todoItemWork, cancellationToken);

            return Ok(todoItemWorkDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItemWork([FromBody] TodoItemForCreationDto todoItemForCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.TodoItemWorkService.CreateAsync(todoItemForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetTodoItemWorkById), new { todoItemHomeId = response.Id }, response);
        }

        [HttpDelete("{todoItemWorkId:guid}")]
        public async Task<IActionResult> DeleteTodoItemWork(Guid todoItemWorkId, CancellationToken cancellationToken)
        {
            await _serviceManager.TodoItemWorkService.DeleteAsync(todoItemWorkId, cancellationToken);

            return NoContent();
        }

    }
}
