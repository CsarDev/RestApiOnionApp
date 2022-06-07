using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemHomeController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TodoItemHomeController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetTodoItemsHome(CancellationToken cancellationToken)
        {
            var todoItemsHomeDto = await _serviceManager.TodoItemHomeService.GetAllAsync(cancellationToken);

            return Ok(todoItemsHomeDto);
        }

        [HttpGet("{todoItemHomeId:guid}")]
        public async Task<IActionResult> GetTodoItemHomeById(Guid todoItemHome, CancellationToken cancellationToken)
        {
            var todoItemHomeDto = await _serviceManager.TodoItemHomeService.GetByIdAsync(todoItemHome, cancellationToken);

            return Ok(todoItemHomeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItemHome([FromBody] TodoItemForCreationDto todoItemForCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.TodoItemHomeService.CreateAsync(todoItemForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetTodoItemHomeById), new { todoItemHomeId = response.Id }, response);
        }

        [HttpDelete("{todoItemHomeId:guid}")]
        public async Task<IActionResult> DeleteTodoItemHome(Guid todoItemHomeId, CancellationToken cancellationToken)
        {
            await _serviceManager.TodoItemHomeService.DeleteAsync(todoItemHomeId, cancellationToken);

            return NoContent();
        }

    }
}
