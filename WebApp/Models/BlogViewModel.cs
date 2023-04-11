using System;

namespace NestorRojas_Blog.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDraft { get; set; }
    }
}
