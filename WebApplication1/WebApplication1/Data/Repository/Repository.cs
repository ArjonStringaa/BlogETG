using System.Collections.Generic;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Comments;
using WebApplication1.ViewModels;
using System;


//logic//
namespace WebApplication1.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;
        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);

        }

        public List<Post> GetAllPosts()
        {

            return _ctx.Posts.ToList();
        }
        //FILTERBy CATEGORY
       //public IndexViewModel GetAllPosts(string category)
       //{
       //     return _ctx.Posts
       //         .Where(post => post.Category.ToLower().Equals(category.ToLower()))
       //         .ToList();
       // }



        public IndexViewModel GetAllPosts(
            int pageNumber,
            string category,
            string search)
        {
            Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category.ToLower()); };
            int pageSize = 5;
            int skipAmount = pageSize * (pageNumber - 1);
            int capacity = skipAmount + pageSize;

            var query = _ctx.Posts.AsNoTracking().AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query = query.Where(x => InCategory(x));

            if (!String.IsNullOrEmpty(search))
                query = query.Where(x =>    x.Title.Contains(search) 
                                        ||  x.Body.Contains(search) 
                                        ||  x.Description.Contains(search));

            int postsCount = query.Count();


            return new IndexViewModel
            {
                PageNumber = pageNumber,
                NextPage = postsCount > skipAmount + pageSize,
                Category = category,    
                Posts = query
                        .Skip(skipAmount)
                        .Take(pageSize)  
                        .ToList()
            };
        }

        //type id , gets the id and compares if they same it turns back the post id number//
        public Post GetPost(int id)
        {
            return _ctx.Posts
                .Include(p=>p.MainComments)
                //.ThenInclude(mc => mc.SubComments)
                .FirstOrDefault(p =>p.Id==id);
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        
        
        
        //what makes the changes to the database//
        
        public async Task<bool>SaveChangesAsync()
        { 

            if(await _ctx.SaveChangesAsync()>0)
            {
                return true;
            }
            else
            return false;    
            
        }

        public void AddSubComment(SubComment comment)
        {
            _ctx.SubComments.Add(comment);
        }

        IEnumerable<Post> IRepository.Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) 
            { 
            return _ctx.Posts;
            }
            return _ctx.Posts.Where(e => e.Body.Contains(searchTerm)
                                    || e.Title.Contains(searchTerm)
                                    || e.Category.Contains(searchTerm)
                                    || e.Description.Contains(searchTerm));
                    
        }

        public List<Post> GetAllPosts(string category)
        {
            return _ctx.Posts
                .Where(post => post.Category.ToLower().Equals(category.ToLower()))
                .ToList();        }
        }
    }
