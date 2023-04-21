using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
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
            try
            {
                var todo = new ToDoModel
                {
                    userId = toDo.userId,
                    Title = toDo.Title,
                    Content = toDo.Content,
                    Status = "Upcoming"
                };

                _dbContext.ToDoModels.Add(todo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }


        public void completeToDoByTitle(string title)
        {
            var todo = _dbContext.ToDoModels.SingleOrDefault(t => t.Title == title);
            if (todo != null)
            {
                todo.Status = "Completed";
                _dbContext.SaveChanges();
            }
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

        public void deleteTodoBy(string title)
        {
            var todo = _dbContext.ToDoModels.FirstOrDefault(t => t.Title == title);

            if (todo != null)
            {
                _dbContext.ToDoModels.Remove(todo);
                _dbContext.SaveChanges();
            }
        }
    }
}