using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        //public byte[] Image { get; set; }
        public string Image { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;

        public Post()
        {
            this.Categories = new HashSet<Category>();
        }

        public virtual ICollection<Category> Categories { get; set; }
    }
}