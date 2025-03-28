using EugeneCV.Models;
using EugeneCV.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
                var user = await _userService.AuthenticateUserAsync(userViewModel.Username, userViewModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Username/Password");
                    return View("Index");
                }

                // Retrieve user's role
                var role = await _userService.GetUserRole(user.RoleId);

                // Create claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, role) // Add role claim
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true // Keeps user logged in
                };

                await _userService.SaveLoggedInDate(user.Id);

                // Sign in user with claims-based authentication
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);


                return RedirectToAction("Index", "Home");

            }
            return View(userViewModel);

        }


    }
}
