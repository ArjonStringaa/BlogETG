using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public AuthController (
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
            //todo redirect only admin to the panel
            if(!result.Succeeded)
            {
                return View(vm);
            }
            var user = await _userManager.FindByNameAsync(vm.UserName);
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin)
            {
                return RedirectToAction("Index", "Panel");

            }
            return RedirectToAction("Index", "Home");

            //display page
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            var user = new IdentityUser
            {

                UserName = vm.Email,
                Email = vm.Email
            };
            var result = await _userManager.CreateAsync(user, "password");

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index","Home");

            }
            return View(vm);
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
