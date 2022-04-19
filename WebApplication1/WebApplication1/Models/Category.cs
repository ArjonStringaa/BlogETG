//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApplication1.Models
//{
//    public class Category
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }
//        public string Name { get; set; } = "";

//        public Category()
//        {
//            this.Posts = new HashSet<Post>();
//        }

//        public virtual ICollection<Post> Posts { get; set; }

//    }
//}
