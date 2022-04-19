using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public int PageNumber { get; set; }
        public string Category { get; set; }
        public bool NextPage { get; set; }


    }
}
