﻿

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication1.Data.FileManager;
using WebApplication1.Data.Repository;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PanelController : Controller 
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IRepository repo,
            IFileManager fileManager)
        {

            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            { 
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id=post.Id,
                    Title = post.Title,
                    Body = post.Body,
                });
            }
        }




        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)

        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Image= await _fileManager.SaveImage(vm.Image),
                
            };

            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
                await _fileManager.SaveImage(vm.Image);
            }
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())

                return RedirectToAction("Index");
            else
                return View(post);
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
