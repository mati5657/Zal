using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zal.Controllers;
using Zal.Services;

namespace Zal
{
    public class ToDoService
    {
        private readonly TodoDbContext _dbContext;

        public ToDoService(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void addToDo(ToDoModel toDo)
        {
      //      ToDos.Add(toDo);
        }

        public void removeTodo(int id)
        {
         //   ToDos.RemoveAll(t => t.Id == id); 
        }
        public List<ToDoModel> getAllToDos()
        {
            return _dbContext.ToDoModels.ToList();
        }
    }
}