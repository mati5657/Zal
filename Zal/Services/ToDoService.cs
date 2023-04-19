using System;
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
                var todo = new ToDoModel
                {
                    userId = toDo.userId,
                    Title = toDo.Title,
                    Content = toDo.Content
                };

                _dbContext.ToDoModels.Add(todo);
                _dbContext.SaveChanges();
            }
        

        public void removeTodo(int id)
        {
         //   ToDos.RemoveAll(t => t.Id == id); 
        }
        public List<ToDoModel> getAllToDos()
        {
            return _dbContext.ToDoModels.ToList();
        }

        public List<ToDoModel> getCompletedToDos()
        {
            return _dbContext.ToDoModels
                .Where(t => t.Status == "Completed")
                .ToList();
        }

        public List<ToDoModel> getUpcomingToDos()
        {
            return _dbContext.ToDoModels
                .Where(t => t.Status == "Upcoming")
                .ToList();
        }
    }
}