using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public  IFormFile Image { get; set; } = null;
       
    }
}
