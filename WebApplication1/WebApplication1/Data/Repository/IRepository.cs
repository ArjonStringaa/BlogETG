using System.Collections.Generic;
using WebApplication1.Models;
using System.Threading.Tasks;

    namespace WebApplication1.Data.Repository
    {
        public interface IRepository
        {
            public Post GetPost(int id);
            List<Post> GetAllPosts();
            void RemovePost (int id);
            void  AddPost(Post post);
            void UpdatePost(Post post);

            Task<bool> SaveChangesAsync();
        
        }
    }
