using System.Collections.Generic;

namespace WebApplication1.Models.Comments
{
    public class SubComment : Comment
    {
        public List <SubComment> SubComments { get; set; }
        public int MainCommentId { get; internal set; }
    }
}
