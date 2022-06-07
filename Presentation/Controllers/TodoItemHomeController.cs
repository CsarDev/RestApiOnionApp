using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/todoItemsHome")]
    public class TodoItemHomeController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TodoItemHomeController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetTodoItemsHome(CancellationToken cancellationToken)
        {
            var accountsDto = await _serviceManager.TodoItemHomeService.GetAllAsync(cancellationToken);

            return Ok(accountsDto);
        }

        [HttpGet("{todoItemHomeId:guid}")]
        public async Task<IActionResult> GetTodoItemHomeById(Guid todoItemHome, CancellationToken cancellationToken)
        {
            var accountDto = await _serviceManager.TodoItemHomeService.GetByIdAsync(todoItemHome, cancellationToken);

            return Ok(accountDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItemHome([FromBody] TodoItemForCreationDto todoItemForCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.TodoItemHomeService.CreateAsync(todoItemForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetTodoItemHomeById), new { todoItemHomeId = response.Id }, response);
        }

        [HttpDelete("{todoItemHomeId:guid}")]
        public async Task<IActionResult> DeleteTodoItemHome(Guid accountId, CancellationToken cancellationToken)
        {
            await _serviceManager.TodoItemHomeService.DeleteAsync(accountId, cancellationToken);

            return NoContent();
        }

    }
}
