using OrganicStore.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace OrganicStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       

        [HttpPost]
        public IActionResult Login(UserOrganics2 user)
        {
            UserOrganics2 uModel = new UserOrganics2();
            SqlConnection conn = new SqlConnection(ConnectionMod.getConnectionString());
            string username = user.username;
            string password = user.password;
            string query = $"SELECT COUNT(*) FROM UserOrganics2 WHERE username = '{username}' AND password = '{password}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int rowsAffected = (int)cmd.ExecuteScalar();
            if(rowsAffected > 0){
                return RedirectToAction("Store", "Home", user);
            }
            return RedirectToAction("ErrorPage", "Home");
        }

       
    }
}
