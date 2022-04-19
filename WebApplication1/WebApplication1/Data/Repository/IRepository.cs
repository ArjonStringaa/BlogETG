using System.Collections.Generic;
using WebApplication1.Models;
using System.Threading.Tasks;
using WebApplication1.Models.Comments;
using WebApplication1.ViewModels;

namespace WebApplication1.Data.Repository
    {
        public interface IRepository
        {
            public Post GetPost(int id);
            List<Post> GetAllPosts();
            IndexViewModel GetAllPosts(int pageNumber, string category
                , string search);
            List<Post> GetAllPosts(string category);

            IEnumerable<Post> Search (string searchTerm);  
            void RemovePost (int id);
            void  AddPost(Post post);
            void UpdatePost(Post post);
            void AddSubComment(SubComment comment);
            Task<bool> SaveChangesAsync();
        
        }
    }
