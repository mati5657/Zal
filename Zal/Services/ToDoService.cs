using System.Collections.Generic;
using System.Reflection;
using Zal.Controllers;

namespace Zal
{
    public class ToDoService
    {
        private List<ToDoModel> ToDos = new List<ToDoModel>
        {
            new ToDoModel(1, "Cleaning", "I have to clean my room"),
            new ToDoModel(2, "Shopping", "Buy groceries for the week"),
            new ToDoModel(3, "Appointment", "Visit the doctor for a checkup"),
            new ToDoModel(4, "Exercise", "Go for a run in the park")
        };

        public void addToDo(ToDoModel toDo)
        {
            ToDos.Add(toDo);
        }

        public void removeTodo(int id)
        {
            ToDos.RemoveAll(t => t.Id == id); 
        }
        public List<ToDoModel> getAllToDos()
        {
            return ToDos;
        }
    }
}