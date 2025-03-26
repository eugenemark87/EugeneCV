using EugeneCV.Models;
using EugeneCV.Services;
using Microsoft.AspNetCore.Mvc;

namespace EugeneCV.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService UserService)
        {
            _userService = UserService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Login(UserViewModel userViewModel)
        {
           
            if (ModelState.IsValid)
            {
               var user =  await _userService.AuthenticateUserAsync(userViewModel.Username, userViewModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Username/Password");
                    return View("Index");
                }

                //store session
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);


                return RedirectToAction("Index", "Home");

            }
            return View(userViewModel);

        }


    }
}
