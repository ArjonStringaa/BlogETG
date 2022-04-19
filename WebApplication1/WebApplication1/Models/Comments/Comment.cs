using System;

namespace WebApplication1.Models.Comments
{
    public class Comment
    {
        public int Id  { get; set; }
        public string Message  { get; set; }
        public DateTime Created { get; set; }
    }
}
