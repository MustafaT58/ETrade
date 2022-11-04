using ETrade.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var usr = JsonConvert.DeserializeObject<UsersDTO>(HttpContext.Session.GetString("User"));
            ViewBag.User=usr.Email;
            return View();
        }
    }
}
