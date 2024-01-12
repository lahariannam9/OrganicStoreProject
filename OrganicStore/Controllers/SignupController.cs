using Microsoft.AspNetCore.Mvc;
using OrganicStore.Models;
namespace OrganicStore.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserOrganics2 user){
           UserOrganics2 uModel = new UserOrganics2();
            uModel.username = user.username;
            uModel.email = user.email;
            uModel.password = user.password;
            int result = uModel.saveUserDetails();
            return RedirectToAction("Login", "Home");
        }
    }

}