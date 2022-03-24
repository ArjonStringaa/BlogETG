﻿using Microsoft.AspNetCore.Mvc;

using WebApplication1.Data.Repository;

using WebApplication1.Data.FileManager;

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
        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
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
        
    }
 }