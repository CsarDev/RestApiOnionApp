
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Services.Abstractions;
using Xunit;

namespace Test
{
    public class TodoItemHomeControllerTests
    {
        private readonly Mock<IServiceManager> _serviceManager;
        public TodoItemHomeControllerTests()
        {
            _serviceManager = new Mock<IServiceManager>();
        }

        [Fact]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public void GetTodoItemsHome_ListOfTodoItemHome_TodoItemHomeExistsInRepo()
        {
            //arrange
            var todoItems = GetSampleTodoItemHome();
            _serviceManager.Setup(x => x.TodoItemHomeService.GetAllAsync(CancellationToken.None))
                .ReturnsAsync(GetSampleTodoItemHome);


            var controller = new TodoItemHomeController(_serviceManager.Object);

            //act
            var actionResult = controller.GetTodoItemsHome(new CancellationToken());
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<TodoItemDTO>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(GetSampleTodoItemHome().Count, actual.Count());
        }

        private List<TodoItemDTO> GetSampleTodoItemHome()
        {
            //{
            //    "id": "f644d6f0-61db-4194-f1fa-08da489deeb3",
            //"name": "FirstTaskHome                                                                                       ",
            //"isComplete": false,
            //"secret": null,
            //"dateCreated": "2022-06-07T15:53:25.163"
            //},
            //{
            //            "id": "b1e4d6f0-5966-439b-1a73-08da4a4b7708",
            //"name": "SecondTaskHome                                                                                      ",
            //"isComplete": true,
            //"secret": null,
            //"dateCreated": "2022-06-09T19:07:38.057"
            //}
            List<TodoItemDTO> output = new List<TodoItemDTO>
            {
                new TodoItemDTO
                {
                    Id = new Guid("f644d6f0-61db-4194-f1fa-08da489deeb3"),
                    Name = "FirstTaskHome",
                    IsComplete = false,
                    Secret = null,
                    DateCreated = DateTime.Parse("2022-06-07T15:53:25.163")
                },
                new TodoItemDTO
                {
                    Id = new Guid("b1e4d6f0-5966-439b-1a73-08da4a4b7708"),
                    Name = "SecondTaskHome",
                    IsComplete = true,
                    Secret = null,
                    DateCreated = DateTime.Parse("2022-06-09T19:07:38.057")
                }
            };
            return output;

        }
    }
}
