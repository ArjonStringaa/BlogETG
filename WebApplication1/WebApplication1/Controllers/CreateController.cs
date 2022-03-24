using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Data.Repository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CreateController : Controller
    {
        private IRepository _repo;
        public CreateController(IRepository repo)
        {
            _repo = repo;
        }
         
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            _repo.AddPost(post);
            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
            {
                return View(post);
            }
        } 


    }
}
