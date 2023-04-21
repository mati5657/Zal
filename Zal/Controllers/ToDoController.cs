using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Zal.Entities;

namespace Zal.Controllers
{
    [ApiController]
    [Route("/todo")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost]
        public IActionResult AddToDoItem([FromBody] ToDoModel toDo)
        {
            _toDoService.addToDo(toDo);
            return Ok();
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GetToDos()
        {
            var toDos = _toDoService.getAllToDos();

            var result = toDos.Select(x => new { x.Title, x.Content });
            return Ok(result);
        }

        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/todo/complete")]
        public IActionResult CompleteTodo([FromBody] CompleteToDoModel model)
        {
            var titleOfTodoToComplete = model.title;
            _toDoService.completeToDoByTitle(titleOfTodoToComplete);
            return Ok();
        }

        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/todo/done")]
        public IActionResult FinishTodo([FromBody] CompleteToDoModel model)
        {
            var titleOfTodoToComplete = model.title;
            _toDoService.deleteTodoBy(titleOfTodoToComplete);
            return Ok();
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/todo/completed")]
        public IActionResult GetCompletedToDos()
        {
            var toDos = _toDoService.getCompletedToDos();

            var result = toDos.Select(x => new { x.Title, x.Content });
            return Ok(result);
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/todo/upcoming")]
        public IActionResult GetUpcomingToDos()
        {
            var toDos = _toDoService.getUpcomingToDos();

            var result = toDos.Select(x => new { x.Title, x.Content });
            return Ok(result);
        }
    }
}