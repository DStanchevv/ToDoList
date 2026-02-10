using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private static readonly string[] Tasks = new[]
        {
            "Task1", "Task2", "Task3", "Task4", "Task5"
        };

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTask"), Authorize]
        public IEnumerable<ToDo> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new ToDo
            {
                Task = Tasks[Random.Shared.Next(Tasks.Length)]
            })
            .ToArray();
        }
    }
}
