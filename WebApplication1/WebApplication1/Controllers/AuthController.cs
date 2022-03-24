using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        public AuthController (SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVewModel());  
            //display page
       }

        [HttpPost]
        public async Task <IActionResult> Login(LoginVewModel vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
            return RedirectToAction ("Index", "Panel");
            //display page
        }

        [HttpGet]
        public async Task <IActionResult> Logout()

        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //display page
        }

    }
}
