using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Comments;

namespace WebApplication1.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
       
        public string Image { get; set; } = "";
        
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";



          
        public DateTime Created { get; set; } = DateTime.Now;

        public List<MainComment> MainComments { get; set; }

    }
} 