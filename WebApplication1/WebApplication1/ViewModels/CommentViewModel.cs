using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        public int MainCommentId { get; set; }
        public string Message { get; set; }
    }
}
