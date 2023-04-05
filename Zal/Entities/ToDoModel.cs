using System.ComponentModel.DataAnnotations;

namespace Zal.Controllers
{
    public class ToDoModel
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public ToDoModel(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public ToDoModel()
        {
        }
    }

}