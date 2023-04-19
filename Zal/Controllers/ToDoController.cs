using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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

        [HttpDelete("/delete/{id}")]
        public IActionResult RemoveToDoItem(int id)
        {
            _toDoService.removeTodo(id);
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