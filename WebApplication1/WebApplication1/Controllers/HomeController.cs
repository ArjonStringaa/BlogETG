using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repository;
using WebApplication1.Data.FileManager;
using WebApplication1.Models.Comments;
using WebApplication1.ViewModels;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(
                IRepository repo,
                IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }



        //[HttpGet]
        //public IActionResult Index( string category)

        //{
        //    var posts = string.IsNullOrEmpty(category) ? _repo.GetAllPosts() : _repo.GetAllPosts(category);

        //    //boolean ? true : false  ..... 1=1 run : ignore
        //    return View(posts); 
        //}






        public IActionResult Index(int pageNumber, string category, string search)
        {
            if (pageNumber < 1)
                return RedirectToAction("Index", new { pageNumber = 1, category });

            var vm = _repo.GetAllPosts(pageNumber, category, search);

            return View(vm);
        }




        public IActionResult Post(int id)
        {
             var post = _repo.GetPost(id);  
            return View(post);
        }
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf(".") + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new {id = vm.PostId});
            var post = _repo.GetPost(vm.PostId);
            if (vm.MainCommentId == 0)  /*if its bigger than 0 is a subcomment else Is main comment*/
            {
                /*if its null createa list */
                post.MainComments = post.MainComments ?? new List<MainComment>();


                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now,


                });

                _repo.UpdatePost(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now,
                };
                
            }

            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = vm.PostId });

        }
    }
 }