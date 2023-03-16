using System.Reflection;
using Zal.Controllers;

namespace Zal
{
    public class ToDoService
    {
        private List<ToDoModel> ToDos = new List<ToDoModel>
        {
            new ToDoModel("Title","Content");
        }

    public void addToDo(ToDoModel toDo)
    {
        ToDos.add(toDo);
    }
    }

