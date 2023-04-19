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
        public string Status { get; set; }


        public ToDoModel(int id, string title, string content, string status)
        {
            Id = id;
            Title = title;
            Content = content;
            Status = status;
        }

        public ToDoModel()
        {
        }
    }

}